namespace VehicleModuleUI.ListVehicles
{
    partial class ListVehiclesForm
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
            this.labelListVehiclesTitle = new System.Windows.Forms.Label();
            this.listBoxAvailableVehicles = new System.Windows.Forms.ListBox();
            this.buttonBackToMainMenu = new System.Windows.Forms.Button();
            this.labelError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelListVehiclesTitle
            // 
            this.labelListVehiclesTitle.AutoSize = true;
            this.labelListVehiclesTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelListVehiclesTitle.Location = new System.Drawing.Point(13, 13);
            this.labelListVehiclesTitle.Name = "labelListVehiclesTitle";
            this.labelListVehiclesTitle.Size = new System.Drawing.Size(200, 24);
            this.labelListVehiclesTitle.TabIndex = 0;
            this.labelListVehiclesTitle.Text = "Available Vehicle\'s List";
            // 
            // listBoxAvailableVehicles
            // 
            this.listBoxAvailableVehicles.FormattingEnabled = true;
            this.listBoxAvailableVehicles.Location = new System.Drawing.Point(16, 45);
            this.listBoxAvailableVehicles.Name = "listBoxAvailableVehicles";
            this.listBoxAvailableVehicles.Size = new System.Drawing.Size(197, 95);
            this.listBoxAvailableVehicles.TabIndex = 1;
            // 
            // buttonBackToMainMenu
            // 
            this.buttonBackToMainMenu.Location = new System.Drawing.Point(16, 192);
            this.buttonBackToMainMenu.Name = "buttonBackToMainMenu";
            this.buttonBackToMainMenu.Size = new System.Drawing.Size(120, 23);
            this.buttonBackToMainMenu.TabIndex = 2;
            this.buttonBackToMainMenu.Text = "Back to Main Menu";
            this.buttonBackToMainMenu.UseVisualStyleBackColor = true;
            this.buttonBackToMainMenu.Click += new System.EventHandler(this.buttonBackToMainMenu_Click);
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Font = new System.Drawing.Font("Verdana", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(16, 173);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(0, 16);
            this.labelError.TabIndex = 3;
            this.labelError.Visible = false;
            // 
            // ListVehiclesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 351);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.buttonBackToMainMenu);
            this.Controls.Add(this.listBoxAvailableVehicles);
            this.Controls.Add(this.labelListVehiclesTitle);
            this.Name = "ListVehiclesForm";
            this.Text = "ListVehiclesForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelListVehiclesTitle;
        private System.Windows.Forms.ListBox listBoxAvailableVehicles;
        private System.Windows.Forms.Button buttonBackToMainMenu;
        private System.Windows.Forms.Label labelError;
    }
}