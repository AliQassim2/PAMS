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
            dataGridView1.DataSource = ProjectModel.GetAllProjects();
            dataGridView1.Columns["BeneficiaryID"].Visible =dataGridView1.Columns["add_by"].Visible = dataGridView1.Columns["ID"].Visible = dataGridView1.Columns["Type"].Visible = false;
            dataGridView1.Columns["Name"].HeaderText = "اسم المشروع";
            dataGridView1.Columns["TypeName"].HeaderText = "نوع المشروع";
            dataGridView1.Columns["StartDate"].HeaderText = "تاريخ البدء";
            dataGridView1.Columns["AllocatedAmount"].HeaderText = "المبلغ المخصص";
            dataGridView1.Columns["BeneficiarieName"].HeaderText = "اسم الجهة المستفيدة";
            dataGridView1.Columns["UsernameAdded"].HeaderText = "اسم المستخدم الذي قام بالاضافة";
            dataGridView1.Columns["CreatedAt"].HeaderText = "تاريخ الاضافة";
            dataGridView1.Columns["BeneficiarieName"].Width = dataGridView1.Columns["Type"].Width = dataGridView1.Columns["StartDate"].Width = dataGridView1.Columns["AllocatedAmount"].Width = dataGridView1.Columns["UsernameAdded"].Width = dataGridView1.Columns["CreatedAt"].Width = 150;
            if (usertype == "3")
            {
                buttonAdd.Visible = buttonEdit.Visible = buttonDelete.Visible = false;
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
            dt.DefaultView.RowFilter = string.Format("[Name] like '" + textBox1.Text + "%'");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("لم يتم اختيار العنصر المراد حذفه", "لم يتم اختيار العنصر", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string projectName = dataGridView1.CurrentRow.Cells["Name"].Value.ToString();
            string projectId = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();


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

            if (dataGridView1.CurrentRow == null) { 
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
            string ID = dataGridView1.CurrentRow.Cells["ID"].Value.ToString(),
                ProjectName = dataGridView1.CurrentRow.Cells["Name"].Value.ToString(),
                ProjectType = dataGridView1.CurrentRow.Cells["Type"].Value.ToString(),
                StartDate = dataGridView1.CurrentRow.Cells["StartDate"].Value.ToString(),
                Amount= dataGridView1.CurrentRow.Cells["AllocatedAmount"].Value.ToString(),
                BN = dataGridView1.CurrentRow.Cells["BeneficiaryID"].Value.ToString();

            List<string> labels = new List<string>() { "اسم المشروع","نوع المشروع","تاريخ البداء","المبلغ المخصص له","الجهة المستفيدة"};
            List<string> values = new List<string>() { ProjectName, ProjectType, StartDate, Amount, BN };
            Add_Edit Edit = new Add_Edit("Project",labels,values,ID ,currentUser);    
            Edit.ShowDialog();
            LoadData();
        }
    }
}
