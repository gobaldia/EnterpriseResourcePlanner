namespace TeacherModuleUI.AddTeacher
{
    partial class AddTeacherForm
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
            this.labelAddTeacherTitle = new System.Windows.Forms.Label();
            this.labelTeacherName = new System.Windows.Forms.Label();
            this.labelTeacherLastName = new System.Windows.Forms.Label();
            this.labelDocument = new System.Windows.Forms.Label();
            this.textBoxTeacherName = new System.Windows.Forms.TextBox();
            this.textBoxTeacherLastName = new System.Windows.Forms.TextBox();
            this.textBoxTeacherDocument = new System.Windows.Forms.TextBox();
            this.buttonAddTeacher = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.listBoxSystemSubjects = new System.Windows.Forms.ListBox();
            this.listBoxTeacherSubjects = new System.Windows.Forms.ListBox();
            this.buttonAddSubjectToTeacher = new System.Windows.Forms.Button();
            this.buttonRemoveSubjectFromTeacher = new System.Windows.Forms.Button();
            this.labelSystemSubjects = new System.Windows.Forms.Label();
            this.labelSubjectsToBeTeach = new System.Windows.Forms.Label();
            this.labelError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelAddTeacherTitle
            // 
            this.labelAddTeacherTitle.AutoSize = true;
            this.labelAddTeacherTitle.Font = new System.Drawing.Font("Verdana", 14.1F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAddTeacherTitle.Location = new System.Drawing.Point(84, 109);
            this.labelAddTeacherTitle.Name = "labelAddTeacherTitle";
            this.labelAddTeacherTitle.Size = new System.Drawing.Size(322, 59);
            this.labelAddTeacherTitle.TabIndex = 18;
            this.labelAddTeacherTitle.Text = "Add Teacher";
            // 
            // labelTeacherName
            // 
            this.labelTeacherName.AutoSize = true;
            this.labelTeacherName.Location = new System.Drawing.Point(301, 262);
            this.labelTeacherName.Name = "labelTeacherName";
            this.labelTeacherName.Size = new System.Drawing.Size(105, 32);
            this.labelTeacherName.TabIndex = 19;
            this.labelTeacherName.Text = "Name: ";
            // 
            // labelTeacherLastName
            // 
            this.labelTeacherLastName.AutoSize = true;
            this.labelTeacherLastName.Location = new System.Drawing.Point(240, 352);
            this.labelTeacherLastName.Name = "labelTeacherLastName";
            this.labelTeacherLastName.Size = new System.Drawing.Size(166, 32);
            this.labelTeacherLastName.TabIndex = 20;
            this.labelTeacherLastName.Text = "Last Name: ";
            // 
            // labelDocument
            // 
            this.labelDocument.AutoSize = true;
            this.labelDocument.Location = new System.Drawing.Point(247, 446);
            this.labelDocument.Name = "labelDocument";
            this.labelDocument.Size = new System.Drawing.Size(159, 32);
            this.labelDocument.TabIndex = 21;
            this.labelDocument.Text = "Document: ";
            // 
            // textBoxTeacherName
            // 
            this.textBoxTeacherName.Location = new System.Drawing.Point(454, 259);
            this.textBoxTeacherName.Name = "textBoxTeacherName";
            this.textBoxTeacherName.Size = new System.Drawing.Size(380, 38);
            this.textBoxTeacherName.TabIndex = 22;
            // 
            // textBoxTeacherLastName
            // 
            this.textBoxTeacherLastName.Location = new System.Drawing.Point(454, 349);
            this.textBoxTeacherLastName.Name = "textBoxTeacherLastName";
            this.textBoxTeacherLastName.Size = new System.Drawing.Size(380, 38);
            this.textBoxTeacherLastName.TabIndex = 23;
            // 
            // textBoxTeacherDocument
            // 
            this.textBoxTeacherDocument.Location = new System.Drawing.Point(454, 443);
            this.textBoxTeacherDocument.Name = "textBoxTeacherDocument";
            this.textBoxTeacherDocument.Size = new System.Drawing.Size(380, 38);
            this.textBoxTeacherDocument.TabIndex = 24;
            // 
            // buttonAddTeacher
            // 
            this.buttonAddTeacher.Location = new System.Drawing.Point(1473, 1066);
            this.buttonAddTeacher.Name = "buttonAddTeacher";
            this.buttonAddTeacher.Size = new System.Drawing.Size(265, 60);
            this.buttonAddTeacher.TabIndex = 25;
            this.buttonAddTeacher.Text = "Add";
            this.buttonAddTeacher.UseVisualStyleBackColor = true;
            this.buttonAddTeacher.Click += new System.EventHandler(this.buttonAddTeacher_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(1123, 1066);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(265, 60);
            this.buttonCancel.TabIndex = 26;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // listBoxSystemSubjects
            // 
            this.listBoxSystemSubjects.FormattingEnabled = true;
            this.listBoxSystemSubjects.ItemHeight = 31;
            this.listBoxSystemSubjects.Location = new System.Drawing.Point(140, 636);
            this.listBoxSystemSubjects.Name = "listBoxSystemSubjects";
            this.listBoxSystemSubjects.Size = new System.Drawing.Size(694, 252);
            this.listBoxSystemSubjects.TabIndex = 27;
            // 
            // listBoxTeacherSubjects
            // 
            this.listBoxTeacherSubjects.FormattingEnabled = true;
            this.listBoxTeacherSubjects.ItemHeight = 31;
            this.listBoxTeacherSubjects.Location = new System.Drawing.Point(1044, 636);
            this.listBoxTeacherSubjects.Name = "listBoxTeacherSubjects";
            this.listBoxTeacherSubjects.Size = new System.Drawing.Size(694, 252);
            this.listBoxTeacherSubjects.TabIndex = 28;
            // 
            // buttonAddSubjectToTeacher
            // 
            this.buttonAddSubjectToTeacher.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddSubjectToTeacher.Location = new System.Drawing.Point(894, 693);
            this.buttonAddSubjectToTeacher.Name = "buttonAddSubjectToTeacher";
            this.buttonAddSubjectToTeacher.Size = new System.Drawing.Size(100, 50);
            this.buttonAddSubjectToTeacher.TabIndex = 29;
            this.buttonAddSubjectToTeacher.Text = ">>";
            this.buttonAddSubjectToTeacher.UseVisualStyleBackColor = true;
            this.buttonAddSubjectToTeacher.Click += new System.EventHandler(this.buttonAddSubjectToTeacher_Click);
            // 
            // buttonRemoveSubjectFromTeacher
            // 
            this.buttonRemoveSubjectFromTeacher.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemoveSubjectFromTeacher.Location = new System.Drawing.Point(894, 781);
            this.buttonRemoveSubjectFromTeacher.Name = "buttonRemoveSubjectFromTeacher";
            this.buttonRemoveSubjectFromTeacher.Size = new System.Drawing.Size(100, 50);
            this.buttonRemoveSubjectFromTeacher.TabIndex = 30;
            this.buttonRemoveSubjectFromTeacher.Text = "<<";
            this.buttonRemoveSubjectFromTeacher.UseVisualStyleBackColor = true;
            this.buttonRemoveSubjectFromTeacher.Click += new System.EventHandler(this.buttonRemoveSubjectFromTeacher_Click);
            // 
            // labelSystemSubjects
            // 
            this.labelSystemSubjects.AutoSize = true;
            this.labelSystemSubjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSystemSubjects.Location = new System.Drawing.Point(137, 590);
            this.labelSystemSubjects.Name = "labelSystemSubjects";
            this.labelSystemSubjects.Size = new System.Drawing.Size(271, 36);
            this.labelSystemSubjects.TabIndex = 31;
            this.labelSystemSubjects.Text = "Available subjects: ";
            // 
            // labelSubjectsToBeTeach
            // 
            this.labelSubjectsToBeTeach.AutoSize = true;
            this.labelSubjectsToBeTeach.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubjectsToBeTeach.Location = new System.Drawing.Point(1047, 590);
            this.labelSubjectsToBeTeach.Name = "labelSubjectsToBeTeach";
            this.labelSubjectsToBeTeach.Size = new System.Drawing.Size(300, 36);
            this.labelSubjectsToBeTeach.TabIndex = 32;
            this.labelSubjectsToBeTeach.Text = "Subjects to be teach: ";
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(137, 1094);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(0, 39);
            this.labelError.TabIndex = 33;
            // 
            // AddTeacherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1868, 1192);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.labelSubjectsToBeTeach);
            this.Controls.Add(this.labelSystemSubjects);
            this.Controls.Add(this.buttonRemoveSubjectFromTeacher);
            this.Controls.Add(this.buttonAddSubjectToTeacher);
            this.Controls.Add(this.listBoxTeacherSubjects);
            this.Controls.Add(this.listBoxSystemSubjects);
            this.Controls.Add(this.labelAddTeacherTitle);
            this.Controls.Add(this.labelTeacherName);
            this.Controls.Add(this.labelTeacherLastName);
            this.Controls.Add(this.labelDocument);
            this.Controls.Add(this.textBoxTeacherName);
            this.Controls.Add(this.textBoxTeacherLastName);
            this.Controls.Add(this.textBoxTeacherDocument);
            this.Controls.Add(this.buttonAddTeacher);
            this.Controls.Add(this.buttonCancel);
            this.Name = "AddTeacherForm";
            this.Text = "AddTeacherForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAddTeacherTitle;
        private System.Windows.Forms.Label labelTeacherName;
        private System.Windows.Forms.Label labelTeacherLastName;
        private System.Windows.Forms.Label labelDocument;
        private System.Windows.Forms.TextBox textBoxTeacherName;
        private System.Windows.Forms.TextBox textBoxTeacherLastName;
        private System.Windows.Forms.TextBox textBoxTeacherDocument;
        private System.Windows.Forms.Button buttonAddTeacher;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ListBox listBoxSystemSubjects;
        private System.Windows.Forms.ListBox listBoxTeacherSubjects;
        private System.Windows.Forms.Button buttonAddSubjectToTeacher;
        private System.Windows.Forms.Button buttonRemoveSubjectFromTeacher;
        private System.Windows.Forms.Label labelSystemSubjects;
        private System.Windows.Forms.Label labelSubjectsToBeTeach;
        private System.Windows.Forms.Label labelError;
    }
}