using CoreEntities.Entities;
using CoreEntities.Exceptions;
using CoreLogic;
using FrameworkCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentModuleUI.DeleteStudent
{
    public partial class DeleteStudentForm : Form
    {
        private Student StudentToDelete;
        public DeleteStudentForm()
        {
            InitializeComponent();
            SetDefaultWindowsSize();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.CleanForm();
                this.labelSuccess.Text = string.Empty;
                int studentNumber = 0;
                if (int.TryParse(this.textBoxStudentNumber.Text, out studentNumber))
                {
                    this.StudentToDelete = ClassFactory.GetOrCreate<StudentLogic>().GetStudentByNumber(studentNumber);
                    FillFormWithStudentData();
                }
                else
                {
                    this.labelError.Text = Constants.ERROR_INVALID_STUDENTNUMBER;
                }
            }
            catch (CoreException ex)
            {
                this.StudentToDelete = null;
                this.labelError.Text = ex.Message;
            }
            catch (Exception)
            {
                this.StudentToDelete = null;
                this.labelError.Text = Constants.ERROR_UNEXPECTED;
            }
        }

        private void buttonDeleteStudent_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.StudentToDelete != null)
                {
                    ClassFactory.GetOrCreate<StudentLogic>().DeleteStudent(this.StudentToDelete.GetStudentNumber());
                    this.CleanForm();
                    this.labelSuccess.Text = Constants.SUCCESS_TEACHER_DELETED;
                }
                else
                {
                    labelError.Text = Constants.ERROR_NOSTUDENTFOUND;
                }
            }
            catch (CoreException ex)
            {
                this.labelError.Text = ex.Message;
            }
            catch (Exception)
            {
                this.labelError.Text = Constants.ERROR_UNEXPECTED;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        #region Utility methods
        private void SetDefaultWindowsSize()
        {
            this.AutoScaleMode = AutoScaleMode.None;
            this.Size = new System.Drawing.Size(750, 550);
        }
        private void CleanForm()
        {
            textBoxDocument.Text = string.Empty;
            textBoxName.Text = string.Empty;
            textBoxLastName.Text = string.Empty;
            radioButtonNoPickUp.Checked = true;
            radioButtonYesPickUp.Checked = false;
            textBoxLatitud.Text = string.Empty;
            textBoxLongitud.Text = string.Empty;
            listBoxStudentSubjects.Items.Clear();
        }
        private void FillFormWithStudentData()
        {
            textBoxDocument.Text = this.StudentToDelete.GetDocumentNumber();
            textBoxName.Text = this.StudentToDelete.GetName();
            textBoxLastName.Text = this.StudentToDelete.GetLastName();
            radioButtonNoPickUp.Checked = !this.StudentToDelete.HavePickUpService();
            radioButtonYesPickUp.Checked = this.StudentToDelete.HavePickUpService();
            if (this.StudentToDelete.HavePickUpService())
            {
                Location studentLocation = this.StudentToDelete.GetLocation();
                textBoxLatitud.Text = studentLocation.GetLatitud().ToString();
                textBoxLongitud.Text = studentLocation.GetLongitud().ToString();
            }
            LoadStudentSubjects();
        }
        private void LoadStudentSubjects()
        {
            foreach (var subject in this.StudentToDelete.GetSubjects())
            {
                this.listBoxStudentSubjects.Items.Add(subject);
            }
        }
        #endregion

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            this.labelError.Text = string.Empty;
            this.labelSuccess.Text = string.Empty;
        }
    }
}
