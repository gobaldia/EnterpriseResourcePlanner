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

        }

        private void buttonRemoveSubjectFromStudent_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddStudent_Click(object sender, EventArgs e)
        {

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

        #region Utility methods
        private void SetDefaultWindowsSize()
        {
            this.AutoScaleMode = AutoScaleMode.None;
            this.Size = new System.Drawing.Size(750, 550);
        }
        private void LoadFormInitialData()
        {
            this.textBoxStudentNumber.Text = Student.GetNextStudentNumber().ToString();
            List<Subject> subjects = ClassFactory.GetOrCreate<SubjectLogic>().GetSubjects();
            foreach (Subject subject in subjects)
            {
                this.listBoxSystemSubjects.Items.Add(subject);
            }
        }
        #endregion        
    }
}
