using System.Data;

namespace PAMS
{
    public partial class Executors : UserControl
    {
        public Executors()
        {
            InitializeComponent();
            dataGridView1.DataSource = DB.LoadData("SELECT * FROM [PAMS].[dbo].[Executors]");
            dataGridView1.Columns["id"].Visible = false;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell = null;
            DataTable dt = (DataTable)dataGridView1.DataSource;
            dt.DefaultView.RowFilter = string.Format("[Name] like '" + textBox1.Text + "%'");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> labels = new List<string>() { "اسم الشركة" };
            Add_Edit Add = new Add_Edit("Executors",labels);
            Add.Icon = new Icon(@"Resources\add.ico");
            Add.Text = "اضافة شركة منفذة";
            Add.ShowDialog();
        }
    }
}
