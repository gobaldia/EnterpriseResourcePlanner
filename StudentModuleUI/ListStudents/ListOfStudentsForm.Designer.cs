namespace StudentModuleUI.ListStudents
{
    partial class ListOfStudentsForm
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
            this.listBoxSystemStudents = new System.Windows.Forms.ListBox();
            this.labelSubjectsToBeTeach = new System.Windows.Forms.Label();
            this.labelSystemSubjects = new System.Windows.Forms.Label();
            this.listBoxStudentSubjects = new System.Windows.Forms.ListBox();
            this.labelListOfStudentsTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxSystemStudents
            // 
            this.listBoxSystemStudents.FormattingEnabled = true;
            this.listBoxSystemStudents.ItemHeight = 31;
            this.listBoxSystemStudents.Location = new System.Drawing.Point(261, 249);
            this.listBoxSystemStudents.Name = "listBoxSystemStudents";
            this.listBoxSystemStudents.Size = new System.Drawing.Size(1029, 376);
            this.listBoxSystemStudents.TabIndex = 96;
            this.listBoxSystemStudents.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBoxSystemStudents_MouseClick);
            // 
            // labelSubjectsToBeTeach
            // 
            this.labelSubjectsToBeTeach.AutoSize = true;
            this.labelSubjectsToBeTeach.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubjectsToBeTeach.Location = new System.Drawing.Point(264, 683);
            this.labelSubjectsToBeTeach.Name = "labelSubjectsToBeTeach";
            this.labelSubjectsToBeTeach.Size = new System.Drawing.Size(362, 36);
            this.labelSubjectsToBeTeach.TabIndex = 95;
            this.labelSubjectsToBeTeach.Text = "Selected student subjects:";
            // 
            // labelSystemSubjects
            // 
            this.labelSystemSubjects.AutoSize = true;
            this.labelSystemSubjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSystemSubjects.Location = new System.Drawing.Point(255, 196);
            this.labelSystemSubjects.Name = "labelSystemSubjects";
            this.labelSystemSubjects.Size = new System.Drawing.Size(241, 36);
            this.labelSystemSubjects.TabIndex = 94;
            this.labelSystemSubjects.Text = "System students:";
            // 
            // listBoxStudentSubjects
            // 
            this.listBoxStudentSubjects.FormattingEnabled = true;
            this.listBoxStudentSubjects.ItemHeight = 31;
            this.listBoxStudentSubjects.Location = new System.Drawing.Point(261, 729);
            this.listBoxStudentSubjects.Name = "listBoxStudentSubjects";
            this.listBoxStudentSubjects.Size = new System.Drawing.Size(1029, 376);
            this.listBoxStudentSubjects.TabIndex = 93;
            // 
            // labelListOfStudentsTitle
            // 
            this.labelListOfStudentsTitle.AutoSize = true;
            this.labelListOfStudentsTitle.Font = new System.Drawing.Font("Verdana", 14.1F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelListOfStudentsTitle.Location = new System.Drawing.Point(125, 79);
            this.labelListOfStudentsTitle.Name = "labelListOfStudentsTitle";
            this.labelListOfStudentsTitle.Size = new System.Drawing.Size(404, 59);
            this.labelListOfStudentsTitle.TabIndex = 92;
            this.labelListOfStudentsTitle.Text = "List of Students";
            // 
            // ListOfStudentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1868, 1192);
            this.Controls.Add(this.listBoxSystemStudents);
            this.Controls.Add(this.labelSubjectsToBeTeach);
            this.Controls.Add(this.labelSystemSubjects);
            this.Controls.Add(this.listBoxStudentSubjects);
            this.Controls.Add(this.labelListOfStudentsTitle);
            this.Name = "ListOfStudentsForm";
            this.Text = "List of Students";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxSystemStudents;
        private System.Windows.Forms.Label labelSubjectsToBeTeach;
        private System.Windows.Forms.Label labelSystemSubjects;
        private System.Windows.Forms.ListBox listBoxStudentSubjects;
        private System.Windows.Forms.Label labelListOfStudentsTitle;
    }
}