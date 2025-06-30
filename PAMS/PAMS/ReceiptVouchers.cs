using System.Data;

namespace PAMS
{
    public partial class ReceiptVouchers : UserControl
    {
        public ReceiptVouchers()
        {
            InitializeComponent();
            dataGridView1.DataSource = DB.LoadData("SELECT r.*,p.name as 'Project Name' FROM [PAMS].[dbo].[ReceiptVouchers] as r inner join Project as p on r.ProjectID = p.id");
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["ProjectID"].Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell = null;
            DataTable dt = (DataTable)dataGridView1.DataSource;
            dt.DefaultView.RowFilter = string.Format("[Project Name] like '" + textBox1.Text + "%'");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> labels = new List<string>() { "تاريخ الموصل", "المبلغ", "الملاحضات", "المشروع"};
            Add_Edit Add = new Add_Edit("ReceiptVouchers",labels);
            Add.Icon = new Icon(@"Resources\add.ico");
            Add.Text = "اضافة مشروع";
            Add.ShowDialog();
        }
    }
}
