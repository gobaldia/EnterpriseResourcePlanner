using CoreEntities.Entities;
using CoreEntities.Exceptions;
using CoreLogic;
using CoreLogic.Interfaces;
using FrameworkCommon;
using ProviderManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SubjectModuleUI.AddSubject
{
    public partial class AddSubjectForm : Form
    {
        public AddSubjectForm()
        {
            InitializeComponent();
            SetDefaultWindowsSize();
        }

        private void SetDefaultWindowsSize()
        {
            this.AutoScaleMode = AutoScaleMode.None;
            this.Size = new System.Drawing.Size(500, 350);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            this.labelOk.Visible = false;
            this.labelError.Visible = false;
            try
            {
                this.labelError.Visible = false;
                string name;
                Subject subject = new Subject();
                if (int.TryParse(this.textBoxSubjectCode.Text, out int code))
                {
                    if (!string.IsNullOrWhiteSpace(this.textBoxSubjectName.Text))
                    {
                        subject.Code = code;
                        name = this.textBoxSubjectName.Text;
                        subject.Name = name;

                        ISubjectLogic subjectsOperations = Provider.GetInstance.GetSubjectOperations();
                        subjectsOperations.AddSubject(subject);

                        this.ClearAddSubjectForm();
                        this.ShowCorrectlyAddedSubjectMessage(code, name);
                    }
                    else
                    {
                        this.labelError.Visible = true;
                        this.labelError.Text = "Subject's name must be a not empty string";
                    }
                }
                else
                {
                    this.labelError.Visible = true;
                    this.labelError.Text = "Subject's code must be a number";
                }
            }
            catch (CoreException ex)
            {
                this.labelError.Text = ex.Message;
                this.labelError.Visible = true;
            }
            catch (Exception ex)
            {
                this.labelError.Text = ex.Message;
                this.labelError.Visible = true;
            }
            
        }

        private void ClearAddSubjectForm()
        {
            this.textBoxSubjectCode.Clear();
            this.textBoxSubjectName.Clear();
        }

        private void ShowCorrectlyAddedSubjectMessage(int code, string name)
        {
            labelOk.Visible = true;
            this.labelOk.Text = "Subject " + name + " with code " + code + " was correctly added";
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
