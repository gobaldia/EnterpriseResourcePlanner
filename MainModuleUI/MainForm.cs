using CoreEntities.Entities;
using CoreLogic;
using FrameworkCommon;
using FrameworkCommon.MethodParameters;
using MainComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainModuleUI
{
    public partial class MainForm : Form
    {
        private MainModule MainModule { get; set; }
        public MainForm(MainModule mainModule)
        {
            this.MainModule = mainModule;
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            this.SetDefaultWindowsSize();
            this.CreateMenu(this.MainModule);
        }

        private void SetDefaultWindowsSize()
        {
            this.Size = new System.Drawing.Size(750, 500);
        }

        private void CreateMenu(MainModule mainModule)
        {
            ToolStripMenuItem mainMenuItem = new ToolStripMenuItem("Menu");
            this.mainMenuStrip.Items.Add(mainMenuItem);

            foreach (var module in mainModule.GetModules())
            {
                MenuMethodInput addModuleInput = new MenuMethodInput { Module = module, MenuItem = mainMenuItem };
                ToolStripMenuItem newmMenuItem = this.AddModuleToMenu(addModuleInput);
                foreach (var action in module.GetActions())
                {
                    var addActionInput = new MenuMethodInput
                    {
                        Module = module,
                        Action = action,
                        MenuItem = newmMenuItem
                    };
                    this.AddActionToModule(addActionInput);
                }
            }
        }

        private ToolStripMenuItem AddModuleToMenu(MenuMethodInput input)
        {
            var newMenuModule = new ToolStripMenuItem(input.Module.GetName(), null);
            input.MenuItem.DropDownItems.Add(newMenuModule);
            return newMenuModule;
        }

        private void AddActionToModule(MenuMethodInput input)
        {
            var actionSubMenu = new ToolStripMenuItem(input.Action.GetName(), null);
            actionSubMenu.Click += (sender, e) => ManageActionClick(input, e);
            input.MenuItem.DropDownItems.Add(actionSubMenu);
        }

        private void ManageActionClick(MenuMethodInput input, System.EventArgs e)
        {
            input.Action.Call();
        }

        private void buttonInitialiceData_Click(object sender, EventArgs e)
        {
            #region Create and add subjects to the system
            Subject subject1 = new Subject(1234, "Maths");
            Subject subject2 = new Subject(5678, "Physics");
            Subject subject3 = new Subject(9101, "Chemistry");
            Subject subject4 = new Subject(8529, "History");
            Subject subject5 = new Subject(6547, "Geography");
            Subject subject6 = new Subject(0002, "Algorithms");

            ClassFactory.GetOrCreate<SubjectLogic>().AddSubject(subject1);
            ClassFactory.GetOrCreate<SubjectLogic>().AddSubject(subject2);
            ClassFactory.GetOrCreate<SubjectLogic>().AddSubject(subject3);
            ClassFactory.GetOrCreate<SubjectLogic>().AddSubject(subject4);
            ClassFactory.GetOrCreate<SubjectLogic>().AddSubject(subject5);
            ClassFactory.GetOrCreate<SubjectLogic>().AddSubject(subject6);
            #endregion

            #region Create and add teachers to the system
            Teacher teacher1 = new Teacher("Luis", "Suarez", "1234567-8");
            teacher1.AddSubjectToTeach(subject1);
            teacher1.AddSubjectToTeach(subject2);

            Teacher teacher2 = new Teacher("Edinson", "Cavani", "3216548-5");
            teacher2.AddSubjectToTeach(subject5);
            teacher2.AddSubjectToTeach(subject2);
            teacher2.AddSubjectToTeach(subject3);

            Teacher teacher3 = new Teacher("Diego", "Godin", "8529631-3");
            teacher3.AddSubjectToTeach(subject2);
            teacher3.AddSubjectToTeach(subject4);
            teacher3.AddSubjectToTeach(subject6);

            Teacher teacher4 = new Teacher("Jose Maria", "Gimenez", "2365489-4");
            Teacher teacher5 = new Teacher("Fernando", "Muslera", "3258746-3");
            Teacher teacher6 = new Teacher("Palito", "Pereira", "9514786-9");
            teacher6.AddSubjectToTeach(subject1);
            teacher6.AddSubjectToTeach(subject2);
            teacher6.AddSubjectToTeach(subject3);
            teacher6.AddSubjectToTeach(subject4);
            teacher6.AddSubjectToTeach(subject5);
            teacher6.AddSubjectToTeach(subject6);

            ClassFactory.GetOrCreate<TeacherLogic>().AddTeacher(teacher1);
            ClassFactory.GetOrCreate<TeacherLogic>().AddTeacher(teacher2);
            ClassFactory.GetOrCreate<TeacherLogic>().AddTeacher(teacher3);
            ClassFactory.GetOrCreate<TeacherLogic>().AddTeacher(teacher4);
            ClassFactory.GetOrCreate<TeacherLogic>().AddTeacher(teacher5);
            ClassFactory.GetOrCreate<TeacherLogic>().AddTeacher(teacher6);
            #endregion

            #region Create packs of subjects
            List<Subject> packOfSubjects1 = new List<Subject>();
            packOfSubjects1.Add(subject1);
            packOfSubjects1.Add(subject3);
            packOfSubjects1.Add(subject4);
            List<Subject> packOfSubjects2 = new List<Subject>();
            packOfSubjects2.Add(subject6);
            List<Subject> packOfSubjects3 = new List<Subject>();
            packOfSubjects3.Add(subject1);
            packOfSubjects3.Add(subject2);
            packOfSubjects3.Add(subject3);
            packOfSubjects3.Add(subject4);
            packOfSubjects3.Add(subject5);
            packOfSubjects3.Add(subject6);
            List<Subject> packOfSubjects4 = new List<Subject>();
            packOfSubjects4.Add(subject6);
            packOfSubjects4.Add(subject4);
            #endregion

            #region Add students to the system
            var inputStudent1 = new Student
            {
                Document = "5555555-8",
                Name = "Claudia",
                LastName = "Fernandez",
                Location = new Location(-42.214568, 1.557),
                Subjects = packOfSubjects1,
                StudentNumber = 1
            };

            var inputStudent2 = new Student
            {
                Document = "4444444-3",
                Name = "Gaston",
                LastName = "Silva",
                Location = new Location(1.214568, -170.123456),
                Subjects = packOfSubjects2,
                StudentNumber = 2
            };

            var inputStudent3 = new Student
            {
                Name = "Gallo",
                LastName = "Claudio",
                Document = "3333333-8",
                Location = new Location(12.214568, -17.123456),
                Subjects = packOfSubjects1,
                StudentNumber = 3
            };

            var inputStudent4 = new Student
            {
                Name = "Elon",
                LastName = "Musk",
                Document = "4545456-5",
                Location = new Location(62.214568, 1.123456),
                Subjects = packOfSubjects4,
                StudentNumber = 4
            };

            var inputStudent5 = new Student
            {
                Name = "Mark",
                LastName = "Zuckerberg",
                Document = "9999987-1",
                Location = new Location(-3.555568, 55.557),
                Subjects = packOfSubjects3,
                StudentNumber = 5
            };

            var inputStudent6 = new Student
            {
                Name = "Bart",
                LastName = "Simpson",
                Document = "9999987-2",
                Location = new Location(-3.473568, 55.557123),
                Subjects = packOfSubjects1,
                StudentNumber = 6
            };

            var inputStudent7 = new Student
            {
                Name = "Lisa",
                LastName = "Simpson",
                Document = "9999987-3",
                Location = new Location(-3.473568, 55.557123),
                Subjects = packOfSubjects3,
                StudentNumber = 7
            };

            var inputStudent8 = new Student
            {
                Name = "Bob",
                LastName = "Patiño",
                Document = "1999987-1",
                Location = new Location(-31.235211, -55.557),
                Subjects = packOfSubjects2,
                StudentNumber = 8
            };

            var inputStudent9 = new Student
            {
                Name = "Helga",
                LastName = "Pataki",
                Document = "9992387-1",
                Location = new Location(-4.180324, -16.123456),
                Subjects = packOfSubjects2,
                StudentNumber = 9
            };

            var inputStudent10 = new Student
            {
                Name = "Bilbo",
                LastName = "Bolson",
                Document = "1239987-1",
                Location = new Location(-19.152412, 72.182342),
                Subjects = packOfSubjects1,
                StudentNumber = 10
            };

            ClassFactory.GetOrCreate<StudentLogic>().AddStudent(inputStudent1);
            ClassFactory.GetOrCreate<StudentLogic>().AddStudent(inputStudent2);
            ClassFactory.GetOrCreate<StudentLogic>().AddStudent(inputStudent3);
            ClassFactory.GetOrCreate<StudentLogic>().AddStudent(inputStudent4);
            ClassFactory.GetOrCreate<StudentLogic>().AddStudent(inputStudent5);
            ClassFactory.GetOrCreate<StudentLogic>().AddStudent(inputStudent6);
            ClassFactory.GetOrCreate<StudentLogic>().AddStudent(inputStudent7);
            ClassFactory.GetOrCreate<StudentLogic>().AddStudent(inputStudent8);
            ClassFactory.GetOrCreate<StudentLogic>().AddStudent(inputStudent9);
            ClassFactory.GetOrCreate<StudentLogic>().AddStudent(inputStudent10);
            #endregion

            #region Create and add vehicles to the system
            Vehicle vehicleOne = new Vehicle("SBA0001", 4);
            Vehicle vehicleTwo = new Vehicle("SBA1015", 5);

            ClassFactory.GetOrCreate<VehicleLogic>().AddVehicle(vehicleOne);
            ClassFactory.GetOrCreate<VehicleLogic>().AddVehicle(vehicleTwo);
            #endregion
            this.buttonInitialiceData.Enabled = false;
            this.labelDataGenerated.Visible = true;
        }
    }
}
