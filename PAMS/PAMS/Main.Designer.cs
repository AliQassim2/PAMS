namespace PAMS
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            Title = new Label();
            label_PV = new Label();
            label_RV = new Label();
            label_ben = new Label();
            label_exc = new Label();
            label_pro = new Label();
            beneficiaries1 = new Beneficiaries();
            executors1 = new Executors();
            paymentVouchers1 = new PaymentVouchers();
            projects1 = new Projects();
            receiptVouchers1 = new ReceiptVouchers();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Control;
            panel1.Controls.Add(Title);
            panel1.Controls.Add(label_PV);
            panel1.Controls.Add(label_RV);
            panel1.Controls.Add(label_ben);
            panel1.Controls.Add(label_exc);
            panel1.Controls.Add(label_pro);
            panel1.Location = new Point(1022, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(350, 810);
            panel1.TabIndex = 0;
            // 
            // Title
            // 
            Title.Font = new Font("Times New Roman", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Title.Location = new Point(66, 32);
            Title.Name = "Title";
            Title.RightToLeft = RightToLeft.Yes;
            Title.Size = new Size(247, 64);
            Title.TabIndex = 5;
            Title.Text = "المشاريع";
            Title.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_PV
            // 
            label_PV.Anchor = AnchorStyles.None;
            label_PV.BackColor = SystemColors.ActiveCaption;
            label_PV.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_PV.Location = new Point(19, 699);
            label_PV.Name = "label_PV";
            label_PV.RightToLeft = RightToLeft.Yes;
            label_PV.Size = new Size(313, 89);
            label_PV.TabIndex = 4;
            label_PV.Text = "سندات الصرف";
            label_PV.TextAlign = ContentAlignment.MiddleCenter;
            label_PV.Click += label_PV_Click;
            // 
            // label_RV
            // 
            label_RV.BackColor = SystemColors.ActiveCaption;
            label_RV.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_RV.Location = new Point(19, 558);
            label_RV.Name = "label_RV";
            label_RV.Size = new Size(313, 89);
            label_RV.TabIndex = 3;
            label_RV.Text = "سندات القبض";
            label_RV.TextAlign = ContentAlignment.MiddleCenter;
            label_RV.Click += label_RV_Click;
            // 
            // label_ben
            // 
            label_ben.BackColor = SystemColors.ActiveCaption;
            label_ben.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_ben.Location = new Point(19, 285);
            label_ben.Name = "label_ben";
            label_ben.Size = new Size(313, 89);
            label_ben.TabIndex = 2;
            label_ben.Text = "الجهات المستفيدة ";
            label_ben.TextAlign = ContentAlignment.MiddleCenter;
            label_ben.Click += label_ben_Click_1;
            // 
            // label_exc
            // 
            label_exc.BackColor = SystemColors.ActiveCaption;
            label_exc.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_exc.Location = new Point(19, 423);
            label_exc.Name = "label_exc";
            label_exc.Size = new Size(313, 89);
            label_exc.TabIndex = 1;
            label_exc.Text = "الجهة المنفذة ";
            label_exc.TextAlign = ContentAlignment.MiddleCenter;
            label_exc.Click += label_exc_Click;
            // 
            // label_pro
            // 
            label_pro.BackColor = SystemColors.ActiveCaption;
            label_pro.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_pro.Location = new Point(19, 156);
            label_pro.Name = "label_pro";
            label_pro.Size = new Size(313, 89);
            label_pro.TabIndex = 0;
            label_pro.Text = "المشاريع";
            label_pro.TextAlign = ContentAlignment.MiddleCenter;
            label_pro.Click += label_pro_Click;
            // 
            // beneficiaries1
            // 
            beneficiaries1.Location = new Point(-3, 3);
            beneficiaries1.Name = "beneficiaries1";
            beneficiaries1.Size = new Size(1019, 810);
            beneficiaries1.TabIndex = 1;
            // 
            // executors1
            // 
            executors1.Location = new Point(-3, 3);
            executors1.Name = "executors1";
            executors1.Size = new Size(1004, 810);
            executors1.TabIndex = 2;
            // 
            // paymentVouchers1
            // 
            paymentVouchers1.Location = new Point(-3, 3);
            paymentVouchers1.Name = "paymentVouchers1";
            paymentVouchers1.Size = new Size(1019, 810);
            paymentVouchers1.TabIndex = 3;
            // 
            // projects1
            // 
            projects1.Location = new Point(-3, 3);
            projects1.Name = "projects1";
            projects1.Size = new Size(1019, 810);
            projects1.TabIndex = 4;
            // 
            // receiptVouchers1
            // 
            receiptVouchers1.Location = new Point(-3, 3);
            receiptVouchers1.Name = "receiptVouchers1";
            receiptVouchers1.Size = new Size(1019, 810);
            receiptVouchers1.TabIndex = 5;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1374, 814);
            Controls.Add(receiptVouchers1);
            Controls.Add(projects1);
            Controls.Add(paymentVouchers1);
            Controls.Add(executors1);
            Controls.Add(beneficiaries1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "Main";
            Text = "PAMS";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label_PV;
        private Label label_RV;
        private Label label_ben;
        private Label label_exc;
        private Label label_pro;
        private Projects userControl11;
        private Beneficiaries beneficiaries1;
        private Executors executors1;
        private PaymentVouchers paymentVouchers1;
        private Projects projects1;
        private ReceiptVouchers receiptVouchers1;
        private Label Title;
    }
}
