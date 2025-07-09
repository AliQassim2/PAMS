using System.Data;
using PAMS.Models;
namespace PAMS
{
    public partial class Reports : UserControl
    {
        public Reports()
        {
            InitializeComponent();
            dateTimePicker1.MaxDate = DateTime.Now.AddDays(-1);
            dateTimePicker2.MaxDate = DateTime.Now;
            comboBox1.SelectedIndex = 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell = null;
            DataTable dt = (DataTable)dataGridView1.DataSource;
            dt.DefaultView.RowFilter = string.Format("[Name] like '" + textBox1.Text + "%'");
        }


        private void comboBox1_SelectedIndexChanged(object? sender, EventArgs? e)
        {
            checkBox1.Checked = false;
            checkBox1.Visible = comboBox1.SelectedIndex == 1;
            dataGridView1.DataSource = Report.ReportData(dateTimePicker1.Value.ToString("yyyy-MM-dd"), dateTimePicker2.Value.ToString("yyyy-MM-dd"), comboBox1.SelectedIndex);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
                dataGridView1.DataSource = checkBox1.Checked? 
                Report.ReportData(dateTimePicker1.Value.ToString("yyyy-MM-dd"), dateTimePicker2.Value.ToString("yyyy-MM-dd"), -1):
                Report.ReportData(dateTimePicker1.Value.ToString("yyyy-MM-dd"), dateTimePicker2.Value.ToString("yyyy-MM-dd"), comboBox1.SelectedIndex);
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            comboBox1_SelectedIndexChanged(null, null);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            comboBox1_SelectedIndexChanged(null, null);
        }
    }
}
