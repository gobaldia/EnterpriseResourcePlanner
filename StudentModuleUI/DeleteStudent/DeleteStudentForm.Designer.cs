namespace StudentModuleUI.DeleteStudent
{
    partial class DeleteStudentForm
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
            this.groupBoxPickUpServiceRadioButtons = new System.Windows.Forms.GroupBox();
            this.radioButtonYesPickUp = new System.Windows.Forms.RadioButton();
            this.radioButtonNoPickUp = new System.Windows.Forms.RadioButton();
            this.labelLongitud = new System.Windows.Forms.Label();
            this.labelLatitud = new System.Windows.Forms.Label();
            this.textBoxLongitud = new System.Windows.Forms.TextBox();
            this.textBoxLatitud = new System.Windows.Forms.TextBox();
            this.labelLocation = new System.Windows.Forms.Label();
            this.labelPickupService = new System.Windows.Forms.Label();
            this.labelStudentNumber = new System.Windows.Forms.Label();
            this.labelSuccess = new System.Windows.Forms.Label();
            this.labelError = new System.Windows.Forms.Label();
            this.labelSubjectsToBeAdded = new System.Windows.Forms.Label();
            this.listBoxStudentSubjects = new System.Windows.Forms.ListBox();
            this.labelDeleteStudentTitle = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelLastName = new System.Windows.Forms.Label();
            this.labelDocument = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.textBoxDocument = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonDeleteStudent = new System.Windows.Forms.Button();
            this.comboBoxStudentsNumbers = new System.Windows.Forms.ComboBox();
            this.groupBoxPickUpServiceRadioButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxPickUpServiceRadioButtons
            // 
            this.groupBoxPickUpServiceRadioButtons.Controls.Add(this.radioButtonYesPickUp);
            this.groupBoxPickUpServiceRadioButtons.Controls.Add(this.radioButtonNoPickUp);
            this.groupBoxPickUpServiceRadioButtons.Location = new System.Drawing.Point(1250, 271);
            this.groupBoxPickUpServiceRadioButtons.Name = "groupBoxPickUpServiceRadioButtons";
            this.groupBoxPickUpServiceRadioButtons.Size = new System.Drawing.Size(325, 75);
            this.groupBoxPickUpServiceRadioButtons.TabIndex = 115;
            this.groupBoxPickUpServiceRadioButtons.TabStop = false;
            // 
            // radioButtonYesPickUp
            // 
            this.radioButtonYesPickUp.AutoSize = true;
            this.radioButtonYesPickUp.Enabled = false;
            this.radioButtonYesPickUp.Location = new System.Drawing.Point(45, 26);
            this.radioButtonYesPickUp.Name = "radioButtonYesPickUp";
            this.radioButtonYesPickUp.Size = new System.Drawing.Size(101, 36);
            this.radioButtonYesPickUp.TabIndex = 55;
            this.radioButtonYesPickUp.Text = "Yes";
            this.radioButtonYesPickUp.UseVisualStyleBackColor = true;
            // 
            // radioButtonNoPickUp
            // 
            this.radioButtonNoPickUp.AutoSize = true;
            this.radioButtonNoPickUp.Checked = true;
            this.radioButtonNoPickUp.Enabled = false;
            this.radioButtonNoPickUp.Location = new System.Drawing.Point(162, 27);
            this.radioButtonNoPickUp.Name = "radioButtonNoPickUp";
            this.radioButtonNoPickUp.Size = new System.Drawing.Size(88, 36);
            this.radioButtonNoPickUp.TabIndex = 5;
            this.radioButtonNoPickUp.TabStop = true;
            this.radioButtonNoPickUp.Text = "No";
            this.radioButtonNoPickUp.UseVisualStyleBackColor = true;
            // 
            // labelLongitud
            // 
            this.labelLongitud.AutoSize = true;
            this.labelLongitud.Location = new System.Drawing.Point(1244, 503);
            this.labelLongitud.Name = "labelLongitud";
            this.labelLongitud.Size = new System.Drawing.Size(134, 32);
            this.labelLongitud.TabIndex = 114;
            this.labelLongitud.Text = "Longitud:";
            // 
            // labelLatitud
            // 
            this.labelLatitud.AutoSize = true;
            this.labelLatitud.Location = new System.Drawing.Point(1268, 439);
            this.labelLatitud.Name = "labelLatitud";
            this.labelLatitud.Size = new System.Drawing.Size(110, 32);
            this.labelLatitud.TabIndex = 113;
            this.labelLatitud.Text = "Latitud:";
            // 
            // textBoxLongitud
            // 
            this.textBoxLongitud.Enabled = false;
            this.textBoxLongitud.Location = new System.Drawing.Point(1391, 497);
            this.textBoxLongitud.MaxLength = 11;
            this.textBoxLongitud.Name = "textBoxLongitud";
            this.textBoxLongitud.Size = new System.Drawing.Size(253, 38);
            this.textBoxLongitud.TabIndex = 95;
            // 
            // textBoxLatitud
            // 
            this.textBoxLatitud.Enabled = false;
            this.textBoxLatitud.Location = new System.Drawing.Point(1391, 433);
            this.textBoxLatitud.MaxLength = 10;
            this.textBoxLatitud.Name = "textBoxLatitud";
            this.textBoxLatitud.Size = new System.Drawing.Size(253, 38);
            this.textBoxLatitud.TabIndex = 94;
            // 
            // labelLocation
            // 
            this.labelLocation.AutoSize = true;
            this.labelLocation.Location = new System.Drawing.Point(1191, 370);
            this.labelLocation.Name = "labelLocation";
            this.labelLocation.Size = new System.Drawing.Size(264, 32);
            this.labelLocation.TabIndex = 112;
            this.labelLocation.Text = "Pickup coordinates:";
            // 
            // labelPickupService
            // 
            this.labelPickupService.AutoSize = true;
            this.labelPickupService.Location = new System.Drawing.Point(1191, 226);
            this.labelPickupService.Name = "labelPickupService";
            this.labelPickupService.Size = new System.Drawing.Size(284, 32);
            this.labelPickupService.TabIndex = 111;
            this.labelPickupService.Text = "Have pickup service?";
            // 
            // labelStudentNumber
            // 
            this.labelStudentNumber.AutoSize = true;
            this.labelStudentNumber.Location = new System.Drawing.Point(197, 224);
            this.labelStudentNumber.Name = "labelStudentNumber";
            this.labelStudentNumber.Size = new System.Drawing.Size(232, 32);
            this.labelStudentNumber.TabIndex = 110;
            this.labelStudentNumber.Text = "Student number: ";
            // 
            // labelSuccess
            // 
            this.labelSuccess.AutoSize = true;
            this.labelSuccess.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSuccess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.labelSuccess.Location = new System.Drawing.Point(156, 1041);
            this.labelSuccess.Name = "labelSuccess";
            this.labelSuccess.Size = new System.Drawing.Size(0, 39);
            this.labelSuccess.TabIndex = 108;
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(160, 1069);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(0, 39);
            this.labelError.TabIndex = 107;
            // 
            // labelSubjectsToBeAdded
            // 
            this.labelSubjectsToBeAdded.AutoSize = true;
            this.labelSubjectsToBeAdded.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubjectsToBeAdded.Location = new System.Drawing.Point(206, 635);
            this.labelSubjectsToBeAdded.Name = "labelSubjectsToBeAdded";
            this.labelSubjectsToBeAdded.Size = new System.Drawing.Size(259, 36);
            this.labelSubjectsToBeAdded.TabIndex = 106;
            this.labelSubjectsToBeAdded.Text = "Subjects to study: ";
            // 
            // listBoxStudentSubjects
            // 
            this.listBoxStudentSubjects.Enabled = false;
            this.listBoxStudentSubjects.FormattingEnabled = true;
            this.listBoxStudentSubjects.ItemHeight = 31;
            this.listBoxStudentSubjects.Location = new System.Drawing.Point(203, 681);
            this.listBoxStudentSubjects.Name = "listBoxStudentSubjects";
            this.listBoxStudentSubjects.Size = new System.Drawing.Size(872, 252);
            this.listBoxStudentSubjects.TabIndex = 102;
            // 
            // labelDeleteStudentTitle
            // 
            this.labelDeleteStudentTitle.AutoSize = true;
            this.labelDeleteStudentTitle.Font = new System.Drawing.Font("Verdana", 14.1F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDeleteStudentTitle.Location = new System.Drawing.Point(107, 84);
            this.labelDeleteStudentTitle.Name = "labelDeleteStudentTitle";
            this.labelDeleteStudentTitle.Size = new System.Drawing.Size(388, 59);
            this.labelDeleteStudentTitle.TabIndex = 96;
            this.labelDeleteStudentTitle.Text = "Delete Student";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(324, 370);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(105, 32);
            this.labelName.TabIndex = 97;
            this.labelName.Text = "Name: ";
            // 
            // labelLastName
            // 
            this.labelLastName.AutoSize = true;
            this.labelLastName.Location = new System.Drawing.Point(263, 439);
            this.labelLastName.Name = "labelLastName";
            this.labelLastName.Size = new System.Drawing.Size(166, 32);
            this.labelLastName.TabIndex = 98;
            this.labelLastName.Text = "Last Name: ";
            // 
            // labelDocument
            // 
            this.labelDocument.AutoSize = true;
            this.labelDocument.Location = new System.Drawing.Point(270, 298);
            this.labelDocument.Name = "labelDocument";
            this.labelDocument.Size = new System.Drawing.Size(159, 32);
            this.labelDocument.TabIndex = 99;
            this.labelDocument.Text = "Document: ";
            // 
            // textBoxName
            // 
            this.textBoxName.Enabled = false;
            this.textBoxName.Location = new System.Drawing.Point(477, 367);
            this.textBoxName.MaxLength = 50;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(598, 38);
            this.textBoxName.TabIndex = 3;
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Enabled = false;
            this.textBoxLastName.Location = new System.Drawing.Point(477, 436);
            this.textBoxLastName.MaxLength = 50;
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(598, 38);
            this.textBoxLastName.TabIndex = 4;
            // 
            // textBoxDocument
            // 
            this.textBoxDocument.Enabled = false;
            this.textBoxDocument.Location = new System.Drawing.Point(477, 295);
            this.textBoxDocument.MaxLength = 9;
            this.textBoxDocument.Name = "textBoxDocument";
            this.textBoxDocument.Size = new System.Drawing.Size(598, 38);
            this.textBoxDocument.TabIndex = 2;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(1146, 1041);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(265, 60);
            this.buttonCancel.TabIndex = 101;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonDeleteStudent
            // 
            this.buttonDeleteStudent.Enabled = false;
            this.buttonDeleteStudent.Location = new System.Drawing.Point(1496, 1041);
            this.buttonDeleteStudent.Name = "buttonDeleteStudent";
            this.buttonDeleteStudent.Size = new System.Drawing.Size(265, 60);
            this.buttonDeleteStudent.TabIndex = 100;
            this.buttonDeleteStudent.Text = "Delete";
            this.buttonDeleteStudent.UseVisualStyleBackColor = true;
            this.buttonDeleteStudent.Click += new System.EventHandler(this.buttonDeleteStudent_Click);
            // 
            // comboBoxStudentsNumbers
            // 
            this.comboBoxStudentsNumbers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStudentsNumbers.FormattingEnabled = true;
            this.comboBoxStudentsNumbers.Location = new System.Drawing.Point(477, 223);
            this.comboBoxStudentsNumbers.Name = "comboBoxStudentsNumbers";
            this.comboBoxStudentsNumbers.Size = new System.Drawing.Size(598, 39);
            this.comboBoxStudentsNumbers.TabIndex = 118;
            this.comboBoxStudentsNumbers.SelectedIndexChanged += new System.EventHandler(this.OnStudenNumber_ComboIndexChange);
            // 
            // DeleteStudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1868, 1192);
            this.Controls.Add(this.comboBoxStudentsNumbers);
            this.Controls.Add(this.groupBoxPickUpServiceRadioButtons);
            this.Controls.Add(this.labelLongitud);
            this.Controls.Add(this.labelLatitud);
            this.Controls.Add(this.textBoxLongitud);
            this.Controls.Add(this.textBoxLatitud);
            this.Controls.Add(this.labelLocation);
            this.Controls.Add(this.labelPickupService);
            this.Controls.Add(this.labelStudentNumber);
            this.Controls.Add(this.labelSuccess);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.labelSubjectsToBeAdded);
            this.Controls.Add(this.listBoxStudentSubjects);
            this.Controls.Add(this.labelDeleteStudentTitle);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelLastName);
            this.Controls.Add(this.labelDocument);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.textBoxLastName);
            this.Controls.Add(this.textBoxDocument);
            this.Controls.Add(this.buttonDeleteStudent);
            this.Controls.Add(this.buttonCancel);
            this.Name = "DeleteStudentForm";
            this.Text = "Delete Student";
            this.groupBoxPickUpServiceRadioButtons.ResumeLayout(false);
            this.groupBoxPickUpServiceRadioButtons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxPickUpServiceRadioButtons;
        private System.Windows.Forms.RadioButton radioButtonYesPickUp;
        private System.Windows.Forms.RadioButton radioButtonNoPickUp;
        private System.Windows.Forms.Label labelLongitud;
        private System.Windows.Forms.Label labelLatitud;
        private System.Windows.Forms.TextBox textBoxLongitud;
        private System.Windows.Forms.TextBox textBoxLatitud;
        private System.Windows.Forms.Label labelLocation;
        private System.Windows.Forms.Label labelPickupService;
        private System.Windows.Forms.Label labelStudentNumber;
        private System.Windows.Forms.Label labelSuccess;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.Label labelSubjectsToBeAdded;
        private System.Windows.Forms.ListBox listBoxStudentSubjects;
        private System.Windows.Forms.Label labelDeleteStudentTitle;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelLastName;
        private System.Windows.Forms.Label labelDocument;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.TextBox textBoxDocument;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonDeleteStudent;
        private System.Windows.Forms.ComboBox comboBoxStudentsNumbers;
    }
}