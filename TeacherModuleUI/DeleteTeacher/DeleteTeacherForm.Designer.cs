namespace TeacherModuleUI.DeleteTeacher
{
    partial class DeleteTeacherForm
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
            this.labelSuccess = new System.Windows.Forms.Label();
            this.labelError = new System.Windows.Forms.Label();
            this.labelTeacherSubjects = new System.Windows.Forms.Label();
            this.listBoxTeacherSubjects = new System.Windows.Forms.ListBox();
            this.labelDeleteTeacherTitle = new System.Windows.Forms.Label();
            this.labelTeacherName = new System.Windows.Forms.Label();
            this.labelTeacherLastName = new System.Windows.Forms.Label();
            this.textBoxTeacherName = new System.Windows.Forms.TextBox();
            this.textBoxTeacherLastName = new System.Windows.Forms.TextBox();
            this.buttonDeleteTeacher = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.labelDocument = new System.Windows.Forms.Label();
            this.textBoxTeacherDocument = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
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
            // labelTeacherSubjects
            // 
            this.labelTeacherSubjects.AutoSize = true;
            this.labelTeacherSubjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTeacherSubjects.Location = new System.Drawing.Point(160, 565);
            this.labelTeacherSubjects.Name = "labelTeacherSubjects";
            this.labelTeacherSubjects.Size = new System.Drawing.Size(257, 36);
            this.labelTeacherSubjects.TabIndex = 48;
            this.labelTeacherSubjects.Text = "Teacher subjects: ";
            // 
            // listBoxTeacherSubjects
            // 
            this.listBoxTeacherSubjects.Enabled = false;
            this.listBoxTeacherSubjects.FormattingEnabled = true;
            this.listBoxTeacherSubjects.ItemHeight = 31;
            this.listBoxTeacherSubjects.Location = new System.Drawing.Point(163, 611);
            this.listBoxTeacherSubjects.Name = "listBoxTeacherSubjects";
            this.listBoxTeacherSubjects.Size = new System.Drawing.Size(694, 252);
            this.listBoxTeacherSubjects.TabIndex = 44;
            // 
            // labelDeleteTeacherTitle
            // 
            this.labelDeleteTeacherTitle.AutoSize = true;
            this.labelDeleteTeacherTitle.Font = new System.Drawing.Font("Verdana", 14.1F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDeleteTeacherTitle.Location = new System.Drawing.Point(107, 84);
            this.labelDeleteTeacherTitle.Name = "labelDeleteTeacherTitle";
            this.labelDeleteTeacherTitle.Size = new System.Drawing.Size(385, 59);
            this.labelDeleteTeacherTitle.TabIndex = 35;
            this.labelDeleteTeacherTitle.Text = "Delete Teacher";
            // 
            // labelTeacherName
            // 
            this.labelTeacherName.AutoSize = true;
            this.labelTeacherName.Location = new System.Drawing.Point(324, 328);
            this.labelTeacherName.Name = "labelTeacherName";
            this.labelTeacherName.Size = new System.Drawing.Size(105, 32);
            this.labelTeacherName.TabIndex = 36;
            this.labelTeacherName.Text = "Name: ";
            // 
            // labelTeacherLastName
            // 
            this.labelTeacherLastName.AutoSize = true;
            this.labelTeacherLastName.Location = new System.Drawing.Point(263, 418);
            this.labelTeacherLastName.Name = "labelTeacherLastName";
            this.labelTeacherLastName.Size = new System.Drawing.Size(166, 32);
            this.labelTeacherLastName.TabIndex = 37;
            this.labelTeacherLastName.Text = "Last Name: ";
            // 
            // textBoxTeacherName
            // 
            this.textBoxTeacherName.Enabled = false;
            this.textBoxTeacherName.Location = new System.Drawing.Point(477, 325);
            this.textBoxTeacherName.MaxLength = 50;
            this.textBoxTeacherName.Name = "textBoxTeacherName";
            this.textBoxTeacherName.Size = new System.Drawing.Size(380, 38);
            this.textBoxTeacherName.TabIndex = 39;
            // 
            // textBoxTeacherLastName
            // 
            this.textBoxTeacherLastName.Enabled = false;
            this.textBoxTeacherLastName.Location = new System.Drawing.Point(477, 415);
            this.textBoxTeacherLastName.MaxLength = 50;
            this.textBoxTeacherLastName.Name = "textBoxTeacherLastName";
            this.textBoxTeacherLastName.Size = new System.Drawing.Size(380, 38);
            this.textBoxTeacherLastName.TabIndex = 40;
            // 
            // buttonDeleteTeacher
            // 
            this.buttonDeleteTeacher.Location = new System.Drawing.Point(1496, 1041);
            this.buttonDeleteTeacher.Name = "buttonDeleteTeacher";
            this.buttonDeleteTeacher.Size = new System.Drawing.Size(265, 60);
            this.buttonDeleteTeacher.TabIndex = 42;
            this.buttonDeleteTeacher.Text = "Delete";
            this.buttonDeleteTeacher.UseVisualStyleBackColor = true;
            this.buttonDeleteTeacher.Click += new System.EventHandler(this.buttonDeleteTeacher_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(1104, 1041);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(265, 60);
            this.buttonCancel.TabIndex = 43;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(918, 224);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(265, 53);
            this.buttonSearch.TabIndex = 52;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // labelDocument
            // 
            this.labelDocument.AutoSize = true;
            this.labelDocument.Location = new System.Drawing.Point(270, 235);
            this.labelDocument.Name = "labelDocument";
            this.labelDocument.Size = new System.Drawing.Size(159, 32);
            this.labelDocument.TabIndex = 53;
            this.labelDocument.Text = "Document: ";
            // 
            // textBoxTeacherDocument
            // 
            this.textBoxTeacherDocument.Location = new System.Drawing.Point(477, 235);
            this.textBoxTeacherDocument.MaxLength = 9;
            this.textBoxTeacherDocument.Name = "textBoxTeacherDocument";
            this.textBoxTeacherDocument.Size = new System.Drawing.Size(380, 38);
            this.textBoxTeacherDocument.TabIndex = 1;
            this.textBoxTeacherDocument.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxTeacherDocument_KeyDown);
            // 
            // DeleteTeacherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1868, 1192);
            this.Controls.Add(this.labelDocument);
            this.Controls.Add(this.textBoxTeacherDocument);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.labelSuccess);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.labelTeacherSubjects);
            this.Controls.Add(this.listBoxTeacherSubjects);
            this.Controls.Add(this.labelDeleteTeacherTitle);
            this.Controls.Add(this.labelTeacherName);
            this.Controls.Add(this.labelTeacherLastName);
            this.Controls.Add(this.textBoxTeacherName);
            this.Controls.Add(this.textBoxTeacherLastName);
            this.Controls.Add(this.buttonDeleteTeacher);
            this.Controls.Add(this.buttonCancel);
            this.Name = "DeleteTeacherForm";
            this.Text = "Delete Teacher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSuccess;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.Label labelTeacherSubjects;
        private System.Windows.Forms.ListBox listBoxTeacherSubjects;
        private System.Windows.Forms.Label labelDeleteTeacherTitle;
        private System.Windows.Forms.Label labelTeacherName;
        private System.Windows.Forms.Label labelTeacherLastName;
        private System.Windows.Forms.TextBox textBoxTeacherName;
        private System.Windows.Forms.TextBox textBoxTeacherLastName;
        private System.Windows.Forms.Button buttonDeleteTeacher;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Label labelDocument;
        private System.Windows.Forms.TextBox textBoxTeacherDocument;
    }
}