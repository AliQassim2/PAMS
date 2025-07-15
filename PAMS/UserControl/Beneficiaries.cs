using PAMS.environment;
using PAMS.Models;
using System.Data;
using System.Windows.Forms;
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
                gridControl1.DataSource = context.Beneficiaries.ToList();
            }
            gridView1.Columns["id"].Visible = false;
            gridView1.Columns["Name"].Caption = "اسم الجهة المستفيدة";
            if (usertype == "3")
            {
                button1.Visible = button2.Visible = button3.Visible = false;
            }

        }

        public void LoadDataExec()
        {
            DataTable dt = ExecutorModel.GetAllExecutor();
            gridControl1.DataSource = dt;
            gridView1.Columns["id"].Visible = false;
            gridView1.Columns["Name"].Caption = "اسم الجهة المنفذة";
            if (usertype == "3")
            {
                button1.Visible = button2.Visible = button3.Visible = false;
            }
        }

      

        private void button3_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0)
            {
                MessageBox.Show("لم يتم اختيار العنصر المراد حذفه", "لم يتم اختيار العنصر", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
           
            string Id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id")?.ToString(),
             Name = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "name")?.ToString();
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
            string id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id")?.ToString(),
             name = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "name")?.ToString();
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
