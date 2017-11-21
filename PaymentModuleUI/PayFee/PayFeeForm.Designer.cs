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
            this.checkedListBoxOfFees = new System.Windows.Forms.CheckedListBox();
            this.labelStudentFullName = new System.Windows.Forms.Label();
            this.labelDocumentNumber = new System.Windows.Forms.Label();
            this.textBoxDocumentNumber = new System.Windows.Forms.TextBox();
            this.textBoxFullName = new System.Windows.Forms.TextBox();
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
            // checkedListBoxOfFees
            // 
            this.checkedListBoxOfFees.CheckOnClick = true;
            this.checkedListBoxOfFees.FormattingEnabled = true;
            this.checkedListBoxOfFees.Location = new System.Drawing.Point(250, 486);
            this.checkedListBoxOfFees.Name = "checkedListBoxOfFees";
            this.checkedListBoxOfFees.Size = new System.Drawing.Size(995, 367);
            this.checkedListBoxOfFees.TabIndex = 40;
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
            // PayFeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1668, 992);
            this.Controls.Add(this.textBoxFullName);
            this.Controls.Add(this.textBoxDocumentNumber);
            this.Controls.Add(this.labelDocumentNumber);
            this.Controls.Add(this.labelStudentFullName);
            this.Controls.Add(this.checkedListBoxOfFees);
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
        private System.Windows.Forms.CheckedListBox checkedListBoxOfFees;
        private System.Windows.Forms.Label labelStudentFullName;
        private System.Windows.Forms.Label labelDocumentNumber;
        private System.Windows.Forms.TextBox textBoxDocumentNumber;
        private System.Windows.Forms.TextBox textBoxFullName;
    }
}