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
            this.labelDataGenerated = new System.Windows.Forms.Label();
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
            // labelDataGenerated
            // 
            this.labelDataGenerated.AutoSize = true;
            this.labelDataGenerated.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDataGenerated.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.labelDataGenerated.Location = new System.Drawing.Point(1494, 937);
            this.labelDataGenerated.Name = "labelDataGenerated";
            this.labelDataGenerated.Size = new System.Drawing.Size(260, 39);
            this.labelDataGenerated.TabIndex = 3;
            this.labelDataGenerated.Text = "Data generated.";
            this.labelDataGenerated.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1900, 1000);
            this.Controls.Add(this.labelDataGenerated);
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
        private System.Windows.Forms.Label labelDataGenerated;
    }
}

