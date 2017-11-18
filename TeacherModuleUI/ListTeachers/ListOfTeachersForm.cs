using CoreEntities.Entities;
using CoreLogic;
using CoreLogic.Interfaces;
using FrameworkCommon;
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

namespace TeacherModuleUI.ListTeachers
{
    public partial class ListOfTeachersForm : Form
    {
        public ListOfTeachersForm()
        {
            InitializeComponent();
            SetDefaultWindowsSize();
            LoadTeacherListBox();
        }

        private void listBoxSystemTeachers_MouseClick(object sender, MouseEventArgs e)
        {
            Teacher selectedTeacher = this.listBoxSystemTeachers.SelectedItem as Teacher;
            if(selectedTeacher != null)
            {
                PopulateSubjectsList(selectedTeacher);
            }
        }

        #region Utility methods
        private void LoadTeacherListBox()
        {
            ITeacherLogic teacherOperations = Provider.GetInstance.GetTeacherOperations();
            List<Teacher> systemTeachers = teacherOperations.GetTeachers();

            foreach(Teacher teacher in systemTeachers)
                this.listBoxSystemTeachers.Items.Add(teacher);
        }
        private void PopulateSubjectsList(Teacher aTeacher)
        {
            this.listBoxTeacherSubjects.Items.Clear();
            List<Subject> teacherSubjects = aTeacher.GetSubjects();
            this.LoadSubjectsIntoListBox(teacherSubjects);
        }
        private void LoadSubjectsIntoListBox(List<Subject> subjectsToBeLoaded)
        {
            if (subjectsToBeLoaded?.Count > 0)
            {
                foreach (Subject subject in subjectsToBeLoaded)
                    this.listBoxTeacherSubjects.Items.Add(subject);
            }
        }
        private void SetDefaultWindowsSize()
        {
            this.AutoScaleMode = AutoScaleMode.None;
            this.Size = new System.Drawing.Size(750, 550);
        }
        #endregion
    }
}
