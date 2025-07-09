using Microsoft.Data.SqlClient;
using PAMS.environment;
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
    public partial class Add_Edit : Form
    {
        private readonly List<Label> labels = [];
        private readonly List<TextBox> textBoxes = [];
        private readonly string ID, Table , currentUser;

        public Add_Edit(string table, List<string> Labels, List<string> value , string id = "" , string idUser="")
        {
            Table = table;
            ID = id;
            currentUser=idUser;
            if (Labels.Count > 5 || value.Count > 5)
            {
                MessageBox.Show("labels or value is greater then 5 !!!!", "error");
                this.Close();
            }
            InitializeComponent();

            labels.AddRange(label1, label2, label3, label4, label5);
            textBoxes.AddRange(textBox1, textBox2, textBox3, textBox4, textBox5);
            
            int i = 0;
            while (i < Labels.Count)
                {
                    labels[i].Text = Labels[i];
                    if(i < value.Count)
                        textBoxes[i].Text = value[i];
                    i++;
                }
            while (i < labels.Count)
                {
                    labels[i].Visible = false;
                    textBoxes[i].Visible = false;
                    i++;
                }
            if ( string.IsNullOrEmpty(ID))
            {
                button1.Text = "اضافة";
                this.Text = "اضافة بيانات";
                this.Icon = new Icon(@"Resources\add.ico");

            }
            else             {
                button1.Text = "تعديل";
                this.Text = "تعديل بيانات";
                this.Icon = new Icon(@"Resources\edit.ico");
            }
            switch (Table)
            {
                case "users":
                    Users();
                    if (ID != string.Empty)
                    {
                        comboBox1.SelectedIndex = int.Parse(value[2]);
                        textBox3.Text = string.Empty;
                    }
                    break;
                case "Project":
                    Projects();
                    if(ID != string.Empty)
                    {
                        dateTimePicker1.Value = DateTime.Parse(value[2]);
                        numericUpDown1.Value = decimal.Parse(value[3]);
                        comboBox1.SelectedIndex = int.Parse(value[1]);
                        comboBox2.SelectedValue = value[4];
                    }
                    break;
                case "PaymentVouchers":
                    PaymentVoucher();
                    if (ID != string.Empty)
                    {
                        dateTimePicker1.Value = DateTime.Parse(value[0]);
                        numericUpDown1.Value = decimal.Parse(value[1]);
                        comboBox1.SelectedValue = value[3];
                        comboBox2.SelectedValue = value[4];
                    }
                    break;
                case "ReceiptVouchers":
                    ReceiptVoucher();
                    if (ID != string.Empty)
                    {
                        dateTimePicker1.Value = DateTime.Parse(value[0]);
                        numericUpDown1.Value = decimal.Parse(value[1]);
                        comboBox1.SelectedValue = value[3];
                    }
                    break;
            }          
        }
            
        
        private void Users()
        {
            textBox4.Visible = false;
            comboBox1.Location = textBox4.Location;
            comboBox1.Size = textBox4.Size;
            comboBox1.Items.AddRange(["ادمن", "مسؤول المشاريع", "مسؤول المالي", "مراقب"]);
            comboBox1.SelectedIndex = 0;
            comboBox1.Visible = true;
        }
        private void Projects()
        {
            textBox2.Visible=textBox3.Visible = textBox4.Visible=textBox5.Visible= false;

            comboBox1.Location = textBox2.Location;
            comboBox1.Size = textBox2.Size;
            comboBox1.Items.AddRange(["استثماري", "تنفيذي"]);
            comboBox1.SelectedIndex = 0;
            comboBox1.Visible = true;

            dateTimePicker1.Location = textBox3.Location;
            dateTimePicker1.Size = textBox3.Size;
            dateTimePicker1.Visible = true;

            numericUpDown1.Location = textBox4.Location;
            numericUpDown1.Size = textBox4.Size;
            numericUpDown1.Maximum= decimal.MaxValue;
            numericUpDown1.Visible = true;

            comboBox2.Location = textBox5.Location;
            comboBox2.Size = textBox5.Size;
            comboBox2.DataSource = BeneficiaryModel.GetAllBeneficiaries();
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "ID";
            comboBox2.SelectedIndex = 0;
            comboBox2.Visible = true;

        }
        private void PaymentVoucher()
        {
            textBox1.Visible = textBox2.Visible= textBox4.Visible = textBox5.Visible= false;

            dateTimePicker1.Location = textBox1.Location;
            dateTimePicker1.Size = textBox1.Size;
            dateTimePicker1.Visible = true;

            numericUpDown1.Location = textBox2.Location;
            numericUpDown1.Size = textBox2.Size;
            numericUpDown1.Maximum = decimal.MaxValue;
            numericUpDown1.Visible = true;

            comboBox1.Location = textBox4.Location;
            comboBox1.Size = textBox4.Size;
            comboBox1.DataSource = ProjectModel.GetAllProjects();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";
            comboBox1.SelectedIndex = 0;
            comboBox1.Visible = true;

            comboBox2.Location = textBox5.Location;
            comboBox2.Size = textBox5.Size;
            comboBox2.DataSource = ExecutorModel.GetAllExecutor();
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "ID";
            comboBox2.SelectedIndex = 0;
            comboBox2.Visible = true;
        }
        private void ReceiptVoucher()
        {
            textBox1.Visible = textBox2.Visible = textBox4.Visible = textBox5.Visible = false;

            dateTimePicker1.Location = textBox1.Location;
            dateTimePicker1.Size = textBox1.Size;
            dateTimePicker1.Visible = true;

            numericUpDown1.Location = textBox2.Location;
            numericUpDown1.Size = textBox2.Size;
            numericUpDown1.Maximum = decimal.MaxValue;
            numericUpDown1.Visible = true;

            comboBox1.Location = textBox4.Location;
            comboBox1.Size = textBox4.Size;
            comboBox1.DataSource = ProjectModel.GetAllProjects();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";
            comboBox1.SelectedIndex = 0;
            comboBox1.Visible = true;

            
        }
        private void AddUser()
        {
            string validationMessage = Validation.ValidateMultiple(
                        [textBox1.Text, textBox2.Text, textBox3.Text],
                        ["الاسم", "اسم المستخدم", "كلمة المرور"],
                        1, 50, false, false, true, false);
            if (validationMessage != string.Empty)
            {
                MessageBox.Show(validationMessage, "خطأ ادخال البيانات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (UserModel.AddUser(textBox1.Text, textBox2.Text, textBox3.Text, comboBox1.SelectedIndex.ToString(), currentUser))
            {
                MessageBox.Show("تم اضافة المستخدم بنجاح", "success", MessageBoxButtons.OK, MessageBoxIcon.None);
                this.Close();
            }
        }
        private void EditUser()
        {
            string validationMessage = Validation.ValidateMultiple(
                        [textBox1.Text, textBox2.Text, textBox3.Text],
                        ["الاسم", "اسم المستخدم", "كلمة المرور"],
                        1, 50, false, false, true, false);
            if (validationMessage != string.Empty)
            {
                MessageBox.Show(validationMessage, "خطأ ادخال البيانات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (UserModel.UpdateUser(ID, textBox1.Text, textBox2.Text, textBox3.Text, comboBox1.SelectedIndex.ToString()))
            {
                MessageBox.Show("تم تعديل المستخدم بنجاح", "success", MessageBoxButtons.OK, MessageBoxIcon.None);
                this.Close();
            }
        }
        private void AddProject()
        {
            ProjectModel project = new ProjectModel
            (
                string.Empty,
                textBox1.Text,
                comboBox1.SelectedIndex.ToString(),
                dateTimePicker1.Value.ToString("yyyy-MM-dd"),
                numericUpDown1.Value.ToString(),
                comboBox2.SelectedValue.ToString(),
                currentUser               
            );
            if (project != null) 
            { 
                if (ProjectModel.AddProject(project))
                {
                    MessageBox.Show("تم اضافة المشروع بنجاح", "success", MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                }
                            }
        }
        private void EditProject()
        {
           ProjectModel project = new ProjectModel
            (
                ID,
                textBox1.Text,
                comboBox1.SelectedIndex.ToString(),
                dateTimePicker1.Value.ToString("yyyy-MM-dd"),
                numericUpDown1.Value.ToString(),
                comboBox2.SelectedValue.ToString(),
                currentUser
                );
            if (project != null)
            {
                if (ProjectModel.UpdateProject(project))
                {
                    MessageBox.Show("تم تعديل المشروع بنجاح", "success", MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                }
            }
        }
        private void AddBeneficiary()
        {
            string validationMessage = Validation.Validate(textBox1.Text, "اسم الجهة المستفيدة", 1, 50, false, false, true, false);
            if (validationMessage != string.Empty)
            {
                MessageBox.Show(validationMessage, "خطأ ادخال البيانات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (BeneficiaryModel.AddBeneficiary(textBox1.Text))
            {
                MessageBox.Show("تم اضافة الجهة المستفيدة بنجاح", "success", MessageBoxButtons.OK, MessageBoxIcon.None);
                this.Close();
            }
        }
        private void EditBeneficiary()
        {
            string validationMessage = Validation.Validate(textBox1.Text, "اسم الجهة المستفيدة", 1, 50, false, false, true, false);
            if (validationMessage != string.Empty)
            {
                MessageBox.Show(validationMessage, "خطأ ادخال البيانات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (BeneficiaryModel.UpdateBeneficiary(ID, textBox1.Text))
            {
                MessageBox.Show("تم تعديل الجهة المستفيدة بنجاح", "success", MessageBoxButtons.OK, MessageBoxIcon.None);
                this.Close();
            }
        }
        private void AddExecutor()
        {
            string validationMessage = Validation.Validate(textBox1.Text, "اسم الجهة المنفذة", 1, 50, false, false, true, false);
            if (validationMessage != string.Empty)
            {
                MessageBox.Show(validationMessage, "خطأ ادخال البيانات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (ExecutorModel.AddExecutor(textBox1.Text))
            {
                MessageBox.Show("تم اضافة الجهة المنفذة بنجاح", "success", MessageBoxButtons.OK, MessageBoxIcon.None);
                this.Close();
            }
        }
        private void EditExecutor()
        {
            string validationMessage = Validation.Validate(textBox1.Text, "اسم الجهة المنفذة", 1, 50, false, false, true, false);
            if (validationMessage != string.Empty)
            {
                MessageBox.Show(validationMessage, "خطأ ادخال البيانات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (ExecutorModel.UpdateExecutor(ID, textBox1.Text))
            {
                MessageBox.Show("تم تعديل الجهة المنفذة بنجاح", "success", MessageBoxButtons.OK, MessageBoxIcon.None);
                this.Close();
            }
        }

        private void AddPaymentVouchers()
        {
            string vaildation = Validation.ValidateMultiple([dateTimePicker1.Text, numericUpDown1.Value.ToString()], ["تاريخ الموصل", "المبلغ", "الملاحضات", "المشروع", "الجهة المنفذة"], 1);
            if (vaildation != string.Empty)
            {
                MessageBox.Show(vaildation, "خطأ ادخال البيانات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            PaymentModel payment = new PaymentModel
            (
                string.Empty,
                dateTimePicker1.Value.ToString("yyyy-MM-dd"),
                numericUpDown1.Value.ToString(),
                textBox3.Text,
                comboBox1.SelectedValue.ToString(),
                comboBox2.SelectedValue.ToString()
            );
            if (PaymentModel.AddPayment(payment))
            {
                MessageBox.Show("تم اضافة قسيمة الدفع بنجاح", "success", MessageBoxButtons.OK, MessageBoxIcon.None);
                this.Close();
            }
        }
        private void EditPaymentVouchers()
        {
            string vaildation = Validation.ValidateMultiple([dateTimePicker1.Text, numericUpDown1.Value.ToString()], ["تاريخ الموصل", "المبلغ", "الملاحضات", "المشروع", "الجهة المنفذة"], 1);
            if (vaildation != string.Empty)
            {
                MessageBox.Show(vaildation, "خطأ ادخال البيانات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            PaymentModel payment = new PaymentModel
            (
                ID,
                dateTimePicker1.Value.ToString("yyyy-MM-dd"),
                numericUpDown1.Value.ToString(),
                textBox3.Text,
                comboBox1.SelectedValue.ToString(),
                comboBox2.SelectedValue.ToString()
            );
            if (PaymentModel.UpdatePayment(payment))
            {
                MessageBox.Show("تم تعديل قسيمة الدفع بنجاح", "success", MessageBoxButtons.OK, MessageBoxIcon.None);
                this.Close();
            }
        }
        private void AddReceiptVouchers()
        {
            string vaildation = Validation.ValidateMultiple([dateTimePicker1.Text, numericUpDown1.Value.ToString()], ["تاريخ الموصل", "المبلغ", "الملاحضات", "المشروع"], 1);
            if (vaildation != string.Empty)
            {
                MessageBox.Show(vaildation, "خطأ ادخال البيانات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ReceiptModel receipt = new ReceiptModel
            (
                string.Empty,
                dateTimePicker1.Value.ToString("yyyy-MM-dd"),
                numericUpDown1.Value.ToString(),
                textBox3.Text,
                comboBox1.SelectedValue.ToString()
            );
            if (ReceiptModel.AddReceipt(receipt))
            {
                MessageBox.Show("تم اضافة قسيمة الاستلام بنجاح", "success", MessageBoxButtons.OK, MessageBoxIcon.None);
                this.Close();
            }
        }

        private void EditReceiptVouchers()
        {
            string vaildation = Validation.ValidateMultiple([dateTimePicker1.Text, numericUpDown1.Value.ToString()], ["تاريخ الموصل", "المبلغ", "الملاحضات", "المشروع"], 1);
            if (vaildation != string.Empty)
            {
                MessageBox.Show(vaildation, "خطأ ادخال البيانات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ReceiptModel receipt = new ReceiptModel
            (
                ID,
                dateTimePicker1.Value.ToString("yyyy-MM-dd"),
                numericUpDown1.Value.ToString(),
                textBox3.Text,
                comboBox1.SelectedValue.ToString()
            );
            if (ReceiptModel.UpdateReceipt(receipt))
            {
                MessageBox.Show("تم تعديل قسيمة الاستلام بنجاح", "success", MessageBoxButtons.OK, MessageBoxIcon.None);
                this.Close();
            }
        }   

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ID))
            {
                switch (Table)
                {
                    case "users":
                        AddUser();
                        break;
                    case "Project":
                        AddProject();
                        break;
                    case "Beneficiaries":
                        AddBeneficiary();
                        break;
                    case "Executors":
                        AddExecutor();
                        break;
                    case "PaymentVouchers":
                            AddPaymentVouchers();
                        break;
                    case "ReceiptVouchers":
                        AddReceiptVouchers();
                        break;
                    default:
                        MessageBox.Show("Unknown table type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            else
            {
                switch (Table)
                {
                    case "users":
                        EditUser();
                        break;
                    case "Project":
                        EditProject();
                        break;
                    case "Beneficiaries":
                            EditBeneficiary();
                            break;
                    case "Executors":
                            EditExecutor();
                            break;
                    case "PaymentVouchers":
                            EditPaymentVouchers();
                        break;
                    case "ReceiptVouchers":
                        EditReceiptVouchers();
                        break;
                    default:
                        MessageBox.Show("Unknown table type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
        }
    }
}
