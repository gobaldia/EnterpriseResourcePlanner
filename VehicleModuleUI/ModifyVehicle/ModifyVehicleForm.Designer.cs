namespace VehicleModuleUI.ModifyVehicle
{
    partial class ModifyVehicleForm
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
            this.labelModifyVehicleTitle = new System.Windows.Forms.Label();
            this.labelCapacity = new System.Windows.Forms.Label();
            this.numericUpDownCapacity = new System.Windows.Forms.NumericUpDown();
            this.labelSuccess = new System.Windows.Forms.Label();
            this.labelError = new System.Windows.Forms.Label();
            this.buttonModify = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.comboBoxSelectVehicleToModify = new System.Windows.Forms.ComboBox();
            this.labelSelectVehicleToModify = new System.Windows.Forms.Label();
            this.labelFuelConsumption = new System.Windows.Forms.Label();
            this.numericUpDownFuelConsumption = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCapacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFuelConsumption)).BeginInit();
            this.SuspendLayout();
            // 
            // labelModifyVehicleTitle
            // 
            this.labelModifyVehicleTitle.AutoSize = true;
            this.labelModifyVehicleTitle.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelModifyVehicleTitle.Location = new System.Drawing.Point(101, 102);
            this.labelModifyVehicleTitle.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.labelModifyVehicleTitle.Name = "labelModifyVehicleTitle";
            this.labelModifyVehicleTitle.Size = new System.Drawing.Size(369, 59);
            this.labelModifyVehicleTitle.TabIndex = 0;
            this.labelModifyVehicleTitle.Text = "Modify Vehicle";
            // 
            // labelCapacity
            // 
            this.labelCapacity.AutoSize = true;
            this.labelCapacity.Location = new System.Drawing.Point(455, 367);
            this.labelCapacity.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.labelCapacity.Name = "labelCapacity";
            this.labelCapacity.Size = new System.Drawing.Size(126, 32);
            this.labelCapacity.TabIndex = 1;
            this.labelCapacity.Text = "Capacity";
            // 
            // numericUpDownCapacity
            // 
            this.numericUpDownCapacity.Location = new System.Drawing.Point(624, 367);
            this.numericUpDownCapacity.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.numericUpDownCapacity.Name = "numericUpDownCapacity";
            this.numericUpDownCapacity.Size = new System.Drawing.Size(320, 38);
            this.numericUpDownCapacity.TabIndex = 2;
            // 
            // labelSuccess
            // 
            this.labelSuccess.AutoSize = true;
            this.labelSuccess.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSuccess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.labelSuccess.Location = new System.Drawing.Point(160, 713);
            this.labelSuccess.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.labelSuccess.Name = "labelSuccess";
            this.labelSuccess.Size = new System.Drawing.Size(0, 38);
            this.labelSuccess.TabIndex = 3;
            this.labelSuccess.Visible = false;
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(160, 713);
            this.labelError.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(0, 38);
            this.labelError.TabIndex = 4;
            this.labelError.Visible = false;
            // 
            // buttonModify
            // 
            this.buttonModify.Enabled = false;
            this.buttonModify.Location = new System.Drawing.Point(1317, 833);
            this.buttonModify.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.buttonModify.Name = "buttonModify";
            this.buttonModify.Size = new System.Drawing.Size(200, 55);
            this.buttonModify.TabIndex = 3;
            this.buttonModify.Text = "Modify";
            this.buttonModify.UseVisualStyleBackColor = true;
            this.buttonModify.Click += new System.EventHandler(this.buttonModify_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(968, 833);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(200, 55);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // comboBoxSelectVehicleToModify
            // 
            this.comboBoxSelectVehicleToModify.FormattingEnabled = true;
            this.comboBoxSelectVehicleToModify.Location = new System.Drawing.Point(624, 266);
            this.comboBoxSelectVehicleToModify.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.comboBoxSelectVehicleToModify.Name = "comboBoxSelectVehicleToModify";
            this.comboBoxSelectVehicleToModify.Size = new System.Drawing.Size(320, 39);
            this.comboBoxSelectVehicleToModify.TabIndex = 1;
            this.comboBoxSelectVehicleToModify.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelectVehicleToModify_SelectedIndexChanged);
            // 
            // labelSelectVehicleToModify
            // 
            this.labelSelectVehicleToModify.AutoSize = true;
            this.labelSelectVehicleToModify.Location = new System.Drawing.Point(262, 273);
            this.labelSelectVehicleToModify.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.labelSelectVehicleToModify.Name = "labelSelectVehicleToModify";
            this.labelSelectVehicleToModify.Size = new System.Drawing.Size(319, 32);
            this.labelSelectVehicleToModify.TabIndex = 8;
            this.labelSelectVehicleToModify.Text = "Select Vehicle to Modify";
            // 
            // labelFuelConsumption
            // 
            this.labelFuelConsumption.AutoSize = true;
            this.labelFuelConsumption.Location = new System.Drawing.Point(152, 462);
            this.labelFuelConsumption.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.labelFuelConsumption.Name = "labelFuelConsumption";
            this.labelFuelConsumption.Size = new System.Drawing.Size(429, 32);
            this.labelFuelConsumption.TabIndex = 9;
            this.labelFuelConsumption.Text = "Fuel Consumption (Kms per liter)";
            // 
            // numericUpDownFuelConsumption
            // 
            this.numericUpDownFuelConsumption.Location = new System.Drawing.Point(624, 462);
            this.numericUpDownFuelConsumption.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.numericUpDownFuelConsumption.Name = "numericUpDownFuelConsumption";
            this.numericUpDownFuelConsumption.Size = new System.Drawing.Size(320, 38);
            this.numericUpDownFuelConsumption.TabIndex = 10;
            // 
            // ModifyVehicleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1668, 992);
            this.Controls.Add(this.numericUpDownFuelConsumption);
            this.Controls.Add(this.labelFuelConsumption);
            this.Controls.Add(this.labelSelectVehicleToModify);
            this.Controls.Add(this.comboBoxSelectVehicleToModify);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonModify);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.labelSuccess);
            this.Controls.Add(this.numericUpDownCapacity);
            this.Controls.Add(this.labelCapacity);
            this.Controls.Add(this.labelModifyVehicleTitle);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "ModifyVehicleForm";
            this.Text = "ModifyVehicleForm";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCapacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFuelConsumption)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelModifyVehicleTitle;
        private System.Windows.Forms.Label labelCapacity;
        private System.Windows.Forms.NumericUpDown numericUpDownCapacity;
        private System.Windows.Forms.Label labelSuccess;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.Button buttonModify;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ComboBox comboBoxSelectVehicleToModify;
        private System.Windows.Forms.Label labelSelectVehicleToModify;
        private System.Windows.Forms.Label labelFuelConsumption;
        private System.Windows.Forms.NumericUpDown numericUpDownFuelConsumption;
    }
}