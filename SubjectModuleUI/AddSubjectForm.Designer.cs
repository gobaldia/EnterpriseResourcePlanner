namespace SubjectModuleUI
{
    partial class AddSubjectForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxSubjectCode = new System.Windows.Forms.TextBox();
            this.labelSubjectCode = new System.Windows.Forms.Label();
            this.labelSubjectName = new System.Windows.Forms.Label();
            this.textBoxSubjectName = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.labelError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxSubjectCode
            // 
            this.textBoxSubjectCode.Location = new System.Drawing.Point(90, 12);
            this.textBoxSubjectCode.Name = "textBoxSubjectCode";
            this.textBoxSubjectCode.Size = new System.Drawing.Size(100, 20);
            this.textBoxSubjectCode.TabIndex = 0;
            // 
            // labelSubjectCode
            // 
            this.labelSubjectCode.AutoSize = true;
            this.labelSubjectCode.Location = new System.Drawing.Point(13, 18);
            this.labelSubjectCode.Name = "labelSubjectCode";
            this.labelSubjectCode.Size = new System.Drawing.Size(32, 13);
            this.labelSubjectCode.TabIndex = 1;
            this.labelSubjectCode.Text = "Code";
            // 
            // labelSubjectName
            // 
            this.labelSubjectName.AutoSize = true;
            this.labelSubjectName.Location = new System.Drawing.Point(16, 49);
            this.labelSubjectName.Name = "labelSubjectName";
            this.labelSubjectName.Size = new System.Drawing.Size(35, 13);
            this.labelSubjectName.TabIndex = 2;
            this.labelSubjectName.Text = "Name";
            // 
            // textBoxSubjectName
            // 
            this.textBoxSubjectName.Location = new System.Drawing.Point(90, 46);
            this.textBoxSubjectName.Name = "textBoxSubjectName";
            this.textBoxSubjectName.Size = new System.Drawing.Size(100, 20);
            this.textBoxSubjectName.TabIndex = 3;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(115, 89);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 4;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Location = new System.Drawing.Point(112, 131);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(0, 13);
            this.labelError.TabIndex = 5;
            this.labelError.Visible = false;
            // 
            // AddSubjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.textBoxSubjectName);
            this.Controls.Add(this.labelSubjectName);
            this.Controls.Add(this.labelSubjectCode);
            this.Controls.Add(this.textBoxSubjectCode);
            this.Name = "AddSubjectForm";
            this.Text = "Add Subject";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSubjectCode;
        private System.Windows.Forms.Label labelSubjectCode;
        private System.Windows.Forms.Label labelSubjectName;
        private System.Windows.Forms.TextBox textBoxSubjectName;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Label labelError;
    }
}

