using PAMS.environment;
using PAMS.Models;
using System.Data;

namespace PAMS
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();
            string validationMessage = Validation.ValidateMultiple([username,password], ["اسم المستخدم", "كلمة المرور"]);
            UserModel user = new();
            if (validationMessage != string.Empty)
            {
                MessageBox.Show(validationMessage, "خطأ ادخال البيانات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
           
            if (user.Authenticate(username,password))
            {
                this.Hide();
                Main mainForm = new(user);
                mainForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("اسم المستخدم او كلمة المرور غير صحيحة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
