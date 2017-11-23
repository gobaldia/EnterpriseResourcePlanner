namespace PaymentModuleUI.PayActivity
{
    partial class PayActivityForm
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
            this.labelPayStudentActivitiesTitle = new System.Windows.Forms.Label();
            this.comboBoxStudentsNumbers = new System.Windows.Forms.ComboBox();
            this.labelStudentNumber = new System.Windows.Forms.Label();
            this.labelFullName = new System.Windows.Forms.Label();
            this.labelDocument = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxDocument = new System.Windows.Forms.TextBox();
            this.checkedListBoxAvailableActivities = new System.Windows.Forms.CheckedListBox();
            this.listBoxStudentActivities = new System.Windows.Forms.ListBox();
            this.labelStudentActivities = new System.Windows.Forms.Label();
            this.labelAvailableActivities = new System.Windows.Forms.Label();
            this.labelCostToBePaid = new System.Windows.Forms.Label();
            this.labelAmountToPay = new System.Windows.Forms.Label();
            this.buttonPay = new System.Windows.Forms.Button();
            this.labelSuccess = new System.Windows.Forms.Label();
            this.labelError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelPayStudentActivitiesTitle
            // 
            this.labelPayStudentActivitiesTitle.AutoSize = true;
            this.labelPayStudentActivitiesTitle.Font = new System.Drawing.Font("Verdana", 14.1F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPayStudentActivitiesTitle.Location = new System.Drawing.Point(107, 84);
            this.labelPayStudentActivitiesTitle.Name = "labelPayStudentActivitiesTitle";
            this.labelPayStudentActivitiesTitle.Size = new System.Drawing.Size(344, 59);
            this.labelPayStudentActivitiesTitle.TabIndex = 37;
            this.labelPayStudentActivitiesTitle.Text = "Pay Activities";
            // 
            // comboBoxStudentsNumbers
            // 
            this.comboBoxStudentsNumbers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStudentsNumbers.FormattingEnabled = true;
            this.comboBoxStudentsNumbers.Location = new System.Drawing.Point(380, 212);
            this.comboBoxStudentsNumbers.Name = "comboBoxStudentsNumbers";
            this.comboBoxStudentsNumbers.Size = new System.Drawing.Size(430, 39);
            this.comboBoxStudentsNumbers.TabIndex = 124;
            this.comboBoxStudentsNumbers.SelectedIndexChanged += new System.EventHandler(this.StudentCombo_SelectedIndexChanged);
            // 
            // labelStudentNumber
            // 
            this.labelStudentNumber.AutoSize = true;
            this.labelStudentNumber.Location = new System.Drawing.Point(128, 212);
            this.labelStudentNumber.Name = "labelStudentNumber";
            this.labelStudentNumber.Size = new System.Drawing.Size(232, 32);
            this.labelStudentNumber.TabIndex = 123;
            this.labelStudentNumber.Text = "Student number: ";
            // 
            // labelFullName
            // 
            this.labelFullName.AutoSize = true;
            this.labelFullName.Location = new System.Drawing.Point(205, 394);
            this.labelFullName.Name = "labelFullName";
            this.labelFullName.Size = new System.Drawing.Size(155, 32);
            this.labelFullName.TabIndex = 121;
            this.labelFullName.Text = "Full name: ";
            // 
            // labelDocument
            // 
            this.labelDocument.AutoSize = true;
            this.labelDocument.Location = new System.Drawing.Point(201, 300);
            this.labelDocument.Name = "labelDocument";
            this.labelDocument.Size = new System.Drawing.Size(159, 32);
            this.labelDocument.TabIndex = 122;
            this.labelDocument.Text = "Document: ";
            // 
            // textBoxName
            // 
            this.textBoxName.Enabled = false;
            this.textBoxName.Location = new System.Drawing.Point(380, 394);
            this.textBoxName.MaxLength = 50;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(430, 38);
            this.textBoxName.TabIndex = 120;
            // 
            // textBoxDocument
            // 
            this.textBoxDocument.Enabled = false;
            this.textBoxDocument.Location = new System.Drawing.Point(380, 300);
            this.textBoxDocument.MaxLength = 9;
            this.textBoxDocument.Name = "textBoxDocument";
            this.textBoxDocument.Size = new System.Drawing.Size(430, 38);
            this.textBoxDocument.TabIndex = 119;
            // 
            // checkedListBoxAvailableActivities
            // 
            this.checkedListBoxAvailableActivities.CheckOnClick = true;
            this.checkedListBoxAvailableActivities.FormattingEnabled = true;
            this.checkedListBoxAvailableActivities.Location = new System.Drawing.Point(160, 609);
            this.checkedListBoxAvailableActivities.Name = "checkedListBoxAvailableActivities";
            this.checkedListBoxAvailableActivities.Size = new System.Drawing.Size(798, 400);
            this.checkedListBoxAvailableActivities.TabIndex = 125;
            this.checkedListBoxAvailableActivities.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxAvailableActivities_ItemCheck);
            // 
            // listBoxStudentActivities
            // 
            this.listBoxStudentActivities.Enabled = false;
            this.listBoxStudentActivities.FormattingEnabled = true;
            this.listBoxStudentActivities.ItemHeight = 31;
            this.listBoxStudentActivities.Location = new System.Drawing.Point(951, 259);
            this.listBoxStudentActivities.Name = "listBoxStudentActivities";
            this.listBoxStudentActivities.Size = new System.Drawing.Size(788, 252);
            this.listBoxStudentActivities.TabIndex = 126;
            // 
            // labelStudentActivities
            // 
            this.labelStudentActivities.AutoSize = true;
            this.labelStudentActivities.Location = new System.Drawing.Point(945, 212);
            this.labelStudentActivities.Name = "labelStudentActivities";
            this.labelStudentActivities.Size = new System.Drawing.Size(240, 32);
            this.labelStudentActivities.TabIndex = 127;
            this.labelStudentActivities.Text = "Student activities:";
            // 
            // labelAvailableActivities
            // 
            this.labelAvailableActivities.AutoSize = true;
            this.labelAvailableActivities.Location = new System.Drawing.Point(154, 560);
            this.labelAvailableActivities.Name = "labelAvailableActivities";
            this.labelAvailableActivities.Size = new System.Drawing.Size(259, 32);
            this.labelAvailableActivities.TabIndex = 128;
            this.labelAvailableActivities.Text = "Available activities:";
            // 
            // labelCostToBePaid
            // 
            this.labelCostToBePaid.AutoSize = true;
            this.labelCostToBePaid.Location = new System.Drawing.Point(1163, 878);
            this.labelCostToBePaid.Name = "labelCostToBePaid";
            this.labelCostToBePaid.Size = new System.Drawing.Size(276, 32);
            this.labelCostToBePaid.TabIndex = 129;
            this.labelCostToBePaid.Text = "Amount to be paid: $";
            // 
            // labelAmountToPay
            // 
            this.labelAmountToPay.AutoSize = true;
            this.labelAmountToPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAmountToPay.Location = new System.Drawing.Point(1445, 878);
            this.labelAmountToPay.Name = "labelAmountToPay";
            this.labelAmountToPay.Size = new System.Drawing.Size(37, 39);
            this.labelAmountToPay.TabIndex = 130;
            this.labelAmountToPay.Text = "0";
            // 
            // buttonPay
            // 
            this.buttonPay.Location = new System.Drawing.Point(1452, 954);
            this.buttonPay.Name = "buttonPay";
            this.buttonPay.Size = new System.Drawing.Size(287, 55);
            this.buttonPay.TabIndex = 131;
            this.buttonPay.Text = "Assign and Pay";
            this.buttonPay.UseVisualStyleBackColor = true;
            this.buttonPay.Click += new System.EventHandler(this.ButtonPay_Click);
            // 
            // labelSuccess
            // 
            this.labelSuccess.AutoSize = true;
            this.labelSuccess.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSuccess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.labelSuccess.Location = new System.Drawing.Point(153, 1044);
            this.labelSuccess.Name = "labelSuccess";
            this.labelSuccess.Size = new System.Drawing.Size(0, 39);
            this.labelSuccess.TabIndex = 133;
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(147, 1055);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(0, 39);
            this.labelError.TabIndex = 132;
            // 
            // PayActivityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1868, 1192);
            this.Controls.Add(this.labelSuccess);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.buttonPay);
            this.Controls.Add(this.labelAmountToPay);
            this.Controls.Add(this.labelCostToBePaid);
            this.Controls.Add(this.labelAvailableActivities);
            this.Controls.Add(this.labelStudentActivities);
            this.Controls.Add(this.listBoxStudentActivities);
            this.Controls.Add(this.checkedListBoxAvailableActivities);
            this.Controls.Add(this.comboBoxStudentsNumbers);
            this.Controls.Add(this.labelStudentNumber);
            this.Controls.Add(this.labelFullName);
            this.Controls.Add(this.labelDocument);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.textBoxDocument);
            this.Controls.Add(this.labelPayStudentActivitiesTitle);
            this.Name = "PayActivityForm";
            this.Text = "Pay Student Activities";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPayStudentActivitiesTitle;
        private System.Windows.Forms.ComboBox comboBoxStudentsNumbers;
        private System.Windows.Forms.Label labelStudentNumber;
        private System.Windows.Forms.Label labelFullName;
        private System.Windows.Forms.Label labelDocument;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxDocument;
        private System.Windows.Forms.CheckedListBox checkedListBoxAvailableActivities;
        private System.Windows.Forms.ListBox listBoxStudentActivities;
        private System.Windows.Forms.Label labelStudentActivities;
        private System.Windows.Forms.Label labelAvailableActivities;
        private System.Windows.Forms.Label labelCostToBePaid;
        private System.Windows.Forms.Label labelAmountToPay;
        private System.Windows.Forms.Button buttonPay;
        private System.Windows.Forms.Label labelSuccess;
        private System.Windows.Forms.Label labelError;
    }
}