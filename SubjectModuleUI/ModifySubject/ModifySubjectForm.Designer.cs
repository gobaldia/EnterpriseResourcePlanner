namespace SubjectModuleUI.ModifySubject
{
    partial class ModifySubjectForm
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
            this.labelModifySubjectTitle = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.labelSelectSubjectToModify = new System.Windows.Forms.Label();
            this.textBoxNameModifySubject = new System.Windows.Forms.TextBox();
            this.textBoxCodeModifySubject = new System.Windows.Forms.TextBox();
            this.labelCodeModifySubject = new System.Windows.Forms.Label();
            this.labelNameModifySubject = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelModifySubjectTitle
            // 
            this.labelModifySubjectTitle.AutoSize = true;
            this.labelModifySubjectTitle.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelModifySubjectTitle.Location = new System.Drawing.Point(12, 9);
            this.labelModifySubjectTitle.Name = "labelModifySubjectTitle";
            this.labelModifySubjectTitle.Size = new System.Drawing.Size(153, 23);
            this.labelModifySubjectTitle.TabIndex = 0;
            this.labelModifySubjectTitle.Text = "Modify Subject";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(16, 68);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // labelSelectSubjectToModify
            // 
            this.labelSelectSubjectToModify.AutoSize = true;
            this.labelSelectSubjectToModify.Location = new System.Drawing.Point(16, 49);
            this.labelSelectSubjectToModify.Name = "labelSelectSubjectToModify";
            this.labelSelectSubjectToModify.Size = new System.Drawing.Size(119, 13);
            this.labelSelectSubjectToModify.TabIndex = 2;
            this.labelSelectSubjectToModify.Text = "Select subject to modify";
            // 
            // textBoxNameModifySubject
            // 
            this.textBoxNameModifySubject.Location = new System.Drawing.Point(16, 188);
            this.textBoxNameModifySubject.Name = "textBoxNameModifySubject";
            this.textBoxNameModifySubject.Size = new System.Drawing.Size(100, 20);
            this.textBoxNameModifySubject.TabIndex = 3;
            this.textBoxNameModifySubject.Visible = false;
            // 
            // textBoxCodeModifySubject
            // 
            this.textBoxCodeModifySubject.Location = new System.Drawing.Point(16, 130);
            this.textBoxCodeModifySubject.Name = "textBoxCodeModifySubject";
            this.textBoxCodeModifySubject.Size = new System.Drawing.Size(100, 20);
            this.textBoxCodeModifySubject.TabIndex = 4;
            this.textBoxCodeModifySubject.Visible = false;
            // 
            // labelCodeModifySubject
            // 
            this.labelCodeModifySubject.AutoSize = true;
            this.labelCodeModifySubject.Location = new System.Drawing.Point(16, 111);
            this.labelCodeModifySubject.Name = "labelCodeModifySubject";
            this.labelCodeModifySubject.Size = new System.Drawing.Size(32, 13);
            this.labelCodeModifySubject.TabIndex = 5;
            this.labelCodeModifySubject.Text = "Code";
            this.labelCodeModifySubject.Visible = false;
            // 
            // labelNameModifySubject
            // 
            this.labelNameModifySubject.AutoSize = true;
            this.labelNameModifySubject.Location = new System.Drawing.Point(16, 168);
            this.labelNameModifySubject.Name = "labelNameModifySubject";
            this.labelNameModifySubject.Size = new System.Drawing.Size(35, 13);
            this.labelNameModifySubject.TabIndex = 6;
            this.labelNameModifySubject.Text = "Name";
            this.labelNameModifySubject.Visible = false;
            // 
            // ModifySubjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 442);
            this.Controls.Add(this.labelNameModifySubject);
            this.Controls.Add(this.labelCodeModifySubject);
            this.Controls.Add(this.textBoxCodeModifySubject);
            this.Controls.Add(this.textBoxNameModifySubject);
            this.Controls.Add(this.labelSelectSubjectToModify);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.labelModifySubjectTitle);
            this.Name = "ModifySubjectForm";
            this.Text = "ModifySubjectForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelModifySubjectTitle;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label labelSelectSubjectToModify;
        private System.Windows.Forms.TextBox textBoxNameModifySubject;
        private System.Windows.Forms.TextBox textBoxCodeModifySubject;
        private System.Windows.Forms.Label labelCodeModifySubject;
        private System.Windows.Forms.Label labelNameModifySubject;
    }
}