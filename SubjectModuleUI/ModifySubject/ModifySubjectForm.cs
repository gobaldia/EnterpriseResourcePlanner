using CoreEntities.Entities;
using CoreEntities.Exceptions;
using CoreLogic.Interfaces;
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

namespace SubjectModuleUI.ModifySubject
{
    public partial class ModifySubjectForm : Form
    {
        public ModifySubjectForm()
        {
            InitializeComponent();
            SetDefaultWindowsSize();
            CheckIfIsThereAnySubjectInSystem();
            FillSubjectsComboBox();
        }

        private void SetDefaultWindowsSize()
        {
            this.AutoScaleMode = AutoScaleMode.None;
            this.Size = new System.Drawing.Size(750, 600);
        }

        private void FillSubjectsComboBox()
        {
            ISubjectLogic subjectOperations = Provider.GetInstance.GetSubjectOperations();
            List<Subject> subjects = subjectOperations.GetSubjects();

            for (int index = 0; index < subjects?.Count(); index++)
                this.comboBoxSelectSubjectToModify.Items.Add(subjects[index]);

            this.comboBoxSelectSubjectToModify.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void CheckIfIsThereAnySubjectInSystem()
        {
            ISubjectLogic subjectOperations = Provider.GetInstance.GetSubjectOperations();
            List<Subject> subjects = subjectOperations.GetSubjects();

            if (subjects.Count().Equals(0))
            {
                this.labelError.Text = "Currently there is not any subject in the system.";
                this.labelError.Visible = true;
            }
        }

        private void buttonCancelModifySubject_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void comboBoxSelectSubjectToModify_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ClearListBoxes();
            var combo = (ComboBox)sender;
            var selected = (Subject)combo.SelectedItem;
            this.textBoxCodeModifySubject.Text = selected.GetCode().ToString();
            this.textBoxNameModifySubject.Text = selected.GetName();
            FillSubjectTeachersListBox(selected.Code);
            FillSystemTeachersListBox(selected.Code);
            FillSubjectStudentsListBox(selected.Code);
            FillSystemStudentsListBox(selected.Code);
        }

        private void ClearListBoxes()
        {
            this.listBoxSystemTeachers.Items.Clear();
            this.listBoxSubjectTeachers.Items.Clear();
            this.listBoxSystemStudents.Items.Clear();
            this.listBoxSubjectStudents.Items.Clear();
        }

