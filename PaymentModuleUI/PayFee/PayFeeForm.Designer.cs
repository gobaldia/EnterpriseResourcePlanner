namespace PaymentModuleUI.PayFee
{
    partial class PayFeeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelAddStudentTitle = new System.Windows.Forms.Label();
            this.comboBoxStudentNumbers = new System.Windows.Forms.ComboBox();
            this.labelStudentNumbers = new System.Windows.Forms.Label();
            this.checkedListBoxNotPaidFees = new System.Windows.Forms.CheckedListBox();
            this.labelStudentFullName = new System.Windows.Forms.Label();
            this.labelDocumentNumber = new System.Windows.Forms.Label();
            this.textBoxDocumentNumber = new System.Windows.Forms.TextBox();
            this.textBoxFullName = new System.Windows.Forms.TextBox();
            this.buttonPay = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelSuccess = new System.Windows.Forms.Label();
            this.labelError = new System.Windows.Forms.Label();
            this.checkedListBoxPaidFees = new System.Windows.Forms.CheckedListBox();
            this.labelNoPaidFees = new System.Windows.Forms.Label();
            this.labelPaidFees = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelAddStudentTitle
            // 
            this.labelAddStudentTitle.AutoSize = true;
            this.labelAddStudentTitle.Font = new System.Drawing.Font("Verdana", 14.1F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAddStudentTitle.Location = new System.Drawing.Point(107, 84);
            this.labelAddStudentTitle.Name = "labelAddStudentTitle";
            this.labelAddStudentTitle.Size = new System.Drawing.Size(444, 59);
            this.labelAddStudentTitle.TabIndex = 37;
            this.labelAddStudentTitle.Text = "Pay Student Fees";
            // 
            // comboBoxStudentNumbers
            // 
            this.comboBoxStudentNumbers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStudentNumbers.FormattingEnabled = true;
            this.comboBoxStudentNumbers.Location = new System.Drawing.Point(509, 237);
            this.comboBoxStudentNumbers.Name = "comboBoxStudentNumbers";
            this.comboBoxStudentNumbers.Size = new System.Drawing.Size(309, 39);
            this.comboBoxStudentNumbers.TabIndex = 38;
            this.comboBoxStudentNumbers.SelectedIndexChanged += new System.EventHandler(this.OnStudentNumber_SelectedIndexChange);
            // 
            // labelStudentNumbers
            // 
            this.labelStudentNumbers.AutoSize = true;
            this.labelStudentNumbers.Location = new System.Drawing.Point(244, 244);
            this.labelStudentNumbers.Name = "labelStudentNumbers";
            this.labelStudentNumbers.Size = new System.Drawing.Size(239, 32);
            this.labelStudentNumbers.TabIndex = 39;
            this.labelStudentNumbers.Text = "Student numbers:";
            // 
            // checkedListBoxNotPaidFees
            // 
            this.checkedListBoxNotPaidFees.CheckOnClick = true;
            this.checkedListBoxNotPaidFees.FormattingEnabled = true;
            this.checkedListBoxNotPaidFees.Location = new System.Drawing.Point(509, 500);
            this.checkedListBoxNotPaidFees.Name = "checkedListBoxNotPaidFees";
            this.checkedListBoxNotPaidFees.Size = new System.Drawing.Size(995, 235);
            this.checkedListBoxNotPaidFees.TabIndex = 40;
            // 
            // labelStudentFullName
            // 
            this.labelStudentFullName.AutoSize = true;
            this.labelStudentFullName.Location = new System.Drawing.Point(335, 397);
            this.labelStudentFullName.Name = "labelStudentFullName";
            this.labelStudentFullName.Size = new System.Drawing.Size(148, 32);
            this.labelStudentFullName.TabIndex = 41;
            this.labelStudentFullName.Text = "Full name:";
            // 
            // labelDocumentNumber
            // 
            this.labelDocumentNumber.AutoSize = true;
            this.labelDocumentNumber.Location = new System.Drawing.Point(228, 329);
            this.labelDocumentNumber.Name = "labelDocumentNumber";
            this.labelDocumentNumber.Size = new System.Drawing.Size(255, 32);
            this.labelDocumentNumber.TabIndex = 42;
            this.labelDocumentNumber.Text = "Document number:";
            // 
            // textBoxDocumentNumber
            // 
            this.textBoxDocumentNumber.Enabled = false;
            this.textBoxDocumentNumber.Location = new System.Drawing.Point(509, 323);
            this.textBoxDocumentNumber.Name = "textBoxDocumentNumber";
            this.textBoxDocumentNumber.Size = new System.Drawing.Size(510, 38);
            this.textBoxDocumentNumber.TabIndex = 43;
            // 
            // textBoxFullName
            // 
            this.textBoxFullName.Enabled = false;
            this.textBoxFullName.Location = new System.Drawing.Point(509, 391);
            this.textBoxFullName.Name = "textBoxFullName";
            this.textBoxFullName.Size = new System.Drawing.Size(510, 38);
            this.textBoxFullName.TabIndex = 44;
            // 
            // buttonPay
            // 
            this.buttonPay.Location = new System.Drawing.Point(1239, 1054);
            this.buttonPay.Name = "buttonPay";
            this.buttonPay.Size = new System.Drawing.Size(265, 60);
            this.buttonPay.TabIndex = 45;
            this.buttonPay.Text = "Pay Fees";
            this.buttonPay.UseVisualStyleBackColor = true;
            this.buttonPay.Click += new System.EventHandler(this.buttonPay_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(889, 1054);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(265, 60);
            this.buttonCancel.TabIndex = 46;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelSuccess
            // 
            this.labelSuccess.AutoSize = true;
            this.labelSuccess.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSuccess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.labelSuccess.Location = new System.Drawing.Point(233, 1064);
            this.labelSuccess.Name = "labelSuccess";
            this.labelSuccess.Size = new System.Drawing.Size(0, 39);
            this.labelSuccess.TabIndex = 53;
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(227, 1075);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(0, 39);
            this.labelError.TabIndex = 52;
            // 
            // checkedListBoxPaidFees
            // 
            this.checkedListBoxPaidFees.CheckOnClick = true;
            this.checkedListBoxPaidFees.Enabled = false;
            this.checkedListBoxPaidFees.FormattingEnabled = true;
            this.checkedListBoxPaidFees.Location = new System.Drawing.Point(509, 756);
            this.checkedListBoxPaidFees.Name = "checkedListBoxPaidFees";
            this.checkedListBoxPaidFees.Size = new System.Drawing.Size(995, 235);
            this.checkedListBoxPaidFees.TabIndex = 54;
            // 
            // labelNoPaidFees
            // 
            this.labelNoPaidFees.AutoSize = true;
            this.labelNoPaidFees.Location = new System.Drawing.Point(293, 500);
            this.labelNoPaidFees.Name = "labelNoPaidFees";
            this.labelNoPaidFees.Size = new System.Drawing.Size(190, 32);
            this.labelNoPaidFees.TabIndex = 55;
            this.labelNoPaidFees.Text = "Not paid fees:";
            // 
            // labelPaidFees
            // 
            this.labelPaidFees.AutoSize = true;
            this.labelPaidFees.Location = new System.Drawing.Point(332, 756);
            this.labelPaidFees.Name = "labelPaidFees";
            this.labelPaidFees.Size = new System.Drawing.Size(142, 32);
            this.labelPaidFees.TabIndex = 56;
            this.labelPaidFees.Text = "Paid fees:";
            // 
            // PayFeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1668, 1192);
            this.Controls.Add(this.labelPaidFees);
            this.Controls.Add(this.labelNoPaidFees);
            this.Controls.Add(this.checkedListBoxPaidFees);
            this.Controls.Add(this.labelSuccess);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.buttonPay);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.textBoxFullName);
            this.Controls.Add(this.textBoxDocumentNumber);
            this.Controls.Add(this.labelDocumentNumber);
            this.Controls.Add(this.labelStudentFullName);
            this.Controls.Add(this.checkedListBoxNotPaidFees);
            this.Controls.Add(this.labelStudentNumbers);
            this.Controls.Add(this.comboBoxStudentNumbers);
            this.Controls.Add(this.labelAddStudentTitle);
            this.Name = "PayFeeForm";
            this.Text = "Fee\'s payment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAddStudentTitle;
        private System.Windows.Forms.ComboBox comboBoxStudentNumbers;
        private System.Windows.Forms.Label labelStudentNumbers;
        private System.Windows.Forms.CheckedListBox checkedListBoxNotPaidFees;
        private System.Windows.Forms.Label labelStudentFullName;
        private System.Windows.Forms.Label labelDocumentNumber;
        private System.Windows.Forms.TextBox textBoxDocumentNumber;
        private System.Windows.Forms.TextBox textBoxFullName;
        private System.Windows.Forms.Button buttonPay;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelSuccess;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.CheckedListBox checkedListBoxPaidFees;
        private System.Windows.Forms.Label labelNoPaidFees;
        private System.Windows.Forms.Label labelPaidFees;
    }
}