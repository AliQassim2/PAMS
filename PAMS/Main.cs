using PAMS.Models;

namespace PAMS
{
    public partial class Main : Form
    {
        private readonly UserModel CurrnetUser;

        public Main(UserModel User)
        {
            InitializeComponent();
            CurrnetUser = User;
            Title.Text = $"مرحبا {this.CurrnetUser.Name}";
           switch (CurrnetUser.Type)
            {
                case "0":
                    label_pro_Click(null, null);
                    break;
                case "1":
                    label_pro.Visible = true;
                    label_ben_ex.Visible = label_RV.Visible = labelacc.Visible = label_report.Visible=label_PV.Visible = false;
                    label_pro_Click(null, null);
                    break;
                case "2":
                    label_RV.Visible = label_PV.Visible = true;
                    label_ben_ex.Visible = label_pro.Visible = labelacc.Visible = label_report.Visible =  false;
                    label_RV.Location=label_pro.Location;
                    label_PV.Location =label_ben_ex.Location;
                    label_RV_Click(null, null);
                    break;
                case "3":
                    label_pro_Click(null, null);
                    break;
                default:
                    MessageBox.Show("نوع المستخدم غير معروف.");
                    return;
                    break;
            }
        }



        private void label_pro_Click(object? sender, EventArgs? e)
        {
            projects1.GetCurrentUser(CurrnetUser);
            projects1.LoadData();
            projects1.Visible = true;
            beneficiaries1.Visible = Payment.Visible = Report.Visible = receiptVouchers1.Visible = account1.Visible = false;
        }



        private void label_RV_Click(object sender, EventArgs e)
        {
            receiptVouchers1.GetCurrentUser(CurrnetUser);
            receiptVouchers1.LoadData();
            receiptVouchers1.Visible = true;
            beneficiaries1.Visible = Payment.Visible = Report.Visible = projects1.Visible = account1.Visible = false;
        }



        private void label_ben_Click_1(object sender, EventArgs e)
        {
            beneficiaries1.GetCurrentUser(CurrnetUser);
            beneficiaries1.LoadDataBen();
            beneficiaries1.Visible = true;
            projects1.Visible = Payment.Visible = Report.Visible = receiptVouchers1.Visible = account1.Visible = false;
        }



        private void labelacc_Click(object sender, EventArgs e)
        {
            account1.GetCurrentUser(CurrnetUser);
            account1.LoadData();
            account1.Visible = true;
            projects1.Visible = Payment.Visible = Report.Visible = receiptVouchers1.Visible = beneficiaries1.Visible = false;
        }

        private void label_report_Click(object sender, EventArgs e)
        {
           
            Report.Visible = true;
            beneficiaries1.Visible = Payment.Visible = projects1.Visible = receiptVouchers1.Visible = account1.Visible = false;
        }

        private void label_PV_Click(object sender, EventArgs e)
        {
            Payment.GetCurrentUser(CurrnetUser);
            Payment.LoadData();
            Payment.Visible = true;
            beneficiaries1.Visible = projects1.Visible = Report.Visible = receiptVouchers1.Visible = account1.Visible = false;
        }
    }
}
