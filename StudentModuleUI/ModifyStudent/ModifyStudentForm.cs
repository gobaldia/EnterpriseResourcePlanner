using CoreEntities.Entities;
using CoreEntities.Exceptions;
using CoreLogic;
using DataAccess;
using FrameworkCommon;
using FrameworkCommon.MethodParameters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentModuleUI.ModifyStudent
{
    public partial class ModifyStudentForm : Form
    {
        public ModifyStudentForm()
        {
            InitializeComponent();
            SetDefaultWindowsSize();
            LoadDocumentNumberComboBox();
        }

        private void buttonModifyStudent_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsStudentNumberSelected() && ValidateFormData())
                {
                    labelError.Text = string.Empty;

                    var input = new ModifyStudentInput
                    {
                        NewName = textBoxName.Text,
                        NewLastName = textBoxLastName.Text,
                        StudentNumber = int.Parse(this.comboBoxStudentsNumber.SelectedItem.ToString()),
                        NewSubjects = this.GetSelectedSubjects(),
                        HavePickupService = this.radioButtonYesPickUp.Checked 
                    };

                    if (radioButtonYesPickUp.Checked)
                    {
                        double latitud = double.Parse(textBoxLatitud.Text);
                        double longitud = double.Parse(textBoxLongitud.Text);
                        input.NewLocation = new Location(latitud, longitud);
                    }

                    ClassFactory.GetOrCreate<StudentLogic>().ModifyStudent(input);
                    this.CleanForm();
                    this.labelSuccess.Text = Constants.SUCCESS_STUDENT_MODIFICATION;
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

        private void comboBoxStudentsNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.labelSuccess.Text = string.Empty;
                if (IsStudentNumberSelected())
                {
                    CleanListBoxes();

                    int studentNumber = int.Parse(this.comboBoxStudentsNumber.SelectedItem.ToString());
                    Student studentToModify = ClassFactory.GetOrCreate<StudentLogic>().GetStudentByNumber(studentNumber);
                    FillFormWithStudentData(studentToModify);
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
        }

        #region Utility methods
        private void SetDefaultWindowsSize()
        {
            this.AutoScaleMode = AutoScaleMode.None;
            this.Size = new System.Drawing.Size(750, 550);
        }
        private void LoadDocumentNumberComboBox()
        {
            List<Student> systemStudents = SystemData.GetInstance.GetStudents();
            foreach (Student student in systemStudents)
            {
                this.comboBoxStudentsNumber.Items.Add(student.GetStudentNumber());
            }
        }
        private bool IsStudentNumberSelected()
        {
            return this.comboBoxStudentsNumber.SelectedIndex >= 0;
        }
        private void CleanListBoxes()
        {
            this.listBoxStudentSubjects.Items.Clear();
            this.listBoxSystemSubjects.Items.Clear();
        }
        private void CleanForm()
        {
            this.textBoxName.Text = string.Empty;
            this.textBoxLastName.Text = string.Empty;
            this.textBoxDocument.Text = string.Empty;
            this.radioButtonNoPickUp.Checked = true;
            this.textBoxLatitud.Text = string.Empty;
            this.textBoxLongitud.Text = string.Empty;
            this.textBoxLatitud.Enabled = false;
            this.textBoxLongitud.Enabled = false;
            this.comboBoxStudentsNumber.SelectedIndex = -1;
            CleanListBoxes();

            this.labelError.Text = string.Empty;
        }
        private void FillFormWithStudentData(Student studentToModify)
        {
            this.textBoxName.Text = studentToModify.GetName();
            this.textBoxLastName.Text = studentToModify.GetLastName();
            this.textBoxDocument.Text = studentToModify.GetDocumentNumber();

            LoadPickupServiceData(studentToModify);
            this.PopulateListBoxes(studentToModify);
        }
        private void LoadPickupServiceData(Student studentToModify)
        {
            if (studentToModify.HavePickUpService)
            {
                this.radioButtonYesPickUp.Checked = true;
                this.textBoxLatitud.Enabled = true;
                this.textBoxLongitud.Enabled = true;
                Location studentLocation = studentToModify.GetLocation();
                this.textBoxLatitud.Text = studentLocation.GetLatitud().ToString();
                this.textBoxLongitud.Text = studentLocation.GetLongitud().ToString();
            }
            else
            {
                this.radioButtonNoPickUp.Checked = true;
                this.textBoxLatitud.Enabled = false;
                this.textBoxLongitud.Enabled = false;
                this.textBoxLatitud.Text = string.Empty;
                this.textBoxLongitud.Text = string.Empty;
            }
        }
        private void PopulateListBoxes(Student studentToModify)
        {
            List<Subject> studentSubjects = studentToModify.GetSubjects();
            List<Subject> systemSubjectsNotInStudentSubjects = this.GetSubjectsThatAreNotInTeacher(studentSubjects);

            foreach (Subject subject in studentSubjects)
                this.listBoxStudentSubjects.Items.Add(subject);

            foreach (Subject subject in systemSubjectsNotInStudentSubjects)
                this.listBoxSystemSubjects.Items.Add(subject);

        }
        private List<Subject> GetSubjectsThatAreNotInTeacher(List<Subject> studentSubjects)
        {
            List<Subject> systemSubjects = SystemData.GetInstance.GetSubjects();
            return systemSubjects.Where(systemSubject => !studentSubjects.Any(studentSubject => systemSubject.Equals(studentSubject))).ToList();
        }
        private bool ValidateFormData()
        {
            return IsStudentMainDataNotEmpty() &&
                HaveSubjectsToStudy() &&
                IsPickupInformationValid();
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
