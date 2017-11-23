namespace ActivityModuleUI.ListActivities
{
    partial class ListActivitiesForm
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
            this.labelListActivitiesTitle = new System.Windows.Forms.Label();
            this.listBoxRegisteredActivities = new System.Windows.Forms.ListBox();
            this.listBoxActivitysStudents = new System.Windows.Forms.ListBox();
            this.labelRegisteredActivities = new System.Windows.Forms.Label();
            this.labelActivitysStudents = new System.Windows.Forms.Label();
            this.buttonBackToMainMenu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelListActivitiesTitle
            // 
            this.labelListActivitiesTitle.AutoSize = true;
            this.labelListActivitiesTitle.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelListActivitiesTitle.Location = new System.Drawing.Point(58, 18);
            this.labelListActivitiesTitle.Name = "labelListActivitiesTitle";
            this.labelListActivitiesTitle.Size = new System.Drawing.Size(138, 23);
            this.labelListActivitiesTitle.TabIndex = 0;
            this.labelListActivitiesTitle.Text = "List Activities";
            // 
            // listBoxRegisteredActivities
            // 
            this.listBoxRegisteredActivities.FormattingEnabled = true;
            this.listBoxRegisteredActivities.Location = new System.Drawing.Point(62, 114);
            this.listBoxRegisteredActivities.Name = "listBoxRegisteredActivities";
            this.listBoxRegisteredActivities.Size = new System.Drawing.Size(200, 199);
            this.listBoxRegisteredActivities.TabIndex = 1;
            this.listBoxRegisteredActivities.SelectedIndexChanged += new System.EventHandler(this.listBoxRegisteredActivities_SelectedIndexChanged);
            // 
            // listBoxActivitysStudents
            // 
            this.listBoxActivitysStudents.FormattingEnabled = true;
            this.listBoxActivitysStudents.Location = new System.Drawing.Point(315, 114);
            this.listBoxActivitysStudents.Name = "listBoxActivitysStudents";
            this.listBoxActivitysStudents.Size = new System.Drawing.Size(200, 199);
            this.listBoxActivitysStudents.TabIndex = 2;
            // 
            // labelRegisteredActivities
            // 
            this.labelRegisteredActivities.AutoSize = true;
            this.labelRegisteredActivities.Location = new System.Drawing.Point(62, 95);
            this.labelRegisteredActivities.Name = "labelRegisteredActivities";
            this.labelRegisteredActivities.Size = new System.Drawing.Size(103, 13);
            this.labelRegisteredActivities.TabIndex = 3;
            this.labelRegisteredActivities.Text = "Registered Activities";
            // 
            // labelActivitysStudents
            // 
            this.labelActivitysStudents.AutoSize = true;
            this.labelActivitysStudents.Location = new System.Drawing.Point(312, 95);
            this.labelActivitysStudents.Name = "labelActivitysStudents";
            this.labelActivitysStudents.Size = new System.Drawing.Size(93, 13);
            this.labelActivitysStudents.TabIndex = 4;
            this.labelActivitysStudents.Text = "Activity\'s Students";
            // 
            // buttonBackToMainMenu
            // 
            this.buttonBackToMainMenu.Location = new System.Drawing.Point(407, 370);
            this.buttonBackToMainMenu.Name = "buttonBackToMainMenu";
            this.buttonBackToMainMenu.Size = new System.Drawing.Size(108, 23);
            this.buttonBackToMainMenu.TabIndex = 5;
            this.buttonBackToMainMenu.Text = "Back to main menu";
            this.buttonBackToMainMenu.UseVisualStyleBackColor = true;
            this.buttonBackToMainMenu.Click += new System.EventHandler(this.buttonBackToMainMenu_Click);
            // 
            // ListActivitiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 431);
            this.Controls.Add(this.buttonBackToMainMenu);
            this.Controls.Add(this.labelActivitysStudents);
            this.Controls.Add(this.labelRegisteredActivities);
            this.Controls.Add(this.listBoxActivitysStudents);
            this.Controls.Add(this.listBoxRegisteredActivities);
            this.Controls.Add(this.labelListActivitiesTitle);
            this.Name = "ListActivitiesForm";
            this.Text = "ListActivitiesForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelListActivitiesTitle;
        private System.Windows.Forms.ListBox listBoxRegisteredActivities;
        private System.Windows.Forms.ListBox listBoxActivitysStudents;
        private System.Windows.Forms.Label labelRegisteredActivities;
        private System.Windows.Forms.Label labelActivitysStudents;
        private System.Windows.Forms.Button buttonBackToMainMenu;
    }
}