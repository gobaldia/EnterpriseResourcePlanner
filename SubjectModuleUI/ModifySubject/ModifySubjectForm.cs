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
            var subjects = ClassFactory.GetOrCreate<SubjectLogic>().GetSubjects();
            for(int index = 0; index < subjects.Count(); index++)
            {
                this.comboBoxSelectSubjectToModify.Items.Add(subjects[index]);
            }
            this.comboBoxSelectSubjectToModify.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void CheckIfIsThereAnySubjectInSystem()
        {
            var subjects = ClassFactory.GetOrCreate<SubjectLogic>().GetSubjects();
            if (subjects.Count() == 0)
            {
                this.labelError.Text = "Currently there is not any subject in the system.";
                this.labelError.Visible = true;
            }
        }

        private void FillSubjectTeachersListBox(int subjectCode)
        {
            var subjects = ClassFactory.GetOrCreate<SubjectLogic>().GetSubjects();
            var subject = subjects.Find(s => s.Code == subjectCode);
            var teachersThatTeachThisSubject = subject.Teachers;
            for (int index = 0; index < teachersThatTeachThisSubject.Count; index++)
            {
                this.listBoxSubjectTeachers.Items.Add(teachersThatTeachThisSubject[index]);
            }
        }

        private void FillSystemTeachersListBox(int subjectCode)
        {
            List<Teacher> systemTeachers = ClassFactory.GetOrCreate<TeacherLogic>().GetAllTeachers();
            var subjects = ClassFactory.GetOrCreate<SubjectLogic>().GetSubjects();
            var subject = subjects.Find(s => s.Code == subjectCode);
            var teachersOfThisSubject = subject.Teachers;
            var teachersToAddToListBox = systemTeachers.Except(teachersOfThisSubject).ToList();
            for (int index = 0; index < teachersToAddToListBox.Count(); index++)
            {
                this.listBoxSystemTeachers.Items.Add(teachersToAddToListBox[index]);
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
        }

        private void ClearListBoxes()
        {
            this.listBoxSystemTeachers.Items.Clear();
            this.listBoxSubjectTeachers.Items.Clear();
        }

        private void buttonModifySubject_Click(object sender, EventArgs e)
        {
            this.labelError.Visible = false;
            int code;
            string name;
            Subject newSubject = new Subject();
            Subject originalSubject = (Subject) this.comboBoxSelectSubjectToModify.SelectedItem;
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

                    ClassFactory.GetOrCreate<SubjectLogic>().ModifySubjectByCode(originalSubject.Code, newSubject);

                    var materias = ClassFactory.GetOrCreate<SubjectLogic>().GetSubjects();

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
