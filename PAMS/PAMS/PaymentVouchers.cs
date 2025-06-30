using System.Data;

namespace PAMS
{
    public partial class PaymentVouchers : UserControl
    {
        public PaymentVouchers()
        {
            InitializeComponent();
            dataGridView1.DataSource = DB.LoadData("SELECT pv.*,p.name as 'Project Name',e.name as 'Executor Name' FROM PaymentVouchers as pv inner join Project as p on pv.ProjectID = p.id inner join Executors e on pv.ExecutorID=e.id");
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["ProjectID"].Visible = false;
            dataGridView1.Columns["ExecutorID"].Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell = null;
            DataTable dt = (DataTable)dataGridView1.DataSource;
            dt.DefaultView.RowFilter = string.Format("[Project Name] like '" + textBox1.Text + "%' OR [Executor Name] like '" + textBox1.Text + "%'");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> labels = new List<string>() { "تاريخ الموصل", "المبلغ", "الملاحضات", "المشروع", "الجهة المنفذة" };
            Add_Edit Add = new Add_Edit("PaymentVouchers", labels);
            Add.Icon = new Icon(@"Resources\add.ico");
            Add.Text = "اضافة سند صرف";
            Add.ShowDialog();
        }
    }
}
