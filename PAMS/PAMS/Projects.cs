using System.Data;

namespace PAMS
{
    public partial class Projects : UserControl
    {
        private static string ProjectID = string.Empty, BeneficiarieID = string.Empty;
        public Projects()
        {
            InitializeComponent();
            dataGridView1.DataSource = DB.LoadData("select * from [Projects]");
            dataGridView1.Columns["Beneficiarie ID"].Visible = false;
            dataGridView1.Columns["Project ID"].Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell = null;
            DataTable dt = (DataTable)dataGridView1.DataSource;
            dt.DefaultView.RowFilter = string.Format("[Project Name] like '" + textBox1.Text + "%'");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("لم يتم اختيار العنصر المراد حذفه", "لم يتم اختيار العنصر", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            string projectName = dataGridView1.CurrentRow.Cells["Project Name"].Value.ToString();
            string projectId = dataGridView1.CurrentRow.Cells["Project ID"].Value.ToString();


            DialogResult result = MessageBox.Show($"هل انت متاكد من حذف المشروع {projectName}؟", "تاكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (DB.Execute($"DELETE FROM Project WHERE id = '{projectId}'"))
                    MessageBox.Show("تم الحذف بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            List<string> labels = new List<string>() { "اسم المشروع", "نوع المشروع", "تاريخ البداء", "المبلغ المخصص له", "الجهة المستفيدة" };
            Add_Edit Add = new Add_Edit( "Project",labels);
            Add.Icon = new Icon(@"Resources\add.ico");
            Add.Text = "اضافة مشروع";
            Add.ShowDialog();

        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) { 
                MessageBox.Show("يرجى اختيار مشروع المراد تعديله","خطا في اختيار",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string ID = dataGridView1.CurrentRow.Cells["Project ID"].Value.ToString(),
                ProjectName = dataGridView1.CurrentRow.Cells["Project Name"].Value.ToString(),
                ProjectType = dataGridView1.CurrentRow.Cells["Project Type"].Value.ToString(),
                StartDate = dataGridView1.CurrentRow.Cells["Project Start Date"].Value.ToString(),
                Amount= dataGridView1.CurrentRow.Cells["AllocatedAmount"].Value.ToString(),
                BN = dataGridView1.CurrentRow.Cells["Beneficiarie Name"].Value.ToString();

            List<string> labels = new List<string>() { "اسم المشروع","نوع المشروع","تاريخ البداء","المبلغ المخصص له","الجهة المستفيدة"};
            List<string> values = new List<string>() { ProjectName, ProjectType, StartDate, Amount, BN };
            Add_Edit Edit = new Add_Edit("Project",labels,values,ID );
            Edit.Icon = new Icon(@"Resources\edit.ico");
            Edit.Text = "تعديل مشروع";
            Edit.ShowDialog();

        }
    }
}
