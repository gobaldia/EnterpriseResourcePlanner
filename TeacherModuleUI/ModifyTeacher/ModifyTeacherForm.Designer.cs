namespace TeacherModuleUI.ModifyTeacher
{
    partial class ModifyTeacherForm
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
            this.labelDocument = new System.Windows.Forms.Label();
            this.labelSuccess = new System.Windows.Forms.Label();
            this.labelError = new System.Windows.Forms.Label();
            this.labelModifyTeacherTitle = new System.Windows.Forms.Label();
            this.labelTeacherName = new System.Windows.Forms.Label();
            this.labelTeacherLastName = new System.Windows.Forms.Label();
            this.textBoxTeacherName = new System.Windows.Forms.TextBox();
            this.textBoxTeacherLastName = new System.Windows.Forms.TextBox();
            this.buttonModifyTeacher = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.listBoxSystemSubjects = new System.Windows.Forms.ListBox();
            this.labelSubjectsToBeTeach = new System.Windows.Forms.Label();
            this.labelSystemSubjects = new System.Windows.Forms.Label();
            this.buttonRemoveSubjectFromTeacher = new System.Windows.Forms.Button();
            this.buttonAddSubjectToTeacher = new System.Windows.Forms.Button();
            this.listBoxTeacherSubjects = new System.Windows.Forms.ListBox();
            this.comboBoxTeachersDocuments = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // labelDocument
            // 
            this.labelDocument.AutoSize = true;
            this.labelDocument.Location = new System.Drawing.Point(270, 235);
            this.labelDocument.Name = "labelDocument";
            this.labelDocument.Size = new System.Drawing.Size(159, 32);
            this.labelDocument.TabIndex = 67;
            this.labelDocument.Text = "Document: ";
            // 
            // labelSuccess
            // 
            this.labelSuccess.AutoSize = true;
            this.labelSuccess.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSuccess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.labelSuccess.Location = new System.Drawing.Point(156, 1041);
            this.labelSuccess.Name = "labelSuccess";
            this.labelSuccess.Size = new System.Drawing.Size(0, 39);
            this.labelSuccess.TabIndex = 65;
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(160, 1069);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(0, 39);
            this.labelError.TabIndex = 64;
            // 
            // labelModifyTeacherTitle
            // 
            this.labelModifyTeacherTitle.AutoSize = true;
            this.labelModifyTeacherTitle.Font = new System.Drawing.Font("Verdana", 14.1F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelModifyTeacherTitle.Location = new System.Drawing.Point(107, 84);
            this.labelModifyTeacherTitle.Name = "labelModifyTeacherTitle";
            this.labelModifyTeacherTitle.Size = new System.Drawing.Size(386, 59);
            this.labelModifyTeacherTitle.TabIndex = 55;
            this.labelModifyTeacherTitle.Text = "Modify Teacher";
            // 
            // labelTeacherName
            // 
            this.labelTeacherName.AutoSize = true;
            this.labelTeacherName.Location = new System.Drawing.Point(324, 324);
            this.labelTeacherName.Name = "labelTeacherName";
            this.labelTeacherName.Size = new System.Drawing.Size(105, 32);
            this.labelTeacherName.TabIndex = 56;
            this.labelTeacherName.Text = "Name: ";
            // 
            // labelTeacherLastName
            // 
            this.labelTeacherLastName.AutoSize = true;
            this.labelTeacherLastName.Location = new System.Drawing.Point(263, 418);
            this.labelTeacherLastName.Name = "labelTeacherLastName";
            this.labelTeacherLastName.Size = new System.Drawing.Size(166, 32);
            this.labelTeacherLastName.TabIndex = 57;
            this.labelTeacherLastName.Text = "Last Name: ";
            // 
            // textBoxTeacherName
            // 
            this.textBoxTeacherName.Location = new System.Drawing.Point(477, 321);
            this.textBoxTeacherName.MaxLength = 50;
            this.textBoxTeacherName.Name = "textBoxTeacherName";
            this.textBoxTeacherName.Size = new System.Drawing.Size(472, 38);
            this.textBoxTeacherName.TabIndex = 2;
            this.textBoxTeacherName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxes_KeyDown);
            // 
            // textBoxTeacherLastName
            // 
            this.textBoxTeacherLastName.Location = new System.Drawing.Point(477, 415);
            this.textBoxTeacherLastName.MaxLength = 50;
            this.textBoxTeacherLastName.Name = "textBoxTeacherLastName";
            this.textBoxTeacherLastName.Size = new System.Drawing.Size(472, 38);
            this.textBoxTeacherLastName.TabIndex = 3;
            this.textBoxTeacherLastName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxes_KeyDown);
            // 
            // buttonModifyTeacher
            // 
            this.buttonModifyTeacher.Location = new System.Drawing.Point(1496, 1041);
            this.buttonModifyTeacher.Name = "buttonModifyTeacher";
            this.buttonModifyTeacher.Size = new System.Drawing.Size(265, 60);
            this.buttonModifyTeacher.TabIndex = 60;
            this.buttonModifyTeacher.Text = "Modify";
            this.buttonModifyTeacher.UseVisualStyleBackColor = true;
            this.buttonModifyTeacher.Click += new System.EventHandler(this.buttonModifyTeacher_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(1104, 1041);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(265, 60);
            this.buttonCancel.TabIndex = 61;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // listBoxSystemSubjects
            // 
            this.listBoxSystemSubjects.FormattingEnabled = true;
            this.listBoxSystemSubjects.ItemHeight = 31;
            this.listBoxSystemSubjects.Location = new System.Drawing.Point(163, 615);
            this.listBoxSystemSubjects.Name = "listBoxSystemSubjects";
            this.listBoxSystemSubjects.Size = new System.Drawing.Size(694, 252);
            this.listBoxSystemSubjects.TabIndex = 74;
            // 
            // labelSubjectsToBeTeach
            // 
            this.labelSubjectsToBeTeach.AutoSize = true;
            this.labelSubjectsToBeTeach.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubjectsToBeTeach.Location = new System.Drawing.Point(1070, 569);
            this.labelSubjectsToBeTeach.Name = "labelSubjectsToBeTeach";
            this.labelSubjectsToBeTeach.Size = new System.Drawing.Size(300, 36);
            this.labelSubjectsToBeTeach.TabIndex = 73;
            this.labelSubjectsToBeTeach.Text = "Subjects to be teach: ";
            // 
            // labelSystemSubjects
            // 
            this.labelSystemSubjects.AutoSize = true;
            this.labelSystemSubjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSystemSubjects.Location = new System.Drawing.Point(160, 569);
            this.labelSystemSubjects.Name = "labelSystemSubjects";
            this.labelSystemSubjects.Size = new System.Drawing.Size(271, 36);
            this.labelSystemSubjects.TabIndex = 72;
            this.labelSystemSubjects.Text = "Available subjects: ";
            // 
            // buttonRemoveSubjectFromTeacher
            // 
            this.buttonRemoveSubjectFromTeacher.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemoveSubjectFromTeacher.Location = new System.Drawing.Point(917, 760);
            this.buttonRemoveSubjectFromTeacher.Name = "buttonRemoveSubjectFromTeacher";
            this.buttonRemoveSubjectFromTeacher.Size = new System.Drawing.Size(100, 50);
            this.buttonRemoveSubjectFromTeacher.TabIndex = 71;
            this.buttonRemoveSubjectFromTeacher.Text = "<<";
            this.buttonRemoveSubjectFromTeacher.UseVisualStyleBackColor = true;
            this.buttonRemoveSubjectFromTeacher.Click += new System.EventHandler(this.buttonRemoveSubjectFromTeacher_Click);
            // 
            // buttonAddSubjectToTeacher
            // 
            this.buttonAddSubjectToTeacher.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddSubjectToTeacher.Location = new System.Drawing.Point(917, 672);
            this.buttonAddSubjectToTeacher.Name = "buttonAddSubjectToTeacher";
            this.buttonAddSubjectToTeacher.Size = new System.Drawing.Size(100, 50);
            this.buttonAddSubjectToTeacher.TabIndex = 70;
            this.buttonAddSubjectToTeacher.Text = ">>";
            this.buttonAddSubjectToTeacher.UseVisualStyleBackColor = true;
            this.buttonAddSubjectToTeacher.Click += new System.EventHandler(this.buttonAddSubjectToTeacher_Click);
            // 
            // listBoxTeacherSubjects
            // 
            this.listBoxTeacherSubjects.FormattingEnabled = true;
            this.listBoxTeacherSubjects.ItemHeight = 31;
            this.listBoxTeacherSubjects.Location = new System.Drawing.Point(1067, 615);
            this.listBoxTeacherSubjects.Name = "listBoxTeacherSubjects";
            this.listBoxTeacherSubjects.Size = new System.Drawing.Size(694, 252);
            this.listBoxTeacherSubjects.TabIndex = 69;
            // 
            // comboBoxTeachersDocuments
            // 
            this.comboBoxTeachersDocuments.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTeachersDocuments.FormattingEnabled = true;
            this.comboBoxTeachersDocuments.Location = new System.Drawing.Point(477, 235);
            this.comboBoxTeachersDocuments.Name = "comboBoxTeachersDocuments";
            this.comboBoxTeachersDocuments.Size = new System.Drawing.Size(472, 39);
            this.comboBoxTeachersDocuments.TabIndex = 1;
            this.comboBoxTeachersDocuments.SelectedIndexChanged += new System.EventHandler(this.comboBoxTeachersDocuments_SelectedIndexChanged);
            // 
            // ModifyTeacherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1868, 1192);
            this.Controls.Add(this.comboBoxTeachersDocuments);
            this.Controls.Add(this.listBoxSystemSubjects);
            this.Controls.Add(this.labelSubjectsToBeTeach);
            this.Controls.Add(this.labelSystemSubjects);
            this.Controls.Add(this.buttonRemoveSubjectFromTeacher);
            this.Controls.Add(this.buttonAddSubjectToTeacher);
            this.Controls.Add(this.listBoxTeacherSubjects);
            this.Controls.Add(this.labelDocument);
            this.Controls.Add(this.labelSuccess);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.labelModifyTeacherTitle);
            this.Controls.Add(this.labelTeacherName);
            this.Controls.Add(this.labelTeacherLastName);
            this.Controls.Add(this.textBoxTeacherName);
            this.Controls.Add(this.textBoxTeacherLastName);
            this.Controls.Add(this.buttonModifyTeacher);
            this.Controls.Add(this.buttonCancel);
            this.Name = "ModifyTeacherForm";
            this.Text = "Modify Teacher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDocument;
        private System.Windows.Forms.Label labelSuccess;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.Label labelModifyTeacherTitle;
        private System.Windows.Forms.Label labelTeacherName;
        private System.Windows.Forms.Label labelTeacherLastName;
        private System.Windows.Forms.TextBox textBoxTeacherName;
        private System.Windows.Forms.TextBox textBoxTeacherLastName;
        private System.Windows.Forms.Button buttonModifyTeacher;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ListBox listBoxSystemSubjects;
        private System.Windows.Forms.Label labelSubjectsToBeTeach;
        private System.Windows.Forms.Label labelSystemSubjects;
        private System.Windows.Forms.Button buttonRemoveSubjectFromTeacher;
        private System.Windows.Forms.Button buttonAddSubjectToTeacher;
        private System.Windows.Forms.ListBox listBoxTeacherSubjects;
        private System.Windows.Forms.ComboBox comboBoxTeachersDocuments;
    }
}