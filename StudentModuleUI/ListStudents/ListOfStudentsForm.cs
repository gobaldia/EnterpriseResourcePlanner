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

namespace StudentModuleUI.ListStudents
{
    public partial class ListOfStudentsForm : Form
    {
        public ListOfStudentsForm()
        {
            InitializeComponent();
            SetDefaultWindowsSize();
            LoadStudentsListBox();
        }

        private void listBoxSystemStudents_MouseClick(object sender, MouseEventArgs e)
        {
            Student selectedStudent = this.listBoxSystemStudents.SelectedItem as Student;
            if (selectedStudent != null)
            {
                PopulateSubjectsList(selectedStudent);
            }
        }

        #region Utility Methods
        private void LoadStudentsListBox()
        {
            IStudentLogic studentOperations = Provider.GetInstance.GetStudentOperations();
            List<Student> systemStudents = studentOperations.GetStudents(true);
            foreach (Student student in systemStudents)
            {
                this.listBoxSystemStudents.Items.Add(student);
            }
        }
        private void PopulateSubjectsList(Student aStudent)
        {
            this.listBoxStudentSubjects.Items.Clear();
            foreach (Subject subject in aStudent.GetSubjects())
            {
                this.listBoxStudentSubjects.Items.Add(subject);
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
