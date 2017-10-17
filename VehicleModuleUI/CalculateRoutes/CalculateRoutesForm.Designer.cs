namespace VehicleModuleUI.CalculateRoutes
{
    partial class CalculateRoutesForm
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
            this.labelCalculateRoutesTitle = new System.Windows.Forms.Label();
            this.labelExplainListBox = new System.Windows.Forms.Label();
            this.listBoxVehiclesOrderedByCapacity = new System.Windows.Forms.ListBox();
            this.listBoxStudentsInVehicle = new System.Windows.Forms.ListBox();
            this.labelStudentsInVehicle = new System.Windows.Forms.Label();
            this.buttonBackToMainMenu = new System.Windows.Forms.Button();
            this.labelError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelCalculateRoutesTitle
            // 
            this.labelCalculateRoutesTitle.AutoSize = true;
            this.labelCalculateRoutesTitle.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCalculateRoutesTitle.Location = new System.Drawing.Point(13, 13);
            this.labelCalculateRoutesTitle.Name = "labelCalculateRoutesTitle";
            this.labelCalculateRoutesTitle.Size = new System.Drawing.Size(169, 23);
            this.labelCalculateRoutesTitle.TabIndex = 0;
            this.labelCalculateRoutesTitle.Text = "Calculate Routes";
            // 
            // labelExplainListBox
            // 
            this.labelExplainListBox.AutoSize = true;
            this.labelExplainListBox.Location = new System.Drawing.Point(17, 64);
            this.labelExplainListBox.Name = "labelExplainListBox";
            this.labelExplainListBox.Size = new System.Drawing.Size(144, 13);
            this.labelExplainListBox.TabIndex = 1;
            this.labelExplainListBox.Text = "Vehicles ordered by Capacity";
            // 
            // listBoxVehiclesOrderedByCapacity
            // 
            this.listBoxVehiclesOrderedByCapacity.FormattingEnabled = true;
            this.listBoxVehiclesOrderedByCapacity.Location = new System.Drawing.Point(13, 81);
            this.listBoxVehiclesOrderedByCapacity.Name = "listBoxVehiclesOrderedByCapacity";
            this.listBoxVehiclesOrderedByCapacity.Size = new System.Drawing.Size(148, 95);
            this.listBoxVehiclesOrderedByCapacity.TabIndex = 2;
            this.listBoxVehiclesOrderedByCapacity.SelectedIndexChanged += new System.EventHandler(this.listBoxVehiclesOrderedByCapacity_SelectedIndexChanged);
            // 
            // listBoxStudentsInVehicle
            // 
            this.listBoxStudentsInVehicle.FormattingEnabled = true;
            this.listBoxStudentsInVehicle.Location = new System.Drawing.Point(231, 81);
            this.listBoxStudentsInVehicle.Name = "listBoxStudentsInVehicle";
            this.listBoxStudentsInVehicle.Size = new System.Drawing.Size(301, 264);
            this.listBoxStudentsInVehicle.TabIndex = 3;
            // 
            // labelStudentsInVehicle
            // 
            this.labelStudentsInVehicle.AutoSize = true;
            this.labelStudentsInVehicle.Location = new System.Drawing.Point(228, 64);
            this.labelStudentsInVehicle.Name = "labelStudentsInVehicle";
            this.labelStudentsInVehicle.Size = new System.Drawing.Size(98, 13);
            this.labelStudentsInVehicle.TabIndex = 4;
            this.labelStudentsInVehicle.Text = "Students in Vehicle";
            // 
            // buttonBackToMainMenu
            // 
            this.buttonBackToMainMenu.Location = new System.Drawing.Point(421, 433);
            this.buttonBackToMainMenu.Name = "buttonBackToMainMenu";
            this.buttonBackToMainMenu.Size = new System.Drawing.Size(110, 23);
            this.buttonBackToMainMenu.TabIndex = 5;
            this.buttonBackToMainMenu.Text = "Back to Main Menu";
            this.buttonBackToMainMenu.UseVisualStyleBackColor = true;
            this.buttonBackToMainMenu.Click += new System.EventHandler(this.buttonBackToMainMenu_Click);
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(20, 409);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(0, 16);
            this.labelError.TabIndex = 6;
            this.labelError.Visible = false;
            // 
            // CalculateRoutesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 497);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.buttonBackToMainMenu);
            this.Controls.Add(this.labelStudentsInVehicle);
            this.Controls.Add(this.listBoxStudentsInVehicle);
            this.Controls.Add(this.listBoxVehiclesOrderedByCapacity);
            this.Controls.Add(this.labelExplainListBox);
            this.Controls.Add(this.labelCalculateRoutesTitle);
            this.Name = "CalculateRoutesForm";
            this.Text = "CalculateRoutesForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCalculateRoutesTitle;
        private System.Windows.Forms.Label labelExplainListBox;
        private System.Windows.Forms.ListBox listBoxVehiclesOrderedByCapacity;
        private System.Windows.Forms.ListBox listBoxStudentsInVehicle;
        private System.Windows.Forms.Label labelStudentsInVehicle;
        private System.Windows.Forms.Button buttonBackToMainMenu;
        private System.Windows.Forms.Label labelError;
    }
}