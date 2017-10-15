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

namespace SubjectModuleUI.DeleteSubject
{
    public partial class DeleteSubjectForm : Form
    {
        public DeleteSubjectForm()
        {
            InitializeComponent();
            FillSubjectsComboBox();
        }

        private void FillSubjectsComboBox()
        {
            var datasource = ClassFactory.GetOrCreate<SubjectLogic>().GetSubjects();
            this.comboBoxSelectSubjectToDelete.DataSource = datasource;
            this.comboBoxSelectSubjectToDelete.DisplayMember = "Name";
            this.comboBoxSelectSubjectToDelete.ValueMember = "Code";
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
                    this.labelActionResult.Text = "Subject " + selectedSubject.Name + " was succesfully deleted";
                    this.labelActionResult.Visible = true;
                }
            }
            catch(Exception ex)
            {
                this.labelActionResult.Text = ex.Message;
                this.labelActionResult.Visible = true;
            }
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
    }
}
