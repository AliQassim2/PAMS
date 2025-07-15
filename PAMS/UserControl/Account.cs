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
            gridControl1.DataSource = UserModel.GetAllUsers(currentUser,"[ID]\r\n      ,[Name]\r\n      ,[Username]\r\n          ,[UserType]\r\n      ,[Created_at]\r\n      ,[who_added]\r\n      ,[WhoAddedType],Type");
            gridView1.Columns["ID"].Visible = false;
            gridView1.Columns["Type"].Visible = false;
            gridView1.Columns["Name"].Caption="الاسم";
            gridView1.Columns["Username"].Caption = "اسم المستخدم";
            gridView1.Columns["UserType"].Caption = "نوع المستخدم";
            gridView1.Columns["Created_at"].Caption = "تاريخ الانشاء";
            gridView1.Columns["who_added"].Caption = "من قام بالاضافة";
            gridView1.Columns["WhoAddedType"].Caption = "نوع من قام بالاضافة";
            gridView1.Columns["UserType"].Width =  gridView1.Columns["Created_at"].Width = gridView1.Columns["who_added"].Width = gridView1.Columns["WhoAddedType"].Width = gridView1.Columns["Name"].Width =  gridView1.Columns["Username"].Width = 150;
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
            if (gridView1.FocusedRowHandle < 0)
            {
                MessageBox.Show("الرجاء تحديد صف واحد على الأقل للتعديل.", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string name= gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Name").ToString();
            string username = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Username").ToString();
            string type = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Type").ToString();
            string id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString();
            Add_Edit edit = new("users", ["الاسم", "اسم المستخدم", "كلمة المرور", "نوع المستخدم"], [name,username,type],id, currentUser);
            edit.ShowDialog();
            LoadData();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0)
            {
                MessageBox.Show("الرجاء تحديد صف واحد على الأقل للحذف.", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString();

            string name = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Name").ToString();

            DialogResult result = MessageBox.Show($":هل أنت متأكد أنك تريد حذف هذا المستخدم{name}؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                UserModel.DeleteUser(id);
                LoadData();
            }
            
        }
    }
}
