namespace VehicleModuleUI.AddVehicle
{
    partial class AddVehicleForm
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
            this.labelAddVehicleTitle = new System.Windows.Forms.Label();
            this.labelRegistration = new System.Windows.Forms.Label();
            this.labelCapacity = new System.Windows.Forms.Label();
            this.numericUpDownCapacity = new System.Windows.Forms.NumericUpDown();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelError = new System.Windows.Forms.Label();
            this.labelSuccess = new System.Windows.Forms.Label();
            this.textBoxRegistration = new System.Windows.Forms.TextBox();
            this.labelFuelConsumption = new System.Windows.Forms.Label();
            this.numericUpDownFuelConsumption = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCapacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFuelConsumption)).BeginInit();
            this.SuspendLayout();
            // 
            // labelAddVehicleTitle
            // 
            this.labelAddVehicleTitle.AutoSize = true;
            this.labelAddVehicleTitle.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAddVehicleTitle.Location = new System.Drawing.Point(58, 18);
            this.labelAddVehicleTitle.Name = "labelAddVehicleTitle";
            this.labelAddVehicleTitle.Size = new System.Drawing.Size(168, 23);
            this.labelAddVehicleTitle.TabIndex = 0;
            this.labelAddVehicleTitle.Text = "Add new Vehicle";
            // 
            // labelRegistration
            // 
            this.labelRegistration.AutoSize = true;
            this.labelRegistration.Location = new System.Drawing.Point(62, 78);
            this.labelRegistration.Name = "labelRegistration";
            this.labelRegistration.Size = new System.Drawing.Size(63, 13);
            this.labelRegistration.TabIndex = 1;
            this.labelRegistration.Text = "Registration";
            // 
            // labelCapacity
            // 
            this.labelCapacity.AutoSize = true;
            this.labelCapacity.Location = new System.Drawing.Point(59, 130);
            this.labelCapacity.Name = "labelCapacity";
            this.labelCapacity.Size = new System.Drawing.Size(48, 13);
            this.labelCapacity.TabIndex = 2;
            this.labelCapacity.Text = "Capacity";
            // 
            // numericUpDownCapacity
            // 
            this.numericUpDownCapacity.Location = new System.Drawing.Point(59, 147);
            this.numericUpDownCapacity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownCapacity.Name = "numericUpDownCapacity";
            this.numericUpDownCapacity.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownCapacity.TabIndex = 2;
            this.numericUpDownCapacity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(310, 299);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 3;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(199, 299);
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
            this.labelError.Location = new System.Drawing.Point(17, 268);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(0, 16);
            this.labelError.TabIndex = 7;
            this.labelError.Visible = false;
            // 
            // labelSuccess
            // 
            this.labelSuccess.AutoSize = true;
            this.labelSuccess.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSuccess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.labelSuccess.Location = new System.Drawing.Point(17, 268);
            this.labelSuccess.Name = "labelSuccess";
            this.labelSuccess.Size = new System.Drawing.Size(0, 16);
            this.labelSuccess.TabIndex = 8;
            this.labelSuccess.Visible = false;
            // 
            // textBoxRegistration
            // 
            this.textBoxRegistration.Location = new System.Drawing.Point(62, 95);
            this.textBoxRegistration.Name = "textBoxRegistration";
            this.textBoxRegistration.Size = new System.Drawing.Size(100, 20);
            this.textBoxRegistration.TabIndex = 1;
            // 
            // labelFuelConsumption
            // 
            this.labelFuelConsumption.AutoSize = true;
            this.labelFuelConsumption.Location = new System.Drawing.Point(56, 190);
            this.labelFuelConsumption.Name = "labelFuelConsumption";
            this.labelFuelConsumption.Size = new System.Drawing.Size(157, 13);
            this.labelFuelConsumption.TabIndex = 9;
            this.labelFuelConsumption.Text = "Fuel Consumption (Kms per liter)";
            // 
            // numericUpDownFuelConsumption
            // 
            this.numericUpDownFuelConsumption.Location = new System.Drawing.Point(59, 206);
            this.numericUpDownFuelConsumption.Name = "numericUpDownFuelConsumption";
            this.numericUpDownFuelConsumption.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownFuelConsumption.TabIndex = 10;
            // 
            // AddVehicleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 392);
            this.Controls.Add(this.numericUpDownFuelConsumption);
            this.Controls.Add(this.labelFuelConsumption);
            this.Controls.Add(this.textBoxRegistration);
            this.Controls.Add(this.labelSuccess);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.numericUpDownCapacity);
            this.Controls.Add(this.labelCapacity);
            this.Controls.Add(this.labelRegistration);
            this.Controls.Add(this.labelAddVehicleTitle);
            this.Name = "AddVehicleForm";
            this.Text = "AddVehicleForm";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCapacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFuelConsumption)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAddVehicleTitle;
        private System.Windows.Forms.Label labelRegistration;
        private System.Windows.Forms.Label labelCapacity;
        private System.Windows.Forms.NumericUpDown numericUpDownCapacity;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.Label labelSuccess;
        private System.Windows.Forms.TextBox textBoxRegistration;
        private System.Windows.Forms.Label labelFuelConsumption;
        private System.Windows.Forms.NumericUpDown numericUpDownFuelConsumption;
    }
}