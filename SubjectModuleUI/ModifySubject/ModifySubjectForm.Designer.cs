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
            this.comboBoxSelectSubjectToModify = new System.Windows.Forms.ComboBox();
            this.labelSelectSubjectToModify = new System.Windows.Forms.Label();
            this.textBoxNameModifySubject = new System.Windows.Forms.TextBox();
            this.textBoxCodeModifySubject = new System.Windows.Forms.TextBox();
            this.labelCodeModifySubject = new System.Windows.Forms.Label();
            this.labelNameModifySubject = new System.Windows.Forms.Label();
            this.buttonModifySubject = new System.Windows.Forms.Button();
            this.buttonCancelModifySubject = new System.Windows.Forms.Button();
            this.labelError = new System.Windows.Forms.Label();
            this.listBoxSystemTeachers = new System.Windows.Forms.ListBox();
            this.listBoxSubjectTeachers = new System.Windows.Forms.ListBox();
            this.buttonAddTeacherToSubject = new System.Windows.Forms.Button();
            this.buttonDeleteTeacherToSubject = new System.Windows.Forms.Button();
            this.labelAvailableTeachers = new System.Windows.Forms.Label();
            this.labelSubjectTeachers = new System.Windows.Forms.Label();
            this.listBoxSystemStudents = new System.Windows.Forms.ListBox();
            this.listBoxSubjectStudents = new System.Windows.Forms.ListBox();
            this.labelAvailableStudents = new System.Windows.Forms.Label();
            this.labelSubjectStudents = new System.Windows.Forms.Label();
            this.buttonAddStudentToSubject = new System.Windows.Forms.Button();
            this.buttonDeleteStudentToSubject = new System.Windows.Forms.Button();
            this.labelSuccess = new System.Windows.Forms.Label();
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
            // comboBoxSelectSubjectToModify
            // 
            this.comboBoxSelectSubjectToModify.FormattingEnabled = true;
            this.comboBoxSelectSubjectToModify.Location = new System.Drawing.Point(16, 68);
            this.comboBoxSelectSubjectToModify.Name = "comboBoxSelectSubjectToModify";
            this.comboBoxSelectSubjectToModify.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSelectSubjectToModify.TabIndex = 1;
            this.comboBoxSelectSubjectToModify.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelectSubjectToModify_SelectedIndexChanged);
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
            this.textBoxNameModifySubject.Location = new System.Drawing.Point(16, 181);
            this.textBoxNameModifySubject.Name = "textBoxNameModifySubject";
            this.textBoxNameModifySubject.Size = new System.Drawing.Size(100, 20);
            this.textBoxNameModifySubject.TabIndex = 3;
            // 
            // textBoxCodeModifySubject
            // 
            this.textBoxCodeModifySubject.Location = new System.Drawing.Point(16, 123);
            this.textBoxCodeModifySubject.Name = "textBoxCodeModifySubject";
            this.textBoxCodeModifySubject.Size = new System.Drawing.Size(100, 20);
            this.textBoxCodeModifySubject.TabIndex = 2;
            // 
            // labelCodeModifySubject
            // 
            this.labelCodeModifySubject.AutoSize = true;
            this.labelCodeModifySubject.Location = new System.Drawing.Point(16, 104);
            this.labelCodeModifySubject.Name = "labelCodeModifySubject";
            this.labelCodeModifySubject.Size = new System.Drawing.Size(32, 13);
            this.labelCodeModifySubject.TabIndex = 5;
            this.labelCodeModifySubject.Text = "Code";
            // 
            // labelNameModifySubject
            // 
            this.labelNameModifySubject.AutoSize = true;
            this.labelNameModifySubject.Location = new System.Drawing.Point(16, 161);
            this.labelNameModifySubject.Name = "labelNameModifySubject";
            this.labelNameModifySubject.Size = new System.Drawing.Size(35, 13);
            this.labelNameModifySubject.TabIndex = 6;
            this.labelNameModifySubject.Text = "Name";
            // 
            // buttonModifySubject
            // 
            this.buttonModifySubject.Location = new System.Drawing.Point(471, 523);
            this.buttonModifySubject.Name = "buttonModifySubject";
            this.buttonModifySubject.Size = new System.Drawing.Size(75, 23);
            this.buttonModifySubject.TabIndex = 12;
            this.buttonModifySubject.Text = "Modify";
            this.buttonModifySubject.UseVisualStyleBackColor = true;
            this.buttonModifySubject.Click += new System.EventHandler(this.buttonModifySubject_Click);
            // 
            // buttonCancelModifySubject
            // 
            this.buttonCancelModifySubject.Location = new System.Drawing.Point(346, 523);
            this.buttonCancelModifySubject.Name = "buttonCancelModifySubject";
            this.buttonCancelModifySubject.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelModifySubject.TabIndex = 13;
            this.buttonCancelModifySubject.Text = "Cancel";
            this.buttonCancelModifySubject.UseVisualStyleBackColor = true;
            this.buttonCancelModifySubject.Click += new System.EventHandler(this.buttonCancelModifySubject_Click);
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(219, 111);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(0, 16);
            this.labelError.TabIndex = 9;
            this.labelError.Visible = false;
            // 
            // listBoxSystemTeachers
            // 
            this.listBoxSystemTeachers.FormattingEnabled = true;
            this.listBoxSystemTeachers.Location = new System.Drawing.Point(18, 238);
            this.listBoxSystemTeachers.Name = "listBoxSystemTeachers";
            this.listBoxSystemTeachers.Size = new System.Drawing.Size(200, 95);
            this.listBoxSystemTeachers.TabIndex = 4;
            // 
            // listBoxSubjectTeachers
            // 
            this.listBoxSubjectTeachers.FormattingEnabled = true;
            this.listBoxSubjectTeachers.Location = new System.Drawing.Point(346, 238);
            this.listBoxSubjectTeachers.Name = "listBoxSubjectTeachers";
            this.listBoxSubjectTeachers.Size = new System.Drawing.Size(200, 95);
            this.listBoxSubjectTeachers.TabIndex = 5;
            // 
            // buttonAddTeacherToSubject
            // 
            this.buttonAddTeacherToSubject.Location = new System.Drawing.Point(262, 264);
            this.buttonAddTeacherToSubject.Name = "buttonAddTeacherToSubject";
            this.buttonAddTeacherToSubject.Size = new System.Drawing.Size(38, 21);
            this.buttonAddTeacherToSubject.TabIndex = 6;
            this.buttonAddTeacherToSubject.Text = ">>";
            this.buttonAddTeacherToSubject.UseVisualStyleBackColor = true;
            this.buttonAddTeacherToSubject.Click += new System.EventHandler(this.buttonAddTeacherToSubject_Click);
            // 
            // buttonDeleteTeacherToSubject
            // 
            this.buttonDeleteTeacherToSubject.Location = new System.Drawing.Point(262, 291);
            this.buttonDeleteTeacherToSubject.Name = "buttonDeleteTeacherToSubject";
            this.buttonDeleteTeacherToSubject.Size = new System.Drawing.Size(38, 21);
            this.buttonDeleteTeacherToSubject.TabIndex = 7;
            this.buttonDeleteTeacherToSubject.Text = "<<";
            this.buttonDeleteTeacherToSubject.UseVisualStyleBackColor = true;
            this.buttonDeleteTeacherToSubject.Click += new System.EventHandler(this.buttonDeleteTeacherToSubject_Click);
            // 
            // labelAvailableTeachers
            // 
            this.labelAvailableTeachers.AutoSize = true;
            this.labelAvailableTeachers.Location = new System.Drawing.Point(15, 222);
            this.labelAvailableTeachers.Name = "labelAvailableTeachers";
            this.labelAvailableTeachers.Size = new System.Drawing.Size(98, 13);
            this.labelAvailableTeachers.TabIndex = 14;
            this.labelAvailableTeachers.Text = "Available Teachers";
            // 
            // labelSubjectTeachers
            // 
            this.labelSubjectTeachers.AutoSize = true;
            this.labelSubjectTeachers.Location = new System.Drawing.Point(346, 221);
            this.labelSubjectTeachers.Name = "labelSubjectTeachers";
            this.labelSubjectTeachers.Size = new System.Drawing.Size(159, 13);
            this.labelSubjectTeachers.TabIndex = 15;
            this.labelSubjectTeachers.Text = "Current Teachers of this Subject";
            // 
            // listBoxSystemStudents
            // 
            this.listBoxSystemStudents.FormattingEnabled = true;
            this.listBoxSystemStudents.Location = new System.Drawing.Point(19, 376);
            this.listBoxSystemStudents.Name = "listBoxSystemStudents";
            this.listBoxSystemStudents.Size = new System.Drawing.Size(199, 95);
            this.listBoxSystemStudents.TabIndex = 8;
            // 
            // listBoxSubjectStudents
            // 
            this.listBoxSubjectStudents.FormattingEnabled = true;
            this.listBoxSubjectStudents.Location = new System.Drawing.Point(346, 376);
            this.listBoxSubjectStudents.Name = "listBoxSubjectStudents";
            this.listBoxSubjectStudents.Size = new System.Drawing.Size(200, 95);
            this.listBoxSubjectStudents.TabIndex = 9;
            // 
            // labelAvailableStudents
            // 
            this.labelAvailableStudents.AutoSize = true;
            this.labelAvailableStudents.Location = new System.Drawing.Point(19, 357);
            this.labelAvailableStudents.Name = "labelAvailableStudents";
            this.labelAvailableStudents.Size = new System.Drawing.Size(95, 13);
            this.labelAvailableStudents.TabIndex = 18;
            this.labelAvailableStudents.Text = "Available Students";
            // 
            // labelSubjectStudents
            // 
            this.labelSubjectStudents.AutoSize = true;
            this.labelSubjectStudents.Location = new System.Drawing.Point(346, 357);
            this.labelSubjectStudents.Name = "labelSubjectStudents";
            this.labelSubjectStudents.Size = new System.Drawing.Size(156, 13);
            this.labelSubjectStudents.TabIndex = 19;
            this.labelSubjectStudents.Text = "Current Students of this Subject";
            // 
            // buttonAddStudentToSubject
            // 
            this.buttonAddStudentToSubject.Location = new System.Drawing.Point(262, 399);
            this.buttonAddStudentToSubject.Name = "buttonAddStudentToSubject";
            this.buttonAddStudentToSubject.Size = new System.Drawing.Size(38, 21);
            this.buttonAddStudentToSubject.TabIndex = 10;
            this.buttonAddStudentToSubject.Text = ">>";
            this.buttonAddStudentToSubject.UseVisualStyleBackColor = true;
            this.buttonAddStudentToSubject.Click += new System.EventHandler(this.buttonAddStudentToSubject_Click);
            // 
            // buttonDeleteStudentToSubject
            // 
            this.buttonDeleteStudentToSubject.Location = new System.Drawing.Point(262, 427);
            this.buttonDeleteStudentToSubject.Name = "buttonDeleteStudentToSubject";
            this.buttonDeleteStudentToSubject.Size = new System.Drawing.Size(38, 21);
            this.buttonDeleteStudentToSubject.TabIndex = 11;
            this.buttonDeleteStudentToSubject.Text = "<<";
            this.buttonDeleteStudentToSubject.UseVisualStyleBackColor = true;
            this.buttonDeleteStudentToSubject.Click += new System.EventHandler(this.buttonDeleteStudentToSubject_Click);
            // 
            // labelSuccess
            // 
            this.labelSuccess.AutoSize = true;
            this.labelSuccess.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSuccess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.labelSuccess.Location = new System.Drawing.Point(222, 111);
            this.labelSuccess.Name = "labelSuccess";
            this.labelSuccess.Size = new System.Drawing.Size(0, 16);
            this.labelSuccess.TabIndex = 22;
            // 
            // ModifySubjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 568);
            this.Controls.Add(this.labelSuccess);
            this.Controls.Add(this.buttonDeleteStudentToSubject);
            this.Controls.Add(this.buttonAddStudentToSubject);
            this.Controls.Add(this.labelSubjectStudents);
            this.Controls.Add(this.labelAvailableStudents);
            this.Controls.Add(this.listBoxSubjectStudents);
            this.Controls.Add(this.listBoxSystemStudents);
            this.Controls.Add(this.labelSubjectTeachers);
            this.Controls.Add(this.labelAvailableTeachers);
            this.Controls.Add(this.buttonDeleteTeacherToSubject);
            this.Controls.Add(this.buttonAddTeacherToSubject);
            this.Controls.Add(this.listBoxSubjectTeachers);
            this.Controls.Add(this.listBoxSystemTeachers);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.buttonCancelModifySubject);
            this.Controls.Add(this.buttonModifySubject);
            this.Controls.Add(this.labelNameModifySubject);
            this.Controls.Add(this.labelCodeModifySubject);
            this.Controls.Add(this.textBoxCodeModifySubject);
            this.Controls.Add(this.textBoxNameModifySubject);
            this.Controls.Add(this.labelSelectSubjectToModify);
            this.Controls.Add(this.comboBoxSelectSubjectToModify);
            this.Controls.Add(this.labelModifySubjectTitle);
            this.Name = "ModifySubjectForm";
            this.Text = "ModifySubjectForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelModifySubjectTitle;
        private System.Windows.Forms.ComboBox comboBoxSelectSubjectToModify;
        private System.Windows.Forms.Label labelSelectSubjectToModify;
        private System.Windows.Forms.TextBox textBoxNameModifySubject;
        private System.Windows.Forms.TextBox textBoxCodeModifySubject;
        private System.Windows.Forms.Label labelCodeModifySubject;
        private System.Windows.Forms.Label labelNameModifySubject;
        private System.Windows.Forms.Button buttonModifySubject;
        private System.Windows.Forms.Button buttonCancelModifySubject;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.ListBox listBoxSystemTeachers;
        private System.Windows.Forms.ListBox listBoxSubjectTeachers;
        private System.Windows.Forms.Button buttonAddTeacherToSubject;
        private System.Windows.Forms.Button buttonDeleteTeacherToSubject;
        private System.Windows.Forms.Label labelAvailableTeachers;
        private System.Windows.Forms.Label labelSubjectTeachers;
        private System.Windows.Forms.ListBox listBoxSystemStudents;
        private System.Windows.Forms.ListBox listBoxSubjectStudents;
        private System.Windows.Forms.Label labelAvailableStudents;
        private System.Windows.Forms.Label labelSubjectStudents;
        private System.Windows.Forms.Button buttonAddStudentToSubject;
        private System.Windows.Forms.Button buttonDeleteStudentToSubject;
        private System.Windows.Forms.Label labelSuccess;
    }
}