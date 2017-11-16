namespace ActivityModuleUI.DeleteActivity
{
    partial class DeleteActivityForm
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
            this.labelDeleteActivityTitle = new System.Windows.Forms.Label();
            this.labelSelectActivityToDelete = new System.Windows.Forms.Label();
            this.comboBoxSelectActivityToDelete = new System.Windows.Forms.ComboBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.labelSuccess = new System.Windows.Forms.Label();
            this.labelError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelDeleteActivityTitle
            // 
            this.labelDeleteActivityTitle.AutoSize = true;
            this.labelDeleteActivityTitle.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDeleteActivityTitle.Location = new System.Drawing.Point(59, 13);
            this.labelDeleteActivityTitle.Name = "labelDeleteActivityTitle";
            this.labelDeleteActivityTitle.Size = new System.Drawing.Size(149, 23);
            this.labelDeleteActivityTitle.TabIndex = 0;
            this.labelDeleteActivityTitle.Text = "Delete Activity";
            // 
            // labelSelectActivityToDelete
            // 
            this.labelSelectActivityToDelete.AutoSize = true;
            this.labelSelectActivityToDelete.Location = new System.Drawing.Point(60, 62);
            this.labelSelectActivityToDelete.Name = "labelSelectActivityToDelete";
            this.labelSelectActivityToDelete.Size = new System.Drawing.Size(120, 13);
            this.labelSelectActivityToDelete.TabIndex = 1;
            this.labelSelectActivityToDelete.Text = "Select Activity to Delete";
            // 
            // comboBoxSelectActivityToDelete
            // 
            this.comboBoxSelectActivityToDelete.FormattingEnabled = true;
            this.comboBoxSelectActivityToDelete.Location = new System.Drawing.Point(63, 79);
            this.comboBoxSelectActivityToDelete.Name = "comboBoxSelectActivityToDelete";
            this.comboBoxSelectActivityToDelete.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSelectActivityToDelete.TabIndex = 2;
            this.comboBoxSelectActivityToDelete.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelectActivityToDelete_SelectedIndexChanged);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(273, 247);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Enabled = false;
            this.buttonDelete.Location = new System.Drawing.Point(398, 247);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 4;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // labelSuccess
            // 
            this.labelSuccess.AutoSize = true;
            this.labelSuccess.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSuccess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.labelSuccess.Location = new System.Drawing.Point(63, 188);
            this.labelSuccess.Name = "labelSuccess";
            this.labelSuccess.Size = new System.Drawing.Size(0, 16);
            this.labelSuccess.TabIndex = 5;
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(63, 187);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(0, 16);
            this.labelError.TabIndex = 6;
            // 
            // DeleteActivityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 391);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.labelSuccess);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.comboBoxSelectActivityToDelete);
            this.Controls.Add(this.labelSelectActivityToDelete);
            this.Controls.Add(this.labelDeleteActivityTitle);
            this.Name = "DeleteActivityForm";
            this.Text = "DeleteActivityForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDeleteActivityTitle;
        private System.Windows.Forms.Label labelSelectActivityToDelete;
        private System.Windows.Forms.ComboBox comboBoxSelectActivityToDelete;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Label labelSuccess;
        private System.Windows.Forms.Label labelError;
    }
}