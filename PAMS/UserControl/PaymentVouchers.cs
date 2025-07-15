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
            gridControl1.DataSource = PaymentModel.GetAllPayments();
            gridView1.PopulateColumns(); // Optional: ensures columns are created if not using designer
            gridView1.Columns["id"].Visible = false;
            gridView1.Columns["ProjectID"].Visible = false;
            gridView1.Columns["ExecutorID"].Visible = false;
            gridView1.Columns["Project Name"].Caption = "اسم المشروع";
            gridView1.Columns["Executor Name"].Caption = "اسم الجهة المنفذة";
            gridView1.Columns["Date"].Caption = "تاريخ الدفع";
            gridView1.Columns["Amount"].Caption = "المبلغ المدفوع";
            gridView1.Columns["Notes"].Caption = "الملاحظات";
            gridView1.Columns["Date"].Width = gridView1.Columns["Amount"].Width = gridView1.Columns["Executor Name"].Width = 150;
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
            if (gridView1.FocusedRowHandle < 0)
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
            string id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id")?.ToString();
            string date = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Date")?.ToString();
            string amount = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Amount")?.ToString();
            string notes = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Notes")?.ToString();
            string projectID = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProjectID")?.ToString();
            string executorID = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ExecutorID")?.ToString();
            List<string> values = new List<string>() { date, amount, notes, projectID, executorID };
            Add_Edit edit = new("PaymentVouchers", labels, values, id);
            edit.ShowDialog();
            LoadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0)
            {
                MessageBox.Show("الرجاء تحديد صف واحد على الأقل للحذف.", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id")?.ToString();
            string projectName = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Project Name")?.ToString();
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
