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

namespace StudentModuleUI.ModifyStudent
{
    public partial class ModifyStudentForm : Form
    {
        private decimal NewFeeAmount { get; set; } = 0;
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
                        HavePickupService = this.radioButtonYesPickUp.Checked,
                        NewFeeAmount = numericUpDownFeeAmount.Value != NewFeeAmount ? numericUpDownFeeAmount.Value : 0
                    };

                    if (radioButtonYesPickUp.Checked)
                    {
                        double latitud = double.Parse(textBoxLatitud.Text);
                        double longitud = double.Parse(textBoxLongitud.Text);
                        input.NewLocation = new Location(latitud, longitud);
                    }

                    IStudentLogic studentOperations = Provider.GetInstance.GetStudentOperations();
                    studentOperations.ModifyStudent(input);
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
                    IStudentLogic studentOperations = Provider.GetInstance.GetStudentOperations();
                    Student studentToModify = studentOperations.GetStudentByNumber(studentNumber);
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
            IStudentLogic studentOperations = Provider.GetInstance.GetStudentOperations();
            List<Student> systemStudents = studentOperations.GetStudents();
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
            this.numericUpDownFeeAmount.Value = 0;
            CleanListBoxes();

            this.labelError.Text = string.Empty;
        }
        private void FillFormWithStudentData(Student studentToModify)
        {
            this.textBoxName.Text = studentToModify.GetName();
            this.textBoxLastName.Text = studentToModify.GetLastName();
            this.textBoxDocument.Text = studentToModify.GetDocumentNumber();
            this.numericUpDownFeeAmount.Value = GetCurrentFeeAmount(studentToModify);
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
            ISubjectLogic subjectLogic = Provider.GetInstance.GetSubjectOperations();
            List<Subject> systemSubjects = subjectLogic.GetSubjects();
            return systemSubjects.Where(systemSubject => !studentSubjects.Any(studentSubject => systemSubject.Equals(studentSubject))).ToList();
        }
        private bool ValidateFormData()
        {
            return IsStudentMainDataNotEmpty() &&
                HaveSubjectsToStudy() &&
                IsPickupInformationValid() && IsValidFeeAmount();
        }
        private bool IsValidFeeAmount()
        {
            bool result = false;

            if (numericUpDownFeeAmount.Value <= 0)
                labelError.Text = Constants.ERROR_FEEAMOUNT;
            else
                result = true;

            return result;
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
        private decimal GetCurrentFeeAmount(Student studentToModify)
        {
            NewFeeAmount = studentToModify.Fees.Find(f => f.Date.Month.Equals(DateTime.Now.Month)).Amount;
            return NewFeeAmount;
        }
        #endregion
    }
}
