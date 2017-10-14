using CoreGeneralization;
using MainComponents;
using SubjectModuleUI;
using SubjectModuleUI.AddSubject;
using SubjectModuleUI.ModifySubject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeacherModuleUI;
using TeacherModuleUI.AddTeacher;

namespace MainModuleUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            InitializationDataAndRun();
        }

        private static void InitializationDataAndRun()
        {
            MainModule mainModule = new MainModule();
            
            mainModule.AddModule(TeacherModule());
            mainModule.AddModule(SubjectModule());

            Application.Run(new MainForm(mainModule));
        }

        private static Module TeacherModule()
        {
            List<IAction> teacherActions = new List<IAction>();

            IAction addAction = new AddTeacherAction();
            teacherActions.Add(addAction);

            return new TeacherModule(teacherActions);
        }

        private static Module SubjectModule()
        {
            List<IAction> SubjectActions = new List<IAction>();

            IAction addAction = new AddSubjectAction();
            IAction modifyAction = new ModifySubjectAction();
            SubjectActions.Add(addAction);
            SubjectActions.Add(modifyAction);

            return new SubjectModule(SubjectActions);
        }
    }
}