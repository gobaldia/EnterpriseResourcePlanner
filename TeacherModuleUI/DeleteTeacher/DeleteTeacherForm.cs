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

namespace TeacherModuleUI.DeleteTeacher
{
    public partial class DeleteTeacherForm : Form
    {
        private Teacher teacherToDelete;
        public DeleteTeacherForm()
        {
            InitializeComponent();
            SetDefaultWindowsSize();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void buttonDeleteTeacher_Click(object sender, EventArgs e)
        {
            try
            {
                if (teacherToDelete != null)
                {
                    ClassFactory.GetOrCreate<TeacherLogic>().DeleteTeacher(teacherToDelete);
                    this.CleanForm();
                    this.labelSuccess.Text = Constants.SUCCESS_TEACHER_DELETED;
                }
                else
                {
                    labelError.Text = Constants.ERROR_NOTEACHERFOUND;
                }
            }
            catch(CoreException ex)
            {
                this.labelError.Text = ex.Message;
            }
            catch (Exception)
            {
                this.labelError.Text = Constants.ERROR_UNEXPECTED;
            }
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.CleanForm();
                this.labelSuccess.Text = string.Empty;
                string documentNumber = this.textBoxTeacherDocument.Text;
                if (!string.IsNullOrEmpty(documentNumber))
                {
                    this.teacherToDelete = ClassFactory.GetOrCreate<TeacherLogic>().GetTeacherByDocumentNumber(documentNumber);
                    this.FillFormWithTeacherData();
                }
                else
                {
                    this.labelError.Text = Constants.ERROR_DOCUMENTNUMBER_REQUIRED;
                }
            }
            catch (CoreException ex)
            {
                this.teacherToDelete = null;
                this.labelError.Text = ex.Message;
            }
            catch (Exception)
            {
                this.teacherToDelete = null;
                this.labelError.Text = Constants.ERROR_UNEXPECTED;
            }
        }
        private void textBoxTeacherDocument_KeyDown(object sender, KeyEventArgs e)
        {
            this.labelSuccess.Text = string.Empty;
            this.labelError.Text = string.Empty;
        }

        #region Utility methods
        private void FillFormWithTeacherData()
        {
            this.textBoxTeacherName.Text = this.teacherToDelete.GetName();
            this.textBoxTeacherLastName.Text = this.teacherToDelete.GetLastName();
            foreach (var subject in this.teacherToDelete.GetSubjects())
            {
                this.listBoxTeacherSubjects.Items.Add(subject);
            }
        }
        private void CleanForm(bool cleanTeacherDocumentNumber = false)
        {
            this.textBoxTeacherName.Text = string.Empty;
            this.textBoxTeacherLastName.Text = string.Empty;

            if (cleanTeacherDocumentNumber)
                this.textBoxTeacherDocument.Text = string.Empty;

            this.listBoxTeacherSubjects.Items.Clear();
            this.labelError.Text = string.Empty;
        }
        private void SetDefaultWindowsSize()
        {
            this.AutoScaleMode = AutoScaleMode.None;
            this.Size = new System.Drawing.Size(750, 550);
        }
        #endregion
    }
}
