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
            this.textBoxActivityCost = new System.Windows.Forms.TextBox();
            this.textBoxActivityDate = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelAddActivityTitle
            // 
            this.labelAddActivityTitle.AutoSize = true;
            this.labelAddActivityTitle.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAddActivityTitle.Location = new System.Drawing.Point(13, 13);
            this.labelAddActivityTitle.Name = "labelAddActivityTitle";
            this.labelAddActivityTitle.Size = new System.Drawing.Size(125, 23);
            this.labelAddActivityTitle.TabIndex = 0;
            this.labelAddActivityTitle.Text = "Add Activity";
            // 
            // labelActivityName
            // 
            this.labelActivityName.AutoSize = true;
            this.labelActivityName.Location = new System.Drawing.Point(17, 73);
            this.labelActivityName.Name = "labelActivityName";
            this.labelActivityName.Size = new System.Drawing.Size(35, 13);
            this.labelActivityName.TabIndex = 1;
            this.labelActivityName.Text = "Name";
            // 
            // labelActivityCost
            // 
            this.labelActivityCost.AutoSize = true;
            this.labelActivityCost.Location = new System.Drawing.Point(17, 101);
            this.labelActivityCost.Name = "labelActivityCost";
            this.labelActivityCost.Size = new System.Drawing.Size(28, 13);
            this.labelActivityCost.TabIndex = 2;
            this.labelActivityCost.Text = "Cost";
            // 
            // labelActivityDate
            // 
            this.labelActivityDate.AutoSize = true;
            this.labelActivityDate.Location = new System.Drawing.Point(17, 131);
            this.labelActivityDate.Name = "labelActivityDate";
            this.labelActivityDate.Size = new System.Drawing.Size(30, 13);
            this.labelActivityDate.TabIndex = 3;
            this.labelActivityDate.Text = "Date";
            // 
            // textBoxActivityName
            // 
            this.textBoxActivityName.Location = new System.Drawing.Point(59, 65);
            this.textBoxActivityName.Name = "textBoxActivityName";
            this.textBoxActivityName.Size = new System.Drawing.Size(100, 20);
            this.textBoxActivityName.TabIndex = 4;
            // 
            // textBoxActivityCost
            // 
            this.textBoxActivityCost.Location = new System.Drawing.Point(59, 93);
            this.textBoxActivityCost.Name = "textBoxActivityCost";
            this.textBoxActivityCost.Size = new System.Drawing.Size(100, 20);
            this.textBoxActivityCost.TabIndex = 5;
            // 
            // textBoxActivityDate
            // 
            this.textBoxActivityDate.Location = new System.Drawing.Point(59, 123);
            this.textBoxActivityDate.Name = "textBoxActivityDate";
            this.textBoxActivityDate.Size = new System.Drawing.Size(100, 20);
            this.textBoxActivityDate.TabIndex = 6;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(84, 188);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 7;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(84, 218);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // AddActivityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 360);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.textBoxActivityDate);
            this.Controls.Add(this.textBoxActivityCost);
            this.Controls.Add(this.textBoxActivityName);
            this.Controls.Add(this.labelActivityDate);
            this.Controls.Add(this.labelActivityCost);
            this.Controls.Add(this.labelActivityName);
            this.Controls.Add(this.labelAddActivityTitle);
            this.Name = "AddActivityForm";
            this.Text = "AddActivityForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAddActivityTitle;
        private System.Windows.Forms.Label labelActivityName;
        private System.Windows.Forms.Label labelActivityCost;
        private System.Windows.Forms.Label labelActivityDate;
        private System.Windows.Forms.TextBox textBoxActivityName;
        private System.Windows.Forms.TextBox textBoxActivityCost;
        private System.Windows.Forms.TextBox textBoxActivityDate;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonCancel;
    }
}