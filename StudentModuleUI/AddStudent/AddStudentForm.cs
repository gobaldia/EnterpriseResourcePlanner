using CoreEntities.Entities;
using CoreEntities.Exceptions;
using CoreLogic;
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

namespace StudentModuleUI.AddStudent
{
    public partial class AddStudentForm : Form
    {
        public AddStudentForm()
        {
            InitializeComponent();
            SetDefaultWindowsSize();
            LoadFormInitialData();
        }

        private void buttonAddSubjectToStudent_Click(object sender, EventArgs e)
        {
            var selectedSubject = this.listBoxSystemSubjects.SelectedItem;
            if (selectedSubject != null)
            {
                this.listBoxStudentSubjects.Items.Add(selectedSubject);
                this.listBoxSystemSubjects.Items.Remove(selectedSubject);
            }
        }
        private void buttonRemoveSubjectFromStudent_Click(object sender, EventArgs e)
        {
            var selectedSubject = this.listBoxStudentSubjects.SelectedItem;
            if (selectedSubject != null)
            {
                this.listBoxSystemSubjects.Items.Add(selectedSubject);
                this.listBoxStudentSubjects.Items.Remove(selectedSubject);
            }
        }
        private void buttonAddStudent_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFormData())
                {
                    labelError.Text = string.Empty;
                    var newStudent = this.CreateStudent();

                    IStudentLogic studentOperations = Provider.GetInstance.GetStudentOperations();
                    studentOperations.AddStudent(newStudent);

                    this.CleanForm();
                    this.labelSuccess.Text = Constants.SUCCESS_STUDENT_REGISTRATION;
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
        private void radioButtonPickUp_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonYesPickUp.Checked)
            {
                textBoxLatitud.Enabled = true;
                textBoxLongitud.Enabled = true;
            }
            else
            {
                textBoxLatitud.Text = string.Empty;
                textBoxLongitud.Text = string.Empty;
                textBoxLatitud.Enabled = false;
                textBoxLongitud.Enabled = false;
            }
        }
        private void textBoxes_KeyDown(object sender, KeyEventArgs e)
        {
            this.labelSuccess.Text = string.Empty;
            this.labelError.Text = string.Empty;
        }

        #region Utility methods
        private void SetDefaultWindowsSize()
        {
            this.AutoScaleMode = AutoScaleMode.None;
            this.Size = new System.Drawing.Size(750, 550);
        }
        private void LoadFormInitialData()
        {
            IStudentLogic studentOperations = Provider.GetInstance.GetStudentOperations();
            this.textBoxStudentNumber.Text = studentOperations.GetNextStudentNumber().ToString();

            ISubjectLogic subjectOperations = Provider.GetInstance.GetSubjectOperations();
            List<Subject> subjects = subjectOperations.GetSubjects();

            foreach (Subject subject in subjects)
                this.listBoxSystemSubjects.Items.Add(subject);
        }
        private bool ValidateFormData()
        {
            return IsStudentMainDataNotEmpty() &&
                HaveSubjectsToStudy() &&
                IsPickupInformationValid();
        }
        private Student CreateStudent()
        {
            var newStudent = new Student
            {
                Name = textBoxName.Text,
                LastName = textBoxLastName.Text,
                Document = textBoxDocument.Text,
                StudentNumber = Convert.ToInt32(textBoxStudentNumber.Text),
                Subjects = this.GetSelectedSubjects()
            };

            if (radioButtonYesPickUp.Checked)
            {
                double latitud = double.Parse(textBoxLatitud.Text);
                double longitud = double.Parse(textBoxLongitud.Text);
                newStudent.Location = new Location(latitud, longitud);
                newStudent.SetPickUpService(true);
            }

            return newStudent;
        }
        private bool IsPickupInformationValid()
        {
            bool result = radioButtonNoPickUp.Checked;

            if (radioButtonYesPickUp.Checked)
            {
                result = !string.IsNullOrEmpty(textBoxLatitud.Text) &&
                !string.IsNullOrEmpty(textBoxLongitud.Text) && CoordenatesHaveValidFormat();
            }

            if (!result)
                labelError.Text = Constants.ERROR_VALIDCOORDENATES_REQUIRED;

            return result;
        }
        private bool CoordenatesHaveValidFormat()
        {
            double parsedLatitud;
            double parsedLongitud;

            return double.TryParse(textBoxLatitud.Text, out parsedLatitud) &&
                double.TryParse(textBoxLongitud.Text, out parsedLongitud);
        }
        private bool IsStudentMainDataNotEmpty()
        {
            bool result = !string.IsNullOrEmpty(textBoxDocument.Text) &&
                !string.IsNullOrEmpty(textBoxName.Text) &&
                !string.IsNullOrEmpty(textBoxLastName.Text);

            if (!result)
                labelError.Text = Constants.ERROR_STUDENT_INFO_REQUIRED;

            return result;
        }
        private bool HaveSubjectsToStudy()
        {
            bool result = listBoxStudentSubjects.Items.Count > 0;

            if (!result)
                labelError.Text = Constants.ERROR_SUBJECTS_REQUIRED;

            return result;
        }
        private void CleanForm()
        {
            textBoxDocument.Text = string.Empty;
            textBoxName.Text = string.Empty;
            textBoxLastName.Text = string.Empty;
            radioButtonNoPickUp.Checked = true;
            textBoxLatitud.Text = string.Empty;
            textBoxLatitud.Enabled = false;
            textBoxLongitud.Text = string.Empty;
            textBoxLongitud.Enabled = false;
            listBoxStudentSubjects.Items.Clear();
            listBoxSystemSubjects.Items.Clear();
            LoadFormInitialData();

        }
        private List<Subject> GetSelectedSubjects()
        {
            List<Subject> subjectsToBeAdded = new List<Subject>();
            foreach (Subject subject in this.listBoxStudentSubjects.Items)
            {
                subjectsToBeAdded.Add(subject);
            }
            return subjectsToBeAdded;
        }
        #endregion
    }
}