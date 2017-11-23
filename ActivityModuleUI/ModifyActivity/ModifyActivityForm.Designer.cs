namespace ActivityModuleUI.ModifyActivity
{
    partial class ModifyActivityForm
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
            this.labelModifyActivityTitle = new System.Windows.Forms.Label();
            this.labelSelectActivityToModify = new System.Windows.Forms.Label();
            this.comboBoxSelectActivityToModify = new System.Windows.Forms.ComboBox();
            this.labelActivityName = new System.Windows.Forms.Label();
            this.labelActivityDate = new System.Windows.Forms.Label();
            this.labelActivityCost = new System.Windows.Forms.Label();
            this.textBoxActivityName = new System.Windows.Forms.TextBox();
            this.dateTimePickerActivityDate = new System.Windows.Forms.DateTimePicker();
            this.numericUpDownActivityCost = new System.Windows.Forms.NumericUpDown();
            this.buttonModify = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelError = new System.Windows.Forms.Label();
            this.labelSuccess = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownActivityCost)).BeginInit();
            this.SuspendLayout();
            // 
            // labelModifyActivityTitle
            // 
            this.labelModifyActivityTitle.AutoSize = true;
            this.labelModifyActivityTitle.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelModifyActivityTitle.Location = new System.Drawing.Point(56, 9);
            this.labelModifyActivityTitle.Name = "labelModifyActivityTitle";
            this.labelModifyActivityTitle.Size = new System.Drawing.Size(152, 23);
            this.labelModifyActivityTitle.TabIndex = 0;
            this.labelModifyActivityTitle.Text = "Modify Activity";
            // 
            // labelSelectActivityToModify
            // 
            this.labelSelectActivityToModify.AutoSize = true;
            this.labelSelectActivityToModify.Location = new System.Drawing.Point(60, 49);
            this.labelSelectActivityToModify.Name = "labelSelectActivityToModify";
            this.labelSelectActivityToModify.Size = new System.Drawing.Size(120, 13);
            this.labelSelectActivityToModify.TabIndex = 1;
            this.labelSelectActivityToModify.Text = "Select Activity to Modify";
            // 
            // comboBoxSelectActivityToModify
            // 
            this.comboBoxSelectActivityToModify.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelectActivityToModify.FormattingEnabled = true;
            this.comboBoxSelectActivityToModify.Location = new System.Drawing.Point(60, 66);
            this.comboBoxSelectActivityToModify.Name = "comboBoxSelectActivityToModify";
            this.comboBoxSelectActivityToModify.Size = new System.Drawing.Size(200, 21);
            this.comboBoxSelectActivityToModify.TabIndex = 2;
            this.comboBoxSelectActivityToModify.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelectActivityToModify_SelectedIndexChanged);
            // 
            // labelActivityName
            // 
            this.labelActivityName.AutoSize = true;
            this.labelActivityName.Location = new System.Drawing.Point(60, 103);
            this.labelActivityName.Name = "labelActivityName";
            this.labelActivityName.Size = new System.Drawing.Size(35, 13);
            this.labelActivityName.TabIndex = 3;
            this.labelActivityName.Text = "Name";
            // 
            // labelActivityDate
            // 
            this.labelActivityDate.AutoSize = true;
            this.labelActivityDate.Location = new System.Drawing.Point(60, 162);
            this.labelActivityDate.Name = "labelActivityDate";
            this.labelActivityDate.Size = new System.Drawing.Size(30, 13);
            this.labelActivityDate.TabIndex = 4;
            this.labelActivityDate.Text = "Date";
            // 
            // labelActivityCost
            // 
            this.labelActivityCost.AutoSize = true;
            this.labelActivityCost.Location = new System.Drawing.Point(63, 216);
            this.labelActivityCost.Name = "labelActivityCost";
            this.labelActivityCost.Size = new System.Drawing.Size(28, 13);
            this.labelActivityCost.TabIndex = 5;
            this.labelActivityCost.Text = "Cost";
            // 
            // textBoxActivityName
            // 
            this.textBoxActivityName.Location = new System.Drawing.Point(60, 120);
            this.textBoxActivityName.Name = "textBoxActivityName";
            this.textBoxActivityName.Size = new System.Drawing.Size(200, 20);
            this.textBoxActivityName.TabIndex = 8;
            // 
            // dateTimePickerActivityDate
            // 
            this.dateTimePickerActivityDate.Location = new System.Drawing.Point(60, 179);
            this.dateTimePickerActivityDate.Name = "dateTimePickerActivityDate";
            this.dateTimePickerActivityDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerActivityDate.TabIndex = 9;
            // 
            // numericUpDownActivityCost
            // 
            this.numericUpDownActivityCost.Location = new System.Drawing.Point(63, 233);
            this.numericUpDownActivityCost.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownActivityCost.Name = "numericUpDownActivityCost";
            this.numericUpDownActivityCost.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownActivityCost.TabIndex = 10;
            // 
            // buttonModify
            // 
            this.buttonModify.Enabled = false;
            this.buttonModify.Location = new System.Drawing.Point(497, 350);
            this.buttonModify.Name = "buttonModify";
            this.buttonModify.Size = new System.Drawing.Size(75, 23);
            this.buttonModify.TabIndex = 15;
            this.buttonModify.Text = "Modify";
            this.buttonModify.UseVisualStyleBackColor = true;
            this.buttonModify.Click += new System.EventHandler(this.buttonModify_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(368, 350);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 16;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(60, 294);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(0, 16);
            this.labelError.TabIndex = 17;
            // 
            // labelSuccess
            // 
            this.labelSuccess.AutoSize = true;
            this.labelSuccess.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSuccess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.labelSuccess.Location = new System.Drawing.Point(60, 294);
            this.labelSuccess.Name = "labelSuccess";
            this.labelSuccess.Size = new System.Drawing.Size(0, 16);
            this.labelSuccess.TabIndex = 18;
            // 
            // ModifyActivityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 485);
            this.Controls.Add(this.labelSuccess);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonModify);
            this.Controls.Add(this.numericUpDownActivityCost);
            this.Controls.Add(this.dateTimePickerActivityDate);
            this.Controls.Add(this.textBoxActivityName);
            this.Controls.Add(this.labelActivityCost);
            this.Controls.Add(this.labelActivityDate);
            this.Controls.Add(this.labelActivityName);
            this.Controls.Add(this.comboBoxSelectActivityToModify);
            this.Controls.Add(this.labelSelectActivityToModify);
            this.Controls.Add(this.labelModifyActivityTitle);
            this.Name = "ModifyActivityForm";
            this.Text = "ModifyActivityForm";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownActivityCost)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelModifyActivityTitle;
        private System.Windows.Forms.Label labelSelectActivityToModify;
        private System.Windows.Forms.ComboBox comboBoxSelectActivityToModify;
        private System.Windows.Forms.Label labelActivityName;
        private System.Windows.Forms.Label labelActivityDate;
        private System.Windows.Forms.Label labelActivityCost;
        private System.Windows.Forms.TextBox textBoxActivityName;
        private System.Windows.Forms.DateTimePicker dateTimePickerActivityDate;
        private System.Windows.Forms.NumericUpDown numericUpDownActivityCost;
        private System.Windows.Forms.Button buttonModify;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.Label labelSuccess;
    }
}