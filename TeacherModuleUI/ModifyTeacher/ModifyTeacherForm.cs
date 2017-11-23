using CoreEntities.Entities;
using CoreEntities.Exceptions;
using CoreLogic.Interfaces;
using FrameworkCommon;
using FrameworkCommon.MethodParameters;
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

namespace TeacherModuleUI.ModifyTeacher
{
    public partial class ModifyTeacherForm : Form
    {
        public ModifyTeacherForm()
        {
            InitializeComponent();
            SetDefaultWindowsSize();
            LoadDocumentNumberComboBox();
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

        private void buttonRemoveSubjectFromTeacher_Click(object sender, EventArgs e)
        {
            var selectedSubject = this.listBoxTeacherSubjects.SelectedItem;
            if (selectedSubject != null)
            {
                this.listBoxSystemSubjects.Items.Add(selectedSubject);
                this.listBoxTeacherSubjects.Items.Remove(selectedSubject);
            }
        }

        private void buttonModifyTeacher_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsDocumentSelected() && NameAndLastNameNotEmpty())
                {
                    string name = textBoxTeacherName.Text;
                    string lastName = textBoxTeacherLastName.Text;
                    string document = comboBoxTeachersDocuments.SelectedItem.ToString();

                    var input = new ModifyTeacherInput
                    {
                        NewName = name,
                        NewLastName = lastName,
                        DocumentNumber = document,
                        NewSubjects = GetSelectedSubjects()
                    };

                    ITeacherLogic teacherOpertions = Provider.GetInstance.GetTeacherOperations();
                    teacherOpertions.ModifyTeacher(input);

                    this.CleanForm();
                    this.labelSuccess.Text = Constants.SUCCESS_TEACHER_MODIFICATION;
                }
                else
                {
                    this.labelError.Text = Constants.ERROR_ALL_FIELDS_REQUIRED;
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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void comboBoxTeachersDocuments_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.labelSuccess.Text = string.Empty;
                if (IsDocumentSelected())
                {
                    CleanListBoxes();

                    string documentNumber = this.comboBoxTeachersDocuments.SelectedItem.ToString();

                    ITeacherLogic teacherOpertions = Provider.GetInstance.GetTeacherOperations(); 
                    Teacher teacherToModify = teacherOpertions.GetTeacherByDocumentNumber(documentNumber);
                    this.textBoxTeacherName.Text = teacherToModify.GetName();
                    this.textBoxTeacherLastName.Text = teacherToModify.GetLastName();

                    this.PopulateListBoxes(teacherToModify);
                }
                else
                {
                    this.CleanForm();
                }
            }
            catch (CoreException ex)
            {
                CleanForm();
                this.labelError.Text = ex.Message;
            }
            catch (Exception)
            {
                CleanForm();
                this.labelError.Text = Constants.ERROR_UNEXPECTED;
            }
        }

        private void textBoxes_KeyDown(object sender, KeyEventArgs e)
        {
            this.labelSuccess.Text = string.Empty;
        }

        #region Utility methods
        private void CleanForm()
        {
            this.textBoxTeacherName.Text = string.Empty;
            this.textBoxTeacherLastName.Text = string.Empty;
            this.comboBoxTeachersDocuments.SelectedIndex = -1;
            CleanListBoxes();

            this.labelError.Text = string.Empty;
        }
        private void CleanListBoxes()
        {
            this.listBoxTeacherSubjects.Items.Clear();
            this.listBoxSystemSubjects.Items.Clear();
        }
        private void SetDefaultWindowsSize()
        {
            this.AutoScaleMode = AutoScaleMode.None;
            this.Size = new System.Drawing.Size(750, 550);
        }
        private void LoadDocumentNumberComboBox()
        {
            ITeacherLogic teacherOpertions = Provider.GetInstance.GetTeacherOperations();
            List<Teacher> systemTeachers = teacherOpertions.GetTeachers();

            foreach (Teacher teacher in systemTeachers)
                this.comboBoxTeachersDocuments.Items.Add(teacher.GetDocumentNumber());
        }
        private List<Subject> GetSubjectsThatAreNotInTeacher(List<Subject> teacherSubjects)
        {
            ISubjectLogic subjectsOperations = Provider.GetInstance.GetSubjectOperations();
            List<Subject> systemSubjects = subjectsOperations.GetSubjects();
            return systemSubjects?.Where(systemSubject => !teacherSubjects.Any(teacherSubject => systemSubject.Equals(teacherSubject))).ToList();
        }
        private List<Subject> GetSelectedSubjects()
        {
            List<Subject> newSubjects = new List<Subject>();
            foreach (Subject subject in listBoxTeacherSubjects.Items)
            {
                newSubjects.Add(subject);
            }
            return newSubjects;
        }
        private void PopulateListBoxes(Teacher teacherToModify)
        {
            List<Subject> teacherSubjects = teacherToModify.GetSubjects();
            List<Subject> systemSubjectsNotInTeacherSubjects = this.GetSubjectsThatAreNotInTeacher(teacherSubjects);

            foreach (Subject subject in teacherSubjects)
                this.listBoxTeacherSubjects.Items.Add(subject);

            foreach (Subject subject in systemSubjectsNotInTeacherSubjects)
                this.listBoxSystemSubjects.Items.Add(subject);
        }
        private bool IsDocumentSelected()
        {
            return this.comboBoxTeachersDocuments.SelectedIndex >= 0;
        }
        private bool NameAndLastNameNotEmpty()
        {
            return !string.IsNullOrEmpty(this.textBoxTeacherName.Text) && 
                !string.IsNullOrEmpty(this.textBoxTeacherLastName.Text); 
        }
        #endregion
    }
}
