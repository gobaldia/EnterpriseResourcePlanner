using CoreEntities.Entities;
using CoreEntities.Exceptions;
using CoreLogic.Interfaces;
using FrameworkCommon;
using ProviderManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeacherModuleUI.AddTeacher
{
    public partial class AddTeacherForm : Form
    {
        private List<Subject> subjectsToBeAdded = new List<Subject>();
        public AddTeacherForm()
        {
            InitializeComponent();
            SetDefaultWindowsSize();
            LoadFormData();
        }

        #region Form event methods
        private void buttonAddTeacher_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextboxesNotEmpty())
                {
                    var newTeacher = CreateTeacher();
                    ITeacherLogic teacherOperations = Provider.GetInstance.GetTeacherOperations();
                    teacherOperations.AddTeacher(newTeacher);

                    this.CleanForm();
                    this.labelSuccess.Text = Constants.SUCCESS_TEACHERREGISTRATION; ;
                }
                else
                {
                    this.labelError.Text = Constants.ERROR_ALL_FIELDS_REQUIRED;
                }
            }
            catch (CoreException ex)
            {
                labelError.Text = ex.Message;
            }
            catch (Exception)
            {
                this.labelError.Text = Constants.ERROR_UNEXPECTED;
                //TODO: Try log the error somewhere.
            }
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void buttonRemoveSubjectFromTeacher_Click(object sender, EventArgs e)
        {
            var selectedSubject = this.listBoxTeacherSubjects.SelectedItem;
            if (selectedSubject != null)
            {
                this.listBoxSystemSubjects.Items.Add(selectedSubject);
                this.listBoxTeacherSubjects.Items.Remove(selectedSubject);
            }
        }
        private void buttonAddSubjectToTeacher_Click(object sender, EventArgs e)
        {
            var selectedSubject = this.listBoxSystemSubjects.SelectedItem;
            if (selectedSubject != null)
            {
                this.listBoxTeacherSubjects.Items.Add(selectedSubject);
                this.listBoxSystemSubjects.Items.Remove(selectedSubject);
            }
        }
        private void cleanSuccessOn_KeyDown(object sender, KeyEventArgs e)
        {
            this.labelSuccess.Text = string.Empty;
        }
        #endregion

        #region Utility methods
        private void LoadFormData()
        {
            ISubjectLogic subjectOperations = Provider.GetInstance.GetSubjectOperations();
            List<Subject> subjects = subjectOperations.GetSubjects();
            foreach (Subject subject in subjects)
            {
                this.listBoxSystemSubjects.Items.Add(subject);
            }
        }
        private void SetDefaultWindowsSize()
        {
            this.AutoScaleMode = AutoScaleMode.None;
            this.Size = new System.Drawing.Size(750, 550);
        }
        private void CleanForm()
        {
            this.labelError.Text = string.Empty;
            this.textBoxTeacherName.Text = string.Empty;
            this.textBoxTeacherLastName.Text = string.Empty;
            this.textBoxTeacherDocument.Text = string.Empty;
            this.ResetListBoxes();
            this.LoadFormData();
        }
        private void ResetListBoxes()
        {
            this.listBoxSystemSubjects.Items.Clear();
            this.listBoxTeacherSubjects.Items.Clear();
        }
        private Teacher CreateTeacher()
        {
            string name = textBoxTeacherName.Text;
            string lastName = textBoxTeacherLastName.Text;
            string document = textBoxTeacherDocument.Text;

            Teacher newTeacher = new Teacher(name, lastName, document);
            this.AddSubjectsToTeacher(newTeacher);
            return newTeacher;
        }
        private void AddSubjectsToTeacher(Teacher aTeacher)
        {
            foreach (var subject in this.listBoxTeacherSubjects.Items)
            {
                aTeacher.AddSubjectToTeach((Subject)subject);
            }
        }
        private bool TextboxesNotEmpty()
        {
            return !string.IsNullOrEmpty(textBoxTeacherName.Text) ||
                !string.IsNullOrEmpty(textBoxTeacherLastName.Text) ||
                !string.IsNullOrEmpty(textBoxTeacherDocument.Text);
        }
        #endregion
    }
}