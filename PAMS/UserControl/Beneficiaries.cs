using PAMS.environment;
using PAMS.Models;
using System.Data;
using PAMS.environment;
namespace PAMS
{
    public partial class Beneficiaries : UserControl
    {
        private string currentUser = string.Empty;
        private string usertype = string.Empty;
        public Beneficiaries()
        {
            InitializeComponent();
            LoadDataBen(); // Initial load
        }
        private string CurrentUser;

        public void GetCurrentUser(UserModel user)
        {
            currentUser = user.Id;
            usertype = user.Type;
        }
        public void LoadDataBen()
        {
            using(AppDbContext context = new AppDbContext())
            {
                dataGridView1.DataSource = context.Beneficiaries.ToList();
            }
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["name"].HeaderText = "اسم الجهة المستفيدة";
            if (usertype == "3")
            {
                button1.Visible = button2.Visible = button3.Visible = false;
            }

        }

        public void LoadDataExec()
        {
            DataTable dt = ExecutorModel.GetAllExecutor();
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["name"].HeaderText = "اسم الجهة المنفذة";
            if (usertype == "3")
            {
                button1.Visible = button2.Visible = button3.Visible = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource != null)
            {
                dataGridView1.CurrentCell = null;
                DataTable dt = (DataTable)dataGridView1.DataSource;
                dt.DefaultView.RowFilter = string.Format("[name] like '" + textBox1.Text + "%'");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("لم يتم اختيار العنصر المراد حذفه", "لم يتم اختيار العنصر", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
           
            string Id = dataGridView1.CurrentRow.Cells["id"].Value.ToString(),
             Name = dataGridView1.CurrentRow.Cells["name"].Value.ToString();
            DialogResult result = MessageBox.Show($"هل انت متاكد من حذف الجهة   {Name}؟", "تاكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            { 
                if(checkBox1.Checked)
                {
                    ExecutorModel.DeleteExecutor(Id); LoadDataExec();
                }
                else
                {
                    BeneficiaryModel.DeleteBeneficiary(Id);LoadDataBen();
                }               
                
            }

        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                LoadDataExec();
            }
            else
            {
                LoadDataBen();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                List<string> labels = ["اسم الجهة المنفذة"];
                Add_Edit Add = new("Executors", labels, [], string.Empty, CurrentUser);
                Add.ShowDialog();
                LoadDataExec();
            }
            else
            {
                List<string> labels = ["اسم الجهة المستفيدة"];
                Add_Edit Add = new("Beneficiaries", labels, [], string.Empty, CurrentUser);
                Add.ShowDialog();
                LoadDataBen();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
            string name = dataGridView1.CurrentRow.Cells["Name"].Value.ToString();
            if (checkBox1.Checked)
            {
                List<string> labels = ["اسم الجهة المنفذة"];
                Add_Edit Edit = new("Executors", labels, [name], id, CurrentUser);
                Edit.ShowDialog();
                LoadDataExec();
            }
            else
            {
                List<string> labels = ["اسم الجهة المستفيدة"];
                Add_Edit Edit = new("Beneficiaries", labels, [name], id, CurrentUser);
                Edit.ShowDialog();
                LoadDataBen();
            }
        }
    }
}
