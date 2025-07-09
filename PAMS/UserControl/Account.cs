using PAMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAMS
{
    public partial class Account : UserControl
    {
        private string currentUser = string.Empty;
        private string usertype = string.Empty;
        public Account()
        {
            InitializeComponent();

        }
        public void LoadData()
        {
            dataGridView1.DataSource = UserModel.GetAllUsers(currentUser,"[ID]\r\n      ,[Name]\r\n      ,[Username]\r\n          ,[UserType]\r\n      ,[Created_at]\r\n      ,[who_added]\r\n      ,[WhoAddedType],Type");
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["Type"].Visible = false;
            dataGridView1.Columns["Name"].HeaderText="الاسم";
            dataGridView1.Columns["Username"].HeaderText = "اسم المستخدم";
            dataGridView1.Columns["UserType"].HeaderText = "نوع المستخدم";
            dataGridView1.Columns["Created_at"].HeaderText = "تاريخ الانشاء";
            dataGridView1.Columns["who_added"].HeaderText = "من قام بالاضافة";
            dataGridView1.Columns["WhoAddedType"].HeaderText = "نوع من قام بالاضافة";
            dataGridView1.Columns["UserType"].Width =  dataGridView1.Columns["Created_at"].Width = dataGridView1.Columns["who_added"].Width = dataGridView1.Columns["WhoAddedType"].Width = dataGridView1.Columns["Name"].Width =  dataGridView1.Columns["Username"].Width = 150;
            if (usertype == "3")
            {
                buttonAdd.Visible = buttonEdit.Visible = buttonDelete.Visible = false;
            }
        }
        public void GetCurrentUser(UserModel user)
        {
            currentUser = user.Id;
            usertype = user.Type;
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Add_Edit add = new("users", ["الاسم", "اسم المستخدم", "كلمة المرور", "نوع المستخدم"], [],string.Empty,currentUser);

            add.ShowDialog();
            LoadData();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("الرجاء تحديد صف واحد على الأقل للتعديل.", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string name= dataGridView1.CurrentRow.Cells["Name"].Value.ToString();
            string username = dataGridView1.CurrentRow.Cells["Username"].Value.ToString();
            string type = dataGridView1.CurrentRow.Cells["Type"].Value.ToString();
            string id = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            Add_Edit edit = new("users", ["الاسم", "اسم المستخدم", "كلمة المرور", "نوع المستخدم"], [name,username,type],id, currentUser);
            edit.ShowDialog();
            LoadData();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("الرجاء تحديد صف واحد على الأقل للحذف.", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult result = MessageBox.Show($":هل أنت متأكد أنك تريد حذف هذا المستخدم{dataGridView1.CurrentRow.Cells["Name"].Value.ToString()}؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                UserModel.DeleteUser(dataGridView1.CurrentRow.Cells["ID"].Value.ToString());
                LoadData();
            }
            
        }
    }
}
