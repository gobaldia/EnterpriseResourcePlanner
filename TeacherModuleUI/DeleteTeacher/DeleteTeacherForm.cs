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

namespace TeacherModuleUI.DeleteTeacher
{
    public partial class DeleteTeacherForm : Form
    {
        private Teacher teacherToDelete;
        public DeleteTeacherForm()
        {
            InitializeComponent();
            SetDefaultWindowsSize();
            FillTeachersCombo();
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
                    ITeacherLogic teacherOperations = Provider.GetInstance.GetTeacherOperations();
                    teacherOperations.DeleteTeacher(teacherToDelete);
                    this.CleanForm(true);
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
        private void OnTeacherDocument_ComboIndexChange(object sender, EventArgs e)
        {
            try
            {
                this.CleanForm();
                this.labelSuccess.Text = string.Empty;
                if (comboBoxTeachersDocuments.SelectedIndex >= 0)
                {
                    buttonDeleteTeacher.Enabled = true;
                    var documentNumber = comboBoxTeachersDocuments.SelectedItem as string;
                    ITeacherLogic teacherOperations = Provider.GetInstance.GetTeacherOperations();
                    this.teacherToDelete = teacherOperations.GetTeacherByDocumentNumber(documentNumber);
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

        #region Utility methods
        private void FillFormWithTeacherData()
        {
            this.textBoxTeacherName.Text = this.teacherToDelete.GetName();
            this.textBoxTeacherLastName.Text = this.teacherToDelete.GetLastName();
            List<Subject> teacherSubjects = this.teacherToDelete.GetSubjects();
            this.LoadSubjects(teacherSubjects);
            
        }
        private void FillTeachersCombo()
        {
            ITeacherLogic teacherOperations = Provider.GetInstance.GetTeacherOperations();
            var systemTeachers = teacherOperations.GetTeachers();
            foreach (Teacher teacher in systemTeachers)
            {
                this.comboBoxTeachersDocuments.Items.Add(teacher.Document);
            }  
        }
        private void LoadSubjects(List<Subject> subjectsToBeLoaded)
        {
            if(subjectsToBeLoaded?.Count > 0)
            {
                foreach (var subject in subjectsToBeLoaded)
                {
                    this.listBoxTeacherSubjects.Items.Add(subject);
                }
            }
        }
        private void CleanForm(bool reloadTeacherCombo = false)
        {
            this.textBoxTeacherName.Text = string.Empty;
            this.textBoxTeacherLastName.Text = string.Empty;            
            this.listBoxTeacherSubjects.Items.Clear();
            this.labelError.Text = string.Empty;
            if (reloadTeacherCombo)
                this.ReloadTeacherCombo();
        }
        private void ReloadTeacherCombo()
        {
            this.buttonDeleteTeacher.Enabled = false;
            comboBoxTeachersDocuments.Items.Clear();
            this.FillTeachersCombo();
        }
        private void SetDefaultWindowsSize()
        {
            this.AutoScaleMode = AutoScaleMode.None;
            this.Size = new System.Drawing.Size(750, 550);
        }
        #endregion
    }
}
