namespace ActivityModuleUI.AddActivity
{
    partial class AddActivityForm
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
            this.labelAddActivityTitle = new System.Windows.Forms.Label();
            this.labelActivityName = new System.Windows.Forms.Label();
            this.labelActivityCost = new System.Windows.Forms.Label();
            this.labelActivityDate = new System.Windows.Forms.Label();
            this.textBoxActivityName = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelError = new System.Windows.Forms.Label();
            this.labelSuccess = new System.Windows.Forms.Label();
            this.dateTimePickerActivityDate = new System.Windows.Forms.DateTimePicker();
            this.numericUpDownActivityCost = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownActivityCost)).BeginInit();
            this.SuspendLayout();
            // 
            // labelAddActivityTitle
            // 
            this.labelAddActivityTitle.AutoSize = true;
            this.labelAddActivityTitle.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAddActivityTitle.Location = new System.Drawing.Point(80, 9);
            this.labelAddActivityTitle.Name = "labelAddActivityTitle";
            this.labelAddActivityTitle.Size = new System.Drawing.Size(125, 23);
            this.labelAddActivityTitle.TabIndex = 0;
            this.labelAddActivityTitle.Text = "Add Activity";
            // 
            // labelActivityName
            // 
            this.labelActivityName.AutoSize = true;
            this.labelActivityName.Location = new System.Drawing.Point(81, 52);
            this.labelActivityName.Name = "labelActivityName";
            this.labelActivityName.Size = new System.Drawing.Size(35, 13);
            this.labelActivityName.TabIndex = 1;
            this.labelActivityName.Text = "Name";
            // 
            // labelActivityCost
            // 
            this.labelActivityCost.AutoSize = true;
            this.labelActivityCost.Location = new System.Drawing.Point(81, 104);
            this.labelActivityCost.Name = "labelActivityCost";
            this.labelActivityCost.Size = new System.Drawing.Size(28, 13);
            this.labelActivityCost.TabIndex = 2;
            this.labelActivityCost.Text = "Cost";
            // 
            // labelActivityDate
            // 
            this.labelActivityDate.AutoSize = true;
            this.labelActivityDate.Location = new System.Drawing.Point(81, 156);
            this.labelActivityDate.Name = "labelActivityDate";
            this.labelActivityDate.Size = new System.Drawing.Size(30, 13);
            this.labelActivityDate.TabIndex = 3;
            this.labelActivityDate.Text = "Date";
            // 
            // textBoxActivityName
            // 
            this.textBoxActivityName.Location = new System.Drawing.Point(84, 68);
            this.textBoxActivityName.Name = "textBoxActivityName";
            this.textBoxActivityName.Size = new System.Drawing.Size(100, 20);
            this.textBoxActivityName.TabIndex = 4;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(375, 263);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 7;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(264, 263);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Location = new System.Drawing.Point(3, 217);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(0, 13);
            this.labelError.TabIndex = 9;
            // 
            // labelSuccess
            // 
            this.labelSuccess.AutoSize = true;
            this.labelSuccess.Location = new System.Drawing.Point(6, 216);
            this.labelSuccess.Name = "labelSuccess";
            this.labelSuccess.Size = new System.Drawing.Size(0, 13);
            this.labelSuccess.TabIndex = 10;
            // 
            // dateTimePickerActivityDate
            // 
            this.dateTimePickerActivityDate.Location = new System.Drawing.Point(84, 172);
            this.dateTimePickerActivityDate.Name = "dateTimePickerActivityDate";
            this.dateTimePickerActivityDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerActivityDate.TabIndex = 11;
            // 
            // numericUpDownActivityCost
            // 
            this.numericUpDownActivityCost.Location = new System.Drawing.Point(84, 121);
            this.numericUpDownActivityCost.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownActivityCost.Name = "numericUpDownActivityCost";
            this.numericUpDownActivityCost.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownActivityCost.TabIndex = 12;
            // 
            // AddActivityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 360);
            this.Controls.Add(this.numericUpDownActivityCost);
            this.Controls.Add(this.dateTimePickerActivityDate);
            this.Controls.Add(this.labelSuccess);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.textBoxActivityName);
            this.Controls.Add(this.labelActivityDate);
            this.Controls.Add(this.labelActivityCost);
            this.Controls.Add(this.labelActivityName);
            this.Controls.Add(this.labelAddActivityTitle);
            this.Name = "AddActivityForm";
            this.Text = "AddActivityForm";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownActivityCost)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAddActivityTitle;
        private System.Windows.Forms.Label labelActivityName;
        private System.Windows.Forms.Label labelActivityCost;
        private System.Windows.Forms.Label labelActivityDate;
        private System.Windows.Forms.TextBox textBoxActivityName;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.Label labelSuccess;
        private System.Windows.Forms.DateTimePicker dateTimePickerActivityDate;
        private System.Windows.Forms.NumericUpDown numericUpDownActivityCost;
    }
}