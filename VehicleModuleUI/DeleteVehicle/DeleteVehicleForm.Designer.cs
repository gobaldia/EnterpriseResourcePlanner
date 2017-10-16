namespace VehicleModuleUI.DeleteVehicle
{
    partial class DeleteVehicleForm
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
            this.labelDeleteVehicleTitle = new System.Windows.Forms.Label();
            this.labelSelectVehicleToDelete = new System.Windows.Forms.Label();
            this.comboBoxSelectVehicleToDelete = new System.Windows.Forms.ComboBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelError = new System.Windows.Forms.Label();
            this.labelSuccess = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelDeleteVehicleTitle
            // 
            this.labelDeleteVehicleTitle.AutoSize = true;
            this.labelDeleteVehicleTitle.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDeleteVehicleTitle.Location = new System.Drawing.Point(13, 13);
            this.labelDeleteVehicleTitle.Name = "labelDeleteVehicleTitle";
            this.labelDeleteVehicleTitle.Size = new System.Drawing.Size(146, 23);
            this.labelDeleteVehicleTitle.TabIndex = 0;
            this.labelDeleteVehicleTitle.Text = "Delete Vehicle";
            // 
            // labelSelectVehicleToDelete
            // 
            this.labelSelectVehicleToDelete.AutoSize = true;
            this.labelSelectVehicleToDelete.Location = new System.Drawing.Point(17, 60);
            this.labelSelectVehicleToDelete.Name = "labelSelectVehicleToDelete";
            this.labelSelectVehicleToDelete.Size = new System.Drawing.Size(121, 13);
            this.labelSelectVehicleToDelete.TabIndex = 1;
            this.labelSelectVehicleToDelete.Text = "Select Vehicle to Delete";
            // 
            // comboBoxSelectVehicleToDelete
            // 
            this.comboBoxSelectVehicleToDelete.FormattingEnabled = true;
            this.comboBoxSelectVehicleToDelete.Location = new System.Drawing.Point(20, 77);
            this.comboBoxSelectVehicleToDelete.Name = "comboBoxSelectVehicleToDelete";
            this.comboBoxSelectVehicleToDelete.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSelectVehicleToDelete.TabIndex = 2;
            this.comboBoxSelectVehicleToDelete.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelectVehicleToDelete_SelectedIndexChanged);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Enabled = false;
            this.buttonDelete.Location = new System.Drawing.Point(20, 152);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(20, 182);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(20, 133);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(0, 16);
            this.labelError.TabIndex = 5;
            this.labelError.Visible = false;
            // 
            // labelSuccess
            // 
            this.labelSuccess.AutoSize = true;
            this.labelSuccess.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSuccess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.labelSuccess.Location = new System.Drawing.Point(20, 132);
            this.labelSuccess.Name = "labelSuccess";
            this.labelSuccess.Size = new System.Drawing.Size(0, 16);
            this.labelSuccess.TabIndex = 6;
            this.labelSuccess.Visible = false;
            // 
            // DeleteVehicleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 393);
            this.Controls.Add(this.labelSuccess);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.comboBoxSelectVehicleToDelete);
            this.Controls.Add(this.labelSelectVehicleToDelete);
            this.Controls.Add(this.labelDeleteVehicleTitle);
            this.Name = "DeleteVehicleForm";
            this.Text = "DeleteVehicleForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDeleteVehicleTitle;
        private System.Windows.Forms.Label labelSelectVehicleToDelete;
        private System.Windows.Forms.ComboBox comboBoxSelectVehicleToDelete;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.Label labelSuccess;
    }
}