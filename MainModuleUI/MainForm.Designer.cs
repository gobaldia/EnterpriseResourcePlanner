namespace MainModuleUI
{
    partial class MainForm
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
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.labelMainModuleTitle = new System.Windows.Forms.Label();
            this.buttonInitialiceData = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(1900, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "Main Menu";
            // 
            // labelMainModuleTitle
            // 
            this.labelMainModuleTitle.AutoSize = true;
            this.labelMainModuleTitle.Font = new System.Drawing.Font("Verdana", 14.1F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMainModuleTitle.Location = new System.Drawing.Point(121, 108);
            this.labelMainModuleTitle.Name = "labelMainModuleTitle";
            this.labelMainModuleTitle.Size = new System.Drawing.Size(792, 59);
            this.labelMainModuleTitle.TabIndex = 1;
            this.labelMainModuleTitle.Text = "Enterprise Resource Planner";
            // 
            // buttonInitialiceData
            // 
            this.buttonInitialiceData.Location = new System.Drawing.Point(1336, 867);
            this.buttonInitialiceData.Name = "buttonInitialiceData";
            this.buttonInitialiceData.Size = new System.Drawing.Size(477, 61);
            this.buttonInitialiceData.TabIndex = 2;
            this.buttonInitialiceData.Text = "Initialize random generated data";
            this.buttonInitialiceData.UseVisualStyleBackColor = true;
            this.buttonInitialiceData.Click += new System.EventHandler(this.buttonInitialiceData_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1900, 1000);
            this.Controls.Add(this.buttonInitialiceData);
            this.Controls.Add(this.labelMainModuleTitle);
            this.Controls.Add(this.mainMenuStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MainForm";
            this.Text = "Main Module";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.Label labelMainModuleTitle;
        private System.Windows.Forms.Button buttonInitialiceData;
    }
}

