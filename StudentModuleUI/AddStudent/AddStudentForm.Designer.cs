namespace StudentModuleUI.AddStudent
{
    partial class AddStudentForm
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
            this.listBoxSystemSubjects = new System.Windows.Forms.ListBox();
            this.labelSuccess = new System.Windows.Forms.Label();
            this.labelError = new System.Windows.Forms.Label();
            this.labelSubjectsToBeAdded = new System.Windows.Forms.Label();
            this.labelSystemSubjects = new System.Windows.Forms.Label();
            this.buttonRemoveSubjectFromStudent = new System.Windows.Forms.Button();
            this.buttonAddSubjectToStudent = new System.Windows.Forms.Button();
            this.listBoxStudentSubjects = new System.Windows.Forms.ListBox();
            this.labelAddStudentTitle = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelLastName = new System.Windows.Forms.Label();
            this.labelDocument = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.textBoxDocument = new System.Windows.Forms.TextBox();
            this.buttonAddStudent = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelStudentNumber = new System.Windows.Forms.Label();
            this.textBoxStudentNumber = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listBoxSystemSubjects
            // 
            this.listBoxSystemSubjects.FormattingEnabled = true;
            this.listBoxSystemSubjects.ItemHeight = 31;
            this.listBoxSystemSubjects.Location = new System.Drawing.Point(163, 611);
            this.listBoxSystemSubjects.Name = "listBoxSystemSubjects";
            this.listBoxSystemSubjects.Size = new System.Drawing.Size(694, 252);
            this.listBoxSystemSubjects.TabIndex = 52;
            // 
            // labelSuccess
            // 
            this.labelSuccess.AutoSize = true;
            this.labelSuccess.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSuccess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.labelSuccess.Location = new System.Drawing.Point(156, 1041);
            this.labelSuccess.Name = "labelSuccess";
            this.labelSuccess.Size = new System.Drawing.Size(0, 39);
            this.labelSuccess.TabIndex = 51;
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(160, 1069);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(0, 39);
            this.labelError.TabIndex = 50;
            // 
            // labelSubjectsToBeAdded
            // 
            this.labelSubjectsToBeAdded.AutoSize = true;
            this.labelSubjectsToBeAdded.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubjectsToBeAdded.Location = new System.Drawing.Point(1070, 565);
            this.labelSubjectsToBeAdded.Name = "labelSubjectsToBeAdded";
            this.labelSubjectsToBeAdded.Size = new System.Drawing.Size(300, 36);
            this.labelSubjectsToBeAdded.TabIndex = 49;
            this.labelSubjectsToBeAdded.Text = "Subjects to be teach: ";
            // 
            // labelSystemSubjects
            // 
            this.labelSystemSubjects.AutoSize = true;
            this.labelSystemSubjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSystemSubjects.Location = new System.Drawing.Point(160, 565);
            this.labelSystemSubjects.Name = "labelSystemSubjects";
            this.labelSystemSubjects.Size = new System.Drawing.Size(271, 36);
            this.labelSystemSubjects.TabIndex = 48;
            this.labelSystemSubjects.Text = "Available subjects: ";
            // 
            // buttonRemoveSubjectFromStudent
            // 
            this.buttonRemoveSubjectFromStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemoveSubjectFromStudent.Location = new System.Drawing.Point(917, 756);
            this.buttonRemoveSubjectFromStudent.Name = "buttonRemoveSubjectFromStudent";
            this.buttonRemoveSubjectFromStudent.Size = new System.Drawing.Size(100, 50);
            this.buttonRemoveSubjectFromStudent.TabIndex = 47;
            this.buttonRemoveSubjectFromStudent.Text = "<<";
            this.buttonRemoveSubjectFromStudent.UseVisualStyleBackColor = true;
            this.buttonRemoveSubjectFromStudent.Click += new System.EventHandler(this.buttonRemoveSubjectFromStudent_Click);
            // 
            // buttonAddSubjectToStudent
            // 
            this.buttonAddSubjectToStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddSubjectToStudent.Location = new System.Drawing.Point(917, 668);
            this.buttonAddSubjectToStudent.Name = "buttonAddSubjectToStudent";
            this.buttonAddSubjectToStudent.Size = new System.Drawing.Size(100, 50);
            this.buttonAddSubjectToStudent.TabIndex = 46;
            this.buttonAddSubjectToStudent.Text = ">>";
            this.buttonAddSubjectToStudent.UseVisualStyleBackColor = true;
            this.buttonAddSubjectToStudent.Click += new System.EventHandler(this.buttonAddSubjectToStudent_Click);
            // 
            // listBoxStudentSubjects
            // 
            this.listBoxStudentSubjects.FormattingEnabled = true;
            this.listBoxStudentSubjects.ItemHeight = 31;
            this.listBoxStudentSubjects.Location = new System.Drawing.Point(1067, 611);
            this.listBoxStudentSubjects.Name = "listBoxStudentSubjects";
            this.listBoxStudentSubjects.Size = new System.Drawing.Size(694, 252);
            this.listBoxStudentSubjects.TabIndex = 45;
            // 
            // labelAddStudentTitle
            // 
            this.labelAddStudentTitle.AutoSize = true;
            this.labelAddStudentTitle.Font = new System.Drawing.Font("Verdana", 14.1F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAddStudentTitle.Location = new System.Drawing.Point(107, 84);
            this.labelAddStudentTitle.Name = "labelAddStudentTitle";
            this.labelAddStudentTitle.Size = new System.Drawing.Size(325, 59);
            this.labelAddStudentTitle.TabIndex = 36;
            this.labelAddStudentTitle.Text = "Add Student";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(324, 370);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(105, 32);
            this.labelName.TabIndex = 37;
            this.labelName.Text = "Name: ";
            // 
            // labelLastName
            // 
            this.labelLastName.AutoSize = true;
            this.labelLastName.Location = new System.Drawing.Point(263, 439);
            this.labelLastName.Name = "labelLastName";
            this.labelLastName.Size = new System.Drawing.Size(166, 32);
            this.labelLastName.TabIndex = 38;
            this.labelLastName.Text = "Last Name: ";
            // 
            // labelDocument
            // 
            this.labelDocument.AutoSize = true;
            this.labelDocument.Location = new System.Drawing.Point(270, 298);
            this.labelDocument.Name = "labelDocument";
            this.labelDocument.Size = new System.Drawing.Size(159, 32);
            this.labelDocument.TabIndex = 39;
            this.labelDocument.Text = "Document: ";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(477, 367);
            this.textBoxName.MaxLength = 50;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(380, 38);
            this.textBoxName.TabIndex = 40;
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Location = new System.Drawing.Point(477, 436);
            this.textBoxLastName.MaxLength = 50;
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(380, 38);
            this.textBoxLastName.TabIndex = 41;
            // 
            // textBoxDocument
            // 
            this.textBoxDocument.Location = new System.Drawing.Point(477, 295);
            this.textBoxDocument.MaxLength = 9;
            this.textBoxDocument.Name = "textBoxDocument";
            this.textBoxDocument.Size = new System.Drawing.Size(380, 38);
            this.textBoxDocument.TabIndex = 42;
            // 
            // buttonAddStudent
            // 
            this.buttonAddStudent.Location = new System.Drawing.Point(1496, 1041);
            this.buttonAddStudent.Name = "buttonAddStudent";
            this.buttonAddStudent.Size = new System.Drawing.Size(265, 60);
            this.buttonAddStudent.TabIndex = 43;
            this.buttonAddStudent.Text = "Add";
            this.buttonAddStudent.UseVisualStyleBackColor = true;
            this.buttonAddStudent.Click += new System.EventHandler(this.buttonAddStudent_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(1146, 1041);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(265, 60);
            this.buttonCancel.TabIndex = 44;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelStudentNumber
            // 
            this.labelStudentNumber.AutoSize = true;
            this.labelStudentNumber.Location = new System.Drawing.Point(197, 224);
            this.labelStudentNumber.Name = "labelStudentNumber";
            this.labelStudentNumber.Size = new System.Drawing.Size(232, 32);
            this.labelStudentNumber.TabIndex = 53;
            this.labelStudentNumber.Text = "Student number: ";
            // 
            // textBoxStudentNumber
            // 
            this.textBoxStudentNumber.Enabled = false;
            this.textBoxStudentNumber.Location = new System.Drawing.Point(477, 224);
            this.textBoxStudentNumber.MaxLength = 50;
            this.textBoxStudentNumber.Name = "textBoxStudentNumber";
            this.textBoxStudentNumber.Size = new System.Drawing.Size(380, 38);
            this.textBoxStudentNumber.TabIndex = 54;
            // 
            // AddStudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1868, 1192);
            this.Controls.Add(this.textBoxStudentNumber);
            this.Controls.Add(this.labelStudentNumber);
            this.Controls.Add(this.listBoxSystemSubjects);
            this.Controls.Add(this.labelSuccess);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.labelSubjectsToBeAdded);
            this.Controls.Add(this.labelSystemSubjects);
            this.Controls.Add(this.buttonRemoveSubjectFromStudent);
            this.Controls.Add(this.buttonAddSubjectToStudent);
            this.Controls.Add(this.listBoxStudentSubjects);
            this.Controls.Add(this.labelAddStudentTitle);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelLastName);
            this.Controls.Add(this.labelDocument);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.textBoxLastName);
            this.Controls.Add(this.textBoxDocument);
            this.Controls.Add(this.buttonAddStudent);
            this.Controls.Add(this.buttonCancel);
            this.Name = "AddStudentForm";
            this.Text = "Add Student";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxSystemSubjects;
        private System.Windows.Forms.Label labelSuccess;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.Label labelSubjectsToBeAdded;
        private System.Windows.Forms.Label labelSystemSubjects;
        private System.Windows.Forms.Button buttonRemoveSubjectFromStudent;
        private System.Windows.Forms.Button buttonAddSubjectToStudent;
        private System.Windows.Forms.ListBox listBoxStudentSubjects;
        private System.Windows.Forms.Label labelAddStudentTitle;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelLastName;
        private System.Windows.Forms.Label labelDocument;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.TextBox textBoxDocument;
        private System.Windows.Forms.Button buttonAddStudent;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelStudentNumber;
        private System.Windows.Forms.TextBox textBoxStudentNumber;
    }
}