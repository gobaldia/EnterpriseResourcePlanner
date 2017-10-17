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

namespace SubjectModuleUI.DeleteSubject
{
    public partial class DeleteSubjectForm : Form
    {
        public DeleteSubjectForm()
        {
            InitializeComponent();
            SetDefaultWindowsSize();
            FillSubjectsComboBox();
        }

        private void SetDefaultWindowsSize()
        {
            this.AutoScaleMode = AutoScaleMode.None;
            this.Size = new System.Drawing.Size(500, 350);
        }

        private void FillSubjectsComboBox()
        {
            var subjects = ClassFactory.GetOrCreate<SubjectLogic>().GetSubjects();
            for(int index = 0; index < subjects.Count; index++)
            {
                this.comboBoxSelectSubjectToDelete.Items.Add(subjects[index]);
            }
            this.comboBoxSelectSubjectToDelete.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void buttonDeleteSubject_Click(object sender, EventArgs e)
        {
            try
            {
                if(UserConfirmsThatWantToDeleteSubject())
                {
                    var selectedSubject = this.comboBoxSelectSubjectToDelete.SelectedItem as Subject;
                    ClassFactory.GetOrCreate<SubjectLogic>().DeleteSubjectByCode(selectedSubject.Code);
                    this.labelActionResult.Text = "Subject " + selectedSubject + " was succesfully deleted.";
                    this.labelActionResult.Visible = true;
                    this.ReloadComboBoxSelectSubjectToDelete();
                }
            }
            catch (CoreException ex)
            {
                this.labelActionResult.Text = ex.Message;
                this.labelActionResult.Visible = true;
            }
            catch (Exception ex)
            {
                this.labelActionResult.Text = ex.Message;
                this.labelActionResult.Visible = true;
            }
        }

        private void ReloadComboBoxSelectSubjectToDelete()
        {
            this.comboBoxSelectSubjectToDelete.Items.Clear();
            this.FillSubjectsComboBox();
        }

        private bool UserConfirmsThatWantToDeleteSubject()
        {
            var userAnswer = MessageBox.Show("Are you sure you want to delete this subject?",
                    "Delete Subject", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            return userAnswer == DialogResult.Yes;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void comboBoxSelectSubjectToDelete_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.labelError.Visible = false;
            this.buttonDeleteSubject.Enabled = true;
            Subject selectedSubject = this.comboBoxSelectSubjectToDelete.SelectedItem as Subject;
            if(IsThisSubjectAssignedToAnyTeacher(selectedSubject) && IsThisSubjectAssignedToAnyStudent(selectedSubject))
            {
                this.labelError.Text = "This subject is assigned to some teachers and students.\nPlease go to Teacher's Module and Subject's Module and remove the subject from those teachers and students.";
                this.labelError.Visible = true;
                this.buttonDeleteSubject.Enabled = false;
            }
            else if (IsThisSubjectAssignedToAnyTeacher(selectedSubject))
            {
                this.labelError.Text = "This subject is assigned to some teachers.\nPlease go to Teacher's Module and remove the subject from those teachers.";
                this.labelError.Visible = true;
                this.buttonDeleteSubject.Enabled = false;
            }
            else if (IsThisSubjectAssignedToAnyStudent(selectedSubject))
            {
                this.labelError.Text = "This subject is assigned to some students.\nPlease go to Student's Module and remove the subject from those students.";
                this.labelError.Visible = true;
                this.buttonDeleteSubject.Enabled = false;
            }
        }

        private bool IsThisSubjectAssignedToAnyTeacher(Subject subjectToDelete)
        {
            bool isSubjectAssignedToATeacher = false;
            var selectedSubject = this.comboBoxSelectSubjectToDelete.SelectedItem as Subject;
            var teachers = ClassFactory.GetOrCreate<TeacherLogic>().GetAllTeachers();
            for(int index = 0; index < teachers.Count(); index++)
            {
                var teacherSubjects = teachers[index].GetSubjects();
                if(teacherSubjects.Any(s => s.Code == subjectToDelete.Code))
                {
                    isSubjectAssignedToATeacher = true;
                }
            }
            return isSubjectAssignedToATeacher;
        }

        private bool IsThisSubjectAssignedToAnyStudent(Subject subjectToDelete)
        {
            bool isSubjectAssignedToAStudent = false;
            var selectedSubject = this.comboBoxSelectSubjectToDelete.SelectedItem as Subject;
            var students = ClassFactory.GetOrCreate<StudentLogic>().GetStudents();
            for (int index = 0; index < students.Count(); index++)
            {
                var studentSubjects = students[index].GetSubjects();
                if (studentSubjects.Any(s => s.Code == subjectToDelete.Code))
                {
                    isSubjectAssignedToAStudent = true;
                }
            }
            return isSubjectAssignedToAStudent;
        }
    }
}