        private void CleanFields()
        {
            this.textBoxCodeModifySubject.Clear();
            this.textBoxNameModifySubject.Clear();
            this.listBoxSystemTeachers.Items.Clear();
            this.listBoxSubjectTeachers.Items.Clear();
            this.listBoxSystemStudents.Items.Clear();
            this.listBoxSubjectStudents.Items.Clear();
        }
        private void buttonModifySubject_Click(object sender, EventArgs e)
        {
            try
            {
                this.labelError.Visible = false;
                string name;
                int code;
                Subject newSubject = new Subject();
                Subject originalSubject = (Subject)this.comboBoxSelectSubjectToModify.SelectedItem;
                if (int.TryParse(this.textBoxCodeModifySubject.Text, out code))
                {
                    if (!string.IsNullOrWhiteSpace(this.textBoxNameModifySubject.Text))
                    {
                        newSubject.Code = code;
                        name = this.textBoxNameModifySubject.Text;
                        newSubject.Name = name;

                        List<Teacher> teachers = this.listBoxSubjectTeachers.Items.Cast<Teacher>().ToList();
                        newSubject.SetTeachers(teachers);

                        List<Student> students = this.listBoxSubjectStudents.Items.Cast<Student>().ToList();
                        newSubject.SetStudents(students);

                        ISubjectLogic subjectOperations = Provider.GetInstance.GetSubjectOperations();
                        subjectOperations.ModifySubjectByCode(originalSubject.Code, newSubject);

                        this.labelSuccess.Text = "Subject was succesfully modified.";
                        this.labelSuccess.Visible = true;
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
                this.labelError.Visible = true;
                this.labelError.Text = ex.Message;
            }
            catch (Exception ex)
            {
                this.labelError.Visible = true;
                this.labelError.Text = ex.Message;
            }
            this.ReloadComboBoxSelectSubjectToModify();
            this.CleanFields();
        }
        
        private void FillSubjectTeachersListBox(int subjectCode)
        {
            ISubjectLogic subjectOperations = Provider.GetInstance.GetSubjectOperations();
            Subject subject = subjectOperations.GetSubjectByCode(subjectCode);

            var teachersThatTeachThisSubject = subject.Teachers;
            for (int index = 0; index < teachersThatTeachThisSubject.Count; index++)
            {
                this.listBoxSubjectTeachers.Items.Add(teachersThatTeachThisSubject.ElementAt(index));
            }
        }
        private void FillSubjectStudentsListBox(int subjectCode)
        {
            ISubjectLogic subjectOperations = Provider.GetInstance.GetSubjectOperations();
            Subject subject = subjectOperations.GetSubjectByCode(subjectCode);

            var studentsOnThisSubject = subject.Students;
            for (int index = 0; index < studentsOnThisSubject?.Count; index++)
            {
                this.listBoxSubjectStudents.Items.Add(studentsOnThisSubject.ElementAt(index));
            }
        }
        private void FillSystemTeachersListBox(int subjectCode)
        {
            ITeacherLogic teacherOperations = Provider.GetInstance.GetTeacherOperations();
            ISubjectLogic subjectOperations = Provider.GetInstance.GetSubjectOperations();
            List<Teacher> systemTeachers = teacherOperations.GetTeachers();

            var subject = subjectOperations.GetSubjectByCode(subjectCode);
            var teachersOfThisSubject = subject.Teachers;
            var teachersToAddToListBox = systemTeachers.Where(t => !teachersOfThisSubject.Any(st => st.Document == t.Document)).ToList();
            for (int index = 0; index < teachersToAddToListBox.Count(); index++)
            {
                this.listBoxSystemTeachers.Items.Add(teachersToAddToListBox[index]);
            }
        }
        private void FillSystemStudentsListBox(int subjectCode)
        {
            IStudentLogic studentOperations = Provider.GetInstance.GetStudentOperations();
            ISubjectLogic subjectOperations = Provider.GetInstance.GetSubjectOperations();
            List<Student> systemStudents = studentOperations.GetStudents();

            var subject = subjectOperations.GetSubjectByCode(subjectCode);
            var studentsOfThisSubject = subject.Students;
            var studentsToAddToListBox = systemStudents.Where(t => !studentsOfThisSubject.Any(st => st.Document == t.Document)).ToList();
            for (int index = 0; index < studentsToAddToListBox?.Count(); index++)
            {
                this.listBoxSystemStudents.Items.Add(studentsToAddToListBox[index]);
            }
        }
        private void ReloadComboBoxSelectSubjectToModify()
        {
            this.comboBoxSelectSubjectToModify.Items.Clear();
            this.FillSubjectsComboBox();
    }

        private void buttonAddTeacherToSubject_Click(object sender, EventArgs e)
        {
            this.MoveFromOneListBoxToAnother(this.listBoxSystemTeachers, this.listBoxSubjectTeachers);
        }

        private void buttonDeleteTeacherToSubject_Click(object sender, EventArgs e)
        {
            this.MoveFromOneListBoxToAnother(this.listBoxSubjectTeachers, this.listBoxSystemTeachers);
        }

        private void buttonAddStudentToSubject_Click(object sender, EventArgs e)
        {
            this.MoveFromOneListBoxToAnother(this.listBoxSystemStudents, this.listBoxSubjectStudents);
        }

        private void buttonDeleteStudentToSubject_Click(object sender, EventArgs e)
        {
            this.MoveFromOneListBoxToAnother(this.listBoxSubjectStudents, this.listBoxSystemStudents);
        }

        private void MoveFromOneListBoxToAnother(ListBox listBoxFrom, ListBox listBoxTo)
        {
            var selectedItemsToMove = listBoxFrom.SelectedItem;
            if (selectedItemsToMove != null)
            {
                listBoxTo.Items.Add(selectedItemsToMove);
                listBoxFrom.Items.Remove(selectedItemsToMove);
            }
        }
    }
}
