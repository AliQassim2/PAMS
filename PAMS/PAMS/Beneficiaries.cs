using System.Data;

namespace PAMS
{
    public partial class Beneficiaries : UserControl
    {
        public Beneficiaries()
        {
            InitializeComponent();
            dataGridView1.DataSource = DB.LoadData("SELECT * FROM [PAMS].[dbo].[Beneficiaries]");
            LoadData(); // Initial load
        }

        public void LoadData()
        {
            DataTable dt = DB.LoadData("SELECT * FROM [PAMS].[dbo].[Beneficiaries]");
            dataGridView1.DataSource = dt;
            if (dataGridView1.Columns.Contains("id"))
                dataGridView1.Columns["id"].Visible = false;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource != null)
            {
                dataGridView1.CurrentCell = null;
                DataTable dt = (DataTable)dataGridView1.DataSource;
                dt.DefaultView.RowFilter = string.Format("[Name] like '" + textBox1.Text + "%'");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("لم يتم اختيار العنصر المراد حذفه", "لم يتم اختيار العنصر", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string BeneficiariesID = dataGridView1.CurrentRow.Cells["id"].Value.ToString(),
             BeneficiariesName = dataGridView1.CurrentRow.Cells["Name"].Value.ToString();
            DialogResult result = MessageBox.Show($"هل انت متاكد من حذف الجهة المستفيدة  {BeneficiariesName}؟", "تاكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (DB.Execute($"DELETE FROM [Beneficiaries] WHERE id = '{BeneficiariesID}'"))
                    MessageBox.Show("تم الحذف بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> labels = new List<string>() { "اسم الجهة"};
            Add_Edit Add = new Add_Edit("Beneficiaries", labels);
            Add.Icon = new Icon(@"Resources\add.ico");
            Add.Text = "اضافة جهة مستفيدة";
            Add.ShowDialog();
        }
    }
}
