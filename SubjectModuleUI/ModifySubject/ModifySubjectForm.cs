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
            var datasource = ClassFactory.GetOrCreate<SubjectLogic>().GetSubjects();
            this.comboBoxSelectSubjectToModify.DataSource = datasource;
            this.comboBoxSelectSubjectToModify.DisplayMember = "Name";
            this.comboBoxSelectSubjectToModify.ValueMember = "Code";
            this.comboBoxSelectSubjectToModify.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void FillSubjectTeachersListBox(int subjectCode)
        {
            var subjects = ClassFactory.GetOrCreate<SubjectLogic>().GetSubjects();
            var subject = subjects.Find(s => s.Code == subjectCode);
            var datasource = subject.Teachers;
            this.listBoxSubjectTeachers.DataSource = datasource;
            this.listBoxSubjectTeachers.DisplayMember = "Name";
            //this.listBoxSubjectTeachers.ValueMember = "Document";
        }

        private void FillSystemTeachersListBox(int subjectCode)
        {
            var teachers = ClassFactory.GetOrCreate<TeacherLogic>().GetTeachers();
            //var subject = subjects.Find(s => s.Code == subjectCode);
            var datasource = teachers;
            this.listBoxSystemTeachers.DataSource = datasource;
            this.listBoxSystemTeachers.DisplayMember = "Name";
            //this.listBoxSubjectTeachers.ValueMember = "Document";
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
            int originalCode = GetCodeOfSubjectToBeModified();
            int code;
            string name;
            Subject subject = new Subject();
            if (int.TryParse(this.textBoxCodeModifySubject.Text, out code))
            {
                if (!string.IsNullOrWhiteSpace(this.textBoxNameModifySubject.Text))
                {
                    subject.Code = code;
                    name = this.textBoxNameModifySubject.Text;
                    subject.Name = name;

                    ClassFactory.GetOrCreate<SubjectLogic>().ModifySubjectByCode(originalCode, subject);
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

        public int GetCodeOfSubjectToBeModified()
        {
            int originalCode;
            var selected = this.comboBoxSelectSubjectToModify.SelectedValue.ToString();
            try
            {
                int.TryParse(selected, out originalCode);
            }
            catch
            {
                throw new CoreException("Subject's code must be a number");
            }
            return originalCode;
        }
    }
}
