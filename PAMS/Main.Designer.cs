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
            labelacc = new Label();
            Title = new Label();
            label_report = new Label();
            label_RV = new Label();
            label_ben_ex = new Label();
            label_PV = new Label();
            label_pro = new Label();
            beneficiaries1 = new Beneficiaries();
            Payment = new PaymentVouchers();
            Report = new Reports();
            projects1 = new Projects();
            receiptVouchers1 = new ReceiptVouchers();
            account1 = new Account();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Control;
            panel1.Controls.Add(labelacc);
            panel1.Controls.Add(Title);
            panel1.Controls.Add(label_report);
            panel1.Controls.Add(label_RV);
            panel1.Controls.Add(label_ben_ex);
            panel1.Controls.Add(label_PV);
            panel1.Controls.Add(label_pro);
            panel1.Location = new Point(1022, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(350, 810);
            panel1.TabIndex = 0;
            // 
            // labelacc
            // 
            labelacc.Anchor = AnchorStyles.None;
            labelacc.BackColor = SystemColors.ActiveCaption;
            labelacc.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelacc.Location = new Point(19, 695);
            labelacc.Name = "labelacc";
            labelacc.RightToLeft = RightToLeft.Yes;
            labelacc.Size = new Size(313, 89);
            labelacc.TabIndex = 7;
            labelacc.Text = "الحسابات";
            labelacc.TextAlign = ContentAlignment.MiddleCenter;
            labelacc.Click += labelacc_Click;
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
            // label_report
            // 
            label_report.Anchor = AnchorStyles.None;
            label_report.BackColor = SystemColors.ActiveCaption;
            label_report.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_report.Location = new Point(19, 577);
            label_report.Name = "label_report";
            label_report.RightToLeft = RightToLeft.Yes;
            label_report.Size = new Size(313, 89);
            label_report.TabIndex = 4;
            label_report.Text = "التقرير";
            label_report.TextAlign = ContentAlignment.MiddleCenter;
            label_report.Click += label_report_Click;
            // 
            // label_RV
            // 
            label_RV.BackColor = SystemColors.ActiveCaption;
            label_RV.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_RV.Location = new Point(19, 464);
            label_RV.Name = "label_RV";
            label_RV.Size = new Size(313, 89);
            label_RV.TabIndex = 3;
            label_RV.Text = "سندات القبض";
            label_RV.TextAlign = ContentAlignment.MiddleCenter;
            label_RV.Click += label_RV_Click;
            // 
            // label_ben_ex
            // 
            label_ben_ex.BackColor = SystemColors.ActiveCaption;
            label_ben_ex.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_ben_ex.Location = new Point(19, 232);
            label_ben_ex.Name = "label_ben_ex";
            label_ben_ex.Size = new Size(313, 89);
            label_ben_ex.TabIndex = 2;
            label_ben_ex.Text = "الجهات المستفيدة و منفذة";
            label_ben_ex.TextAlign = ContentAlignment.MiddleCenter;
            label_ben_ex.Click += label_ben_Click_1;
            // 
            // label_PV
            // 
            label_PV.BackColor = SystemColors.ActiveCaption;
            label_PV.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_PV.Location = new Point(19, 348);
            label_PV.Name = "label_PV";
            label_PV.Size = new Size(313, 89);
            label_PV.TabIndex = 1;
            label_PV.Text = "سندات الصرف";
            label_PV.TextAlign = ContentAlignment.MiddleCenter;
            label_PV.Click += label_PV_Click;
            // 
            // label_pro
            // 
            label_pro.BackColor = SystemColors.ActiveCaption;
            label_pro.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_pro.Location = new Point(19, 120);
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
            // Payment
            // 
            Payment.Location = new Point(-3, 3);
            Payment.Name = "Payment";
            Payment.Size = new Size(1004, 810);
            Payment.TabIndex = 2;
            // 
            // Report
            // 
            Report.Location = new Point(-3, 3);
            Report.Name = "Report";
            Report.Size = new Size(1019, 810);
            Report.TabIndex = 3;
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
            // account1
            // 
            account1.Location = new Point(-3, 3);
            account1.Name = "account1";
            account1.Size = new Size(1019, 810);
            account1.TabIndex = 8;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1374, 814);
            Controls.Add(account1);
            Controls.Add(receiptVouchers1);
            Controls.Add(projects1);
            Controls.Add(Report);
            Controls.Add(Payment);
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
        private Label label_report;
        private Label label_RV;
        private Label label_ben_ex;
        private Label label_PV;
        private Label label_pro;
        private Projects userControl11;
        private Beneficiaries beneficiaries1;
        private PaymentVouchers Payment;
        private Reports Report;
        private Projects projects1;
        private ReceiptVouchers receiptVouchers1;
        private Label Title;
        private Label labelacc;
        private Account account1;
    }
}
