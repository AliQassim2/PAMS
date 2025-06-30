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
        private readonly string ID, Table;
        public Add_Edit(string table, List<string> Labels, List<string>? value = null, string? id = null)
        {
            Table = table;
            InitializeComponent();
            labels.AddRange(label1, label2, label3, label4, label5);
            textBoxes.AddRange(textBox1, textBox2, textBox3, textBox4, textBox5);
            if (value != null && Labels != null)
            {
                if (Labels.Count != value.Count)
                {
                    MessageBox.Show("count labels not equl value !!!!", "error");
                    Environment.Exit(0);
                }
                if (Labels.Count > 5 || value.Count > 5)
                {
                    MessageBox.Show("labels or value is greater then 5 !!!!", "error");
                    Environment.Exit(0);
                }
                ID = id;
                int i = 0;
                while (i < Labels.Count)
                {
                    labels[i].Text = Labels[i];
                    textBoxes[i].Text = value[i];
                    i++;
                }
                while (i < 5)
                {
                    labels[i].Visible = false;
                    textBoxes[i].Visible = false;
                    i++;
                }
                button1.Text = "تعديل";


            }
            else if (Labels != null)
            {

                if (Labels.Count > 5)
                {
                    MessageBox.Show("labels or value is greater then 5 !!!!", "error");
                    Environment.Exit(0);
                }
                int i = 0;
                while (i < Labels.Count)
                {
                    labels[i].Text = Labels[i];
                    i++;
                }
                while (i < 5)
                {
                    labels[i].Visible = false;
                    textBoxes[i].Visible = false;
                    i++;
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(ID == null)
            {
                DB.Execute()
            }
        }
    }
}
