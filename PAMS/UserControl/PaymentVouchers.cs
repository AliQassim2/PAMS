using PAMS.environment;
using PAMS.Models;
using System.Data;

namespace PAMS
{
    public partial class PaymentVouchers : UserControl
    {
        private string currentUser = string.Empty;
        private string usertype = string.Empty;
        public PaymentVouchers()
        {
            InitializeComponent();
            LoadData();

        }
        public void LoadData()
        {
            dataGridView1.DataSource = PaymentModel.GetAllPayments();
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["ProjectID"].Visible = false;
            dataGridView1.Columns["ExecutorID"].Visible = false;
            dataGridView1.Columns["Project Name"].HeaderText = "اسم المشروع";
            dataGridView1.Columns["Executor Name"].HeaderText = "اسم الجهة المنفذة";
            dataGridView1.Columns["Date"].HeaderText = "تاريخ الدفع";
            dataGridView1.Columns["Amount"].HeaderText = "المبلغ المدفوع";
            dataGridView1.Columns["Notes"].HeaderText = "الملاحظات";
            dataGridView1.Columns["Date"].Width = dataGridView1.Columns["Amount"].Width = dataGridView1.Columns["Executor Name"].Width = 150;
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
            dt.DefaultView.RowFilter = string.Format($"[Project Name] LIKE '{textBox1.Text}%' OR [Executor Name] LIKE '{textBox1.Text}%'");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ProjectModel.GetAllProjects().Rows.Count == 0)
            {
                MessageBox.Show("لا يوجد جهات مشاريع مسجلة في النظام", "خطا في البيانات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            List<string> labels = new List<string>() { "تاريخ الموصل", "المبلغ", "الملاحضات", "المشروع", "الجهة المنفذة" };
            Add_Edit Add = new("PaymentVouchers", labels, [], string.Empty);
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
                MessageBox.Show("لا يوجد  مشاريع مسجلة في النظام", "خطا في البيانات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            List<string> labels = new List<string>() { "تاريخ الموصل", "المبلغ", "الملاحضات", "المشروع", "الجهة المنفذة" };
            string id = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            string date = dataGridView1.CurrentRow.Cells["Date"].Value.ToString();
            string amount = dataGridView1.CurrentRow.Cells["Amount"].Value.ToString();
            string notes = dataGridView1.CurrentRow.Cells["Notes"].Value.ToString();
            string projectID = dataGridView1.CurrentRow.Cells["ProjectID"].Value.ToString();
            string executorID = dataGridView1.CurrentRow.Cells["ExecutorID"].Value.ToString();
            List<string> values = new List<string>() { date, amount, notes, projectID, executorID };
            Add_Edit edit = new("PaymentVouchers", labels, values, id);
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
                if (PaymentModel.DeletePayment(id))
                {
                    MessageBox.Show("تم حذف السجل بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(); // Reload data after deletion
                }
                else
                {
                    MessageBox.Show("حدث خطأ أثناء حذف السجل.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
