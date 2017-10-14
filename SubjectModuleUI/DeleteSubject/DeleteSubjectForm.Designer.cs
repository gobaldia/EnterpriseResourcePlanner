namespace SubjectModuleUI.DeleteSubject
{
    partial class DeleteSubjectForm
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
            this.labelDeleteSubjectTitle = new System.Windows.Forms.Label();
            this.comboBoxSelectSubjectToDelete = new System.Windows.Forms.ComboBox();
            this.labelSelectSubjectToDelete = new System.Windows.Forms.Label();
            this.buttonDeleteSubject = new System.Windows.Forms.Button();
            this.labelActionResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelDeleteSubjectTitle
            // 
            this.labelDeleteSubjectTitle.AutoSize = true;
            this.labelDeleteSubjectTitle.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDeleteSubjectTitle.Location = new System.Drawing.Point(12, 9);
            this.labelDeleteSubjectTitle.Name = "labelDeleteSubjectTitle";
            this.labelDeleteSubjectTitle.Size = new System.Drawing.Size(150, 23);
            this.labelDeleteSubjectTitle.TabIndex = 0;
            this.labelDeleteSubjectTitle.Text = "Delete Subject";
            // 
            // comboBoxSelectSubjectToDelete
            // 
            this.comboBoxSelectSubjectToDelete.FormattingEnabled = true;
            this.comboBoxSelectSubjectToDelete.Location = new System.Drawing.Point(16, 71);
            this.comboBoxSelectSubjectToDelete.Name = "comboBoxSelectSubjectToDelete";
            this.comboBoxSelectSubjectToDelete.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSelectSubjectToDelete.TabIndex = 1;
            // 
            // labelSelectSubjectToDelete
            // 
            this.labelSelectSubjectToDelete.AutoSize = true;
            this.labelSelectSubjectToDelete.Location = new System.Drawing.Point(16, 52);
            this.labelSelectSubjectToDelete.Name = "labelSelectSubjectToDelete";
            this.labelSelectSubjectToDelete.Size = new System.Drawing.Size(118, 13);
            this.labelSelectSubjectToDelete.TabIndex = 2;
            this.labelSelectSubjectToDelete.Text = "Select subject to delete";
            // 
            // buttonDeleteSubject
            // 
            this.buttonDeleteSubject.Location = new System.Drawing.Point(16, 123);
            this.buttonDeleteSubject.Name = "buttonDeleteSubject";
            this.buttonDeleteSubject.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteSubject.TabIndex = 3;
            this.buttonDeleteSubject.Text = "Delete";
            this.buttonDeleteSubject.UseVisualStyleBackColor = true;
            this.buttonDeleteSubject.Click += new System.EventHandler(this.buttonDeleteSubject_Click);
            // 
            // labelActionResult
            // 
            this.labelActionResult.AutoSize = true;
            this.labelActionResult.Location = new System.Drawing.Point(16, 107);
            this.labelActionResult.Name = "labelActionResult";
            this.labelActionResult.Size = new System.Drawing.Size(0, 13);
            this.labelActionResult.TabIndex = 4;
            this.labelActionResult.Visible = false;
            // 
            // DeleteSubjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.labelActionResult);
            this.Controls.Add(this.buttonDeleteSubject);
            this.Controls.Add(this.labelSelectSubjectToDelete);
            this.Controls.Add(this.comboBoxSelectSubjectToDelete);
            this.Controls.Add(this.labelDeleteSubjectTitle);
            this.Name = "DeleteSubjectForm";
            this.Text = "DeleteSubjectForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDeleteSubjectTitle;
        private System.Windows.Forms.ComboBox comboBoxSelectSubjectToDelete;
        private System.Windows.Forms.Label labelSelectSubjectToDelete;
        private System.Windows.Forms.Button buttonDeleteSubject;
        private System.Windows.Forms.Label labelActionResult;
    }
}