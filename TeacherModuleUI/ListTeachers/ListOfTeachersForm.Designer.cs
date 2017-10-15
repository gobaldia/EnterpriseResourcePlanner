namespace TeacherModuleUI.ListTeachers
{
    partial class ListOfTeachersForm
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
            this.listBoxSystemTeachers = new System.Windows.Forms.ListBox();
            this.labelSubjectsToBeTeach = new System.Windows.Forms.Label();
            this.labelSystemSubjects = new System.Windows.Forms.Label();
            this.listBoxTeacherSubjects = new System.Windows.Forms.ListBox();
            this.labelListOfTeacherTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxSystemTeachers
            // 
            this.listBoxSystemTeachers.FormattingEnabled = true;
            this.listBoxSystemTeachers.ItemHeight = 31;
            this.listBoxSystemTeachers.Location = new System.Drawing.Point(243, 254);
            this.listBoxSystemTeachers.Name = "listBoxSystemTeachers";
            this.listBoxSystemTeachers.Size = new System.Drawing.Size(1029, 376);
            this.listBoxSystemTeachers.TabIndex = 91;
            this.listBoxSystemTeachers.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBoxSystemTeachers_MouseClick);
            // 
            // labelSubjectsToBeTeach
            // 
            this.labelSubjectsToBeTeach.AutoSize = true;
            this.labelSubjectsToBeTeach.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubjectsToBeTeach.Location = new System.Drawing.Point(246, 688);
            this.labelSubjectsToBeTeach.Name = "labelSubjectsToBeTeach";
            this.labelSubjectsToBeTeach.Size = new System.Drawing.Size(362, 36);
            this.labelSubjectsToBeTeach.TabIndex = 90;
            this.labelSubjectsToBeTeach.Text = "Selected teacher subjects:";
            // 
            // labelSystemSubjects
            // 
            this.labelSystemSubjects.AutoSize = true;
            this.labelSystemSubjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSystemSubjects.Location = new System.Drawing.Point(237, 201);
            this.labelSystemSubjects.Name = "labelSystemSubjects";
            this.labelSystemSubjects.Size = new System.Drawing.Size(241, 36);
            this.labelSystemSubjects.TabIndex = 89;
            this.labelSystemSubjects.Text = "System teachers:";
            // 
            // listBoxTeacherSubjects
            // 
            this.listBoxTeacherSubjects.FormattingEnabled = true;
            this.listBoxTeacherSubjects.ItemHeight = 31;
            this.listBoxTeacherSubjects.Location = new System.Drawing.Point(243, 734);
            this.listBoxTeacherSubjects.Name = "listBoxTeacherSubjects";
            this.listBoxTeacherSubjects.Size = new System.Drawing.Size(1029, 376);
            this.listBoxTeacherSubjects.TabIndex = 86;
            // 
            // labelListOfTeacherTitle
            // 
            this.labelListOfTeacherTitle.AutoSize = true;
            this.labelListOfTeacherTitle.Font = new System.Drawing.Font("Verdana", 14.1F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelListOfTeacherTitle.Location = new System.Drawing.Point(107, 84);
            this.labelListOfTeacherTitle.Name = "labelListOfTeacherTitle";
            this.labelListOfTeacherTitle.Size = new System.Drawing.Size(401, 59);
            this.labelListOfTeacherTitle.TabIndex = 76;
            this.labelListOfTeacherTitle.Text = "List of Teachers";
            // 
            // ListOfTeachersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1868, 1192);
            this.Controls.Add(this.listBoxSystemTeachers);
            this.Controls.Add(this.labelSubjectsToBeTeach);
            this.Controls.Add(this.labelSystemSubjects);
            this.Controls.Add(this.listBoxTeacherSubjects);
            this.Controls.Add(this.labelListOfTeacherTitle);
            this.Name = "ListOfTeachersForm";
            this.Text = "List of Teachers";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxSystemTeachers;
        private System.Windows.Forms.Label labelSubjectsToBeTeach;
        private System.Windows.Forms.Label labelSystemSubjects;
        private System.Windows.Forms.ListBox listBoxTeacherSubjects;
        private System.Windows.Forms.Label labelListOfTeacherTitle;
    }
}