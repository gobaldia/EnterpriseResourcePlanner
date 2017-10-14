using CoreGeneralization;
using MainComponents;
using SubjectModuleUI;
using SubjectModuleUI.AddSubject;
using SubjectModuleUI.DeleteSubject;
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
            
            mainModule.AddModule(CreateTeacherModule());
            mainModule.AddModule(CreateSubjectsModule());

            Application.Run(new MainForm(mainModule));
        }

        private static Module CreateTeacherModule()
        {
            List<IAction> teacherActions = new List<IAction>();

            IAction addAction = new AddTeacherAction();
            teacherActions.Add(addAction);

            return new TeacherModule(teacherActions);
        }

        private static Module CreateSubjectsModule()
        {
            List<IAction> SubjectActions = new List<IAction>();

            IAction addAction = new AddSubjectAction();
            IAction deleteAction = new DeleteSubjectAction();
            SubjectActions.Add(addAction);
            SubjectActions.Add(deleteAction);

            return new SubjectModule(SubjectActions);
        }
    }
}