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

            this.buttonInitialiceData.Enabled = false;
            this.labelDataGenerated.Visible = true;
        }
    }
}
