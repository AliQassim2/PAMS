using DevExpress.XtraGrid;
using PAMS.Models;
using System.Data;

namespace PAMS
{
    public partial class Projects : UserControl
    {
        private static string ProjectID = string.Empty;
        private static readonly string BeneficiarieID = string.Empty;
        private string currentUser = string.Empty;
        private string usertype = string.Empty;
        public Projects()
        {
            InitializeComponent();       
        }
        public void LoadData()
        {
            gridControl1.DataSource = ProjectModel.GetAllProjects();
            gridView1.PopulateColumns(); // Optional: ensures columns are created if not using designer

            // Hide unnecessary columns
            gridView1.Columns["BeneficiaryID"].Visible = false;
            gridView1.Columns["add_by"].Visible = false;
            gridView1.Columns["ID"].Visible = false;
            gridView1.Columns["Type"].Visible = false;

            // Set headers (captions)
            gridView1.Columns["Name"].Caption = "اسم المشروع";
            gridView1.Columns["TypeName"].Caption = "نوع المشروع";
            gridView1.Columns["StartDate"].Caption = "تاريخ البدء";
            gridView1.Columns["AllocatedAmount"].Caption = "المبلغ المخصص";
            gridView1.Columns["BeneficiarieName"].Caption = "اسم الجهة المستفيدة";
            gridView1.Columns["UsernameAdded"].Caption = "اسم المستخدم الذي قام بالاضافة";
            gridView1.Columns["CreatedAt"].Caption = "تاريخ الاضافة";

            // Set column widths
            gridView1.Columns["BeneficiarieName"].Width = 150;
            gridView1.Columns["StartDate"].Width = 150;
            gridView1.Columns["AllocatedAmount"].Width = 150;
            gridView1.Columns["UsernameAdded"].Width = 150;
            gridView1.Columns["CreatedAt"].Width = 150;
            if (usertype == "3")
            {
                buttonAdd.Visible = buttonEdit.Visible = buttonDelete.Visible = false;
            }
            gridView1.Columns["Name"].OptionsFilter.AllowFilter = true;
        }
        public void GetCurrentUser(UserModel user)
        {
            currentUser = user.Id;
            usertype = user.Type;
        }
       

        private void button3_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0)
            {
                MessageBox.Show("لم يتم اختيار العنصر المراد حذفه", "لم يتم اختيار العنصر", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string? projectName = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Name")?.ToString();
            string? projectId = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID")?.ToString();


            DialogResult result = MessageBox.Show($"هل انت متاكد من حذف المشروع {projectName}؟", "تاكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (ProjectModel.DeleteProject(projectId))
                    MessageBox.Show("تم الحذف بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadData();

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (currentUser == string.Empty)
            {
                MessageBox.Show("يرجى تسجيل الدخول اولا", "خطا في تسجيل الدخول", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (BeneficiaryModel.GetAllBeneficiaries().Rows.Count == 0)
            {
                MessageBox.Show("لا يوجد جهات مستفيدة مسجلة في النظام", "خطا في البيانات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            List<string> labels = new List<string>() { "اسم المشروع", "نوع المشروع", "تاريخ البداء", "المبلغ المخصص له", "الجهة المستفيدة" };
            Add_Edit Add = new Add_Edit("Project", labels, [],string.Empty,currentUser);
            Add.ShowDialog();
            LoadData();

        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {

            if (gridView1.FocusedRowHandle < 0) { 
                MessageBox.Show("يرجى اختيار مشروع المراد تعديله","خطا في اختيار",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (currentUser == string.Empty)
            {
                MessageBox.Show("يرجى تسجيل الدخول اولا", "خطا في تسجيل الدخول", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (BeneficiaryModel.GetAllBeneficiaries().Rows.Count == 0)
            {
                MessageBox.Show("لا يوجد جهات مستفيدة مسجلة في النظام", "خطا في البيانات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string ID = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID")?.ToString(),
                ProjectName = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Name").ToString(),
                ProjectType = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Type") ?.ToString(),
                StartDate = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "StartDate")?.ToString(),
                Amount= gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "AllocatedAmount") ? .ToString(),
                BN = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "BeneficiaryID")?.ToString();

            List<string> labels = new List<string>() { "اسم المشروع","نوع المشروع","تاريخ البداء","المبلغ المخصص له","الجهة المستفيدة"};
            List<string> values = new List<string>() { ProjectName, ProjectType, StartDate, Amount, BN };
            Add_Edit Edit = new Add_Edit("Project",labels,values,ID ,currentUser);    
            Edit.ShowDialog();
            LoadData();
        }
    }
}
