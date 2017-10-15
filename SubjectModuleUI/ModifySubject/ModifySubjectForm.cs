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
            FillSubjectsComboBox();
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

        private void FillSubjectTeachersListBox(int subjectCode)
        {
            var subjects = ClassFactory.GetOrCreate<SubjectLogic>().GetSubjects();
            var subject = subjects.Find(s => s.Code == subjectCode);
            var teachers = subject.Teachers;
            for (int index = 0; index < teachers.Count; index++)
            {
                this.listBoxSubjectTeachers.Items.Add(subjects[index]);
            }
        }

        private void FillSystemTeachersListBox(int subjectCode)
        {
            List<Teacher> teachers = ClassFactory.GetOrCreate<TeacherLogic>().GetTeachers();
            for(int index = 0; index < teachers.Count(); index++)
            {
                this.listBoxSystemTeachers.Items.Add(teachers[index]);
            }
        }

        private void buttonCancelModifySubject_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void comboBoxSelectSubjectToModify_SelectedIndexChanged(object sender, EventArgs e)
        {
            var combo = (ComboBox)sender;
            var selected = (Subject)combo.SelectedItem;
            this.textBoxCodeModifySubject.Text = selected.GetCode().ToString();
            this.textBoxNameModifySubject.Text = selected.GetName();
            FillSubjectTeachersListBox(selected.Code);
            FillSystemTeachersListBox(selected.Code);
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

                    //separar este metodo
                    List<Teacher> teachers = this.listBoxSubjectTeachers.Items.Cast<Teacher>().ToList();
                    newSubject.SetTeachers(teachers);

                    ClassFactory.GetOrCreate<SubjectLogic>().ModifySubjectByCode(originalSubject.Code, newSubject);

                    var materias = ClassFactory.GetOrCreate<SubjectLogic>().GetSubjects();
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
            var selectedTeacher = this.listBoxSystemTeachers.SelectedItem;
            if(selectedTeacher != null)
            {
                this.listBoxSubjectTeachers.Items.Add(selectedTeacher);
                this.listBoxSystemTeachers.Items.Remove(selectedTeacher);
            }
        }
    }
}
