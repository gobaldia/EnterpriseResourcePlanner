using CoreGeneralization;
using MainComponents;
using SubjectModuleUI;
using SubjectModuleUI.AddSubject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeacherModuleUI;
using TeacherModuleUI.AddTeacher;
using TeacherModuleUI.DeleteTeacher;
using TeacherModuleUI.ModifyTeacher;

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
            IAction deleteAction = new DeleteTeacherAction();
            IAction modifyAction = new ModifyTeacherAction();
            teacherActions.Add(addAction);
            teacherActions.Add(deleteAction);
            teacherActions.Add(modifyAction);

            return new TeacherModule(teacherActions);
        }

        private static Module CreateSubjectsModule()
        {
            List<IAction> SubjectActions = new List<IAction>();

            IAction addAction = new AddSubjectAction();
            SubjectActions.Add(addAction);

            return new SubjectModule(SubjectActions);
        }
    }
}