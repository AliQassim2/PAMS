using PAMS.Models;
using System.Data;

namespace PAMS
{
    public partial class ReceiptVouchers : UserControl
    {
        private string currentUser = string.Empty;
        private string usertype = string.Empty;
        public ReceiptVouchers()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            dataGridView1.DataSource = ReceiptModel.GetAllReceipts();
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["ProjectID"].Visible = false;
            dataGridView1.Columns["Project Name"].HeaderText = "اسم المشروع";
            dataGridView1.Columns["Date"].HeaderText = "تاريخ الدفع";
            dataGridView1.Columns["Amount"].HeaderText = "المبلغ المدفوع";
            dataGridView1.Columns["Notes"].HeaderText = "الملاحظات";
            dataGridView1.Columns["Date"].Width = dataGridView1.Columns["Amount"].Width = 150;
            if (usertype == "3")
            {
                button1.Visible = button2.Visible = button3.Visible = false;
            }
        }
        public void GetCurrentUser(UserModel user)
        {
            currentUser = user.Id;
            usertype = user.Type;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell = null;
            DataTable dt = (DataTable)dataGridView1.DataSource;
            dt.DefaultView.RowFilter = string.Format("[Project Name] like '" + textBox1.Text + "%'");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ProjectModel.GetAllProjects().Rows.Count == 0)
            {
                MessageBox.Show("لا يوجد  مشاريع مسجلة في النظام", "خطا في البيانات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            List<string> labels = new List<string>() { "تاريخ الموصل", "المبلغ", "الملاحضات", "المشروع" };
            Add_Edit Add = new Add_Edit("ReceiptVouchers", labels, [], string.Empty);

            Add.ShowDialog();
            LoadData(); // Reload data after adding or editing
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("الرجاء تحديد صف واحد على الأقل للتعديل.", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (ProjectModel.GetAllProjects().Rows.Count == 0)
            {
                MessageBox.Show("لا يوجد جهات مشاريع مسجلة في النظام", "خطا في البيانات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            List<string> labels = new List<string>() { "تاريخ الموصل", "المبلغ", "الملاحضات", "المشروع" };
            string id = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            string date = dataGridView1.CurrentRow.Cells["Date"].Value.ToString();
            string amount = dataGridView1.CurrentRow.Cells["Amount"].Value.ToString();
            string notes = dataGridView1.CurrentRow.Cells["Notes"].Value.ToString();
            string projectID = dataGridView1.CurrentRow.Cells["ProjectID"].Value.ToString();
            List<string> values = new List<string>() { date, amount, notes, projectID };
            Add_Edit edit = new Add_Edit("ReceiptVouchers", labels, values, id);
            edit.ShowDialog();
            LoadData(); // Reload data after adding or editing
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("الرجاء تحديد صف واحد على الأقل للحذف.", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string id = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            string projectName = dataGridView1.CurrentRow.Cells["Project Name"].Value.ToString();
            DialogResult result = MessageBox.Show($"هل أنت متأكد أنك تريد حذف السجل الخاص بالمشروع '{projectName}'؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                ReceiptModel.DeleteReceipt(id);
                MessageBox.Show("تم حذف السجل بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.None);
                LoadData(); // Reload data after deletion
            }
        }
    }
}
