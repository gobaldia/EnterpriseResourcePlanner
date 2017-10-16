using CoreGeneralization;
using MainComponents;
using StudentModuleUI;
using StudentModuleUI.AddStudent;
using StudentModuleUI.ModifyStudent;
using SubjectModuleUI;
using SubjectModuleUI.AddSubject;
using SubjectModuleUI.DeleteSubject;
using SubjectModuleUI.ModifySubject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeacherModuleUI;
using TeacherModuleUI.AddTeacher;
using TeacherModuleUI.DeleteTeacher;
using TeacherModuleUI.ListTeachers;
using TeacherModuleUI.ModifyTeacher;
using VehicleModuleUI;
using VehicleModuleUI.AddVehicle;
using VehicleModuleUI.DeleteVehicle;
using VehicleModuleUI.ModifyVehicle;

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
            mainModule.AddModule(CreateStudentModule());
            mainModule.AddModule(CreateSubjectModule());
            mainModule.AddModule(CreateVehicleModule());

            Application.Run(new MainForm(mainModule));
        }

        private static Module CreateTeacherModule()
        {
            List<IAction> teacherActions = new List<IAction>();

            IAction addAction = new AddTeacherAction();
            IAction deleteAction = new DeleteTeacherAction();
            IAction modifyAction = new ModifyTeacherAction();
            IAction listAction = new ListTeachersAction();
            teacherActions.Add(addAction);
            teacherActions.Add(deleteAction);
            teacherActions.Add(modifyAction);
            teacherActions.Add(listAction);

            return new TeacherModule(teacherActions);
        }

        private static Module CreateStudentModule()
        {
            List<IAction> studentActions = new List<IAction>();

            IAction addAction = new AddStudentAction();
            IAction modifyAction = new ModifyStudentAction();
            studentActions.Add(addAction);
            studentActions.Add(modifyAction);

            return new StudentModule(studentActions);
        }

        private static Module CreateSubjectModule()
        {
            List<IAction> SubjectActions = new List<IAction>();

            IAction addAction = new AddSubjectAction();
            IAction deleteAction = new DeleteSubjectAction();
            IAction modifyAction = new ModifySubjectAction();
            SubjectActions.Add(addAction);
            SubjectActions.Add(deleteAction);
            SubjectActions.Add(modifyAction);

            return new SubjectModule(SubjectActions);
        }

        private static Module CreateVehicleModule()
        {
            List<IAction> VehicleActions = new List<IAction>();

            IAction addAction = new AddVehicleAction();
            IAction deleteAction = new DeleteVehicleAction();
            IAction modifyAction = new ModifyVehicleAction();
            VehicleActions.Add(addAction);
            VehicleActions.Add(deleteAction);
            VehicleActions.Add(modifyAction);

            return new VehicleModule(VehicleActions);
        }
    }
}