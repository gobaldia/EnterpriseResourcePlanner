using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeacherModuleUI.AddTeacher
{
    public partial class AddTeacherForm : Form
    {
        public AddTeacherForm()
        {
            InitializeComponent();
            SetDefaultWindowsSize();
        }

        private void SetDefaultWindowsSize()
        {
            this.AutoScaleMode = AutoScaleMode.None;
            this.Size = new System.Drawing.Size(750, 550);
        }

        private void buttonAddSubjectToTeacher_Click(object sender, EventArgs e)
        {

        }

        private void buttonRemoveSubjectFromTeacher_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddTeacher_Click(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}