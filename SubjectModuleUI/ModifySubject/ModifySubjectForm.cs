using CoreEntities.Entities;
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
        }

        private void buttonModifySubject_Click(object sender, EventArgs e)
        {
            this.labelError.Visible = false;
            int originalCode;
            var selected = this.comboBoxSelectSubjectToModify.SelectedValue.ToString();
            int.TryParse(selected, out originalCode);
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

                    //var algo = ClassFactory.GetOrCreate<SubjectLogic>().ModifySubjectByCode()

                    //this.ClearAddSubjectForm();
                    //this.ShowCorrectlyAddedSubjectMessage(code, name);
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
    }
}
