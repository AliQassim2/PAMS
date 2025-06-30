namespace PAMS
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            label_pro_Click(null, EventArgs.Empty);
        }



        private void label_pro_Click(object sender, EventArgs e)
        {
            Title.Text = label_pro.Text;
            projects1.Visible = true;
            beneficiaries1.Visible = executors1.Visible = paymentVouchers1.Visible = receiptVouchers1.Visible = false;
        }


        private void label_exc_Click(object sender, EventArgs e)
        {
            Title.Text = label_exc.Text;
            executors1.Visible = true;
            beneficiaries1.Visible = projects1.Visible = paymentVouchers1.Visible = receiptVouchers1.Visible = false;
        }

        private void label_RV_Click(object sender, EventArgs e)
        {
            Title.Text = label_RV.Text;
            receiptVouchers1.Visible = true;
            beneficiaries1.Visible = executors1.Visible = paymentVouchers1.Visible = projects1.Visible = false;
        }

        private void label_PV_Click(object sender, EventArgs e)
        {
            Title.Text = label_PV.Text;
            paymentVouchers1.Visible = true;
            beneficiaries1.Visible = executors1.Visible = projects1.Visible = receiptVouchers1.Visible = false;
        }

        private void label_ben_Click_1(object sender, EventArgs e)
        {
            Title.Text = label_ben.Text;
            beneficiaries1.Visible = true;
            beneficiaries1.LoadData();
            projects1.Visible = executors1.Visible = paymentVouchers1.Visible = receiptVouchers1.Visible = false;
        }
    }
}
