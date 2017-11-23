using ActivityModuleUI;
using ActivityModuleUI.AddActivity;
using ActivityModuleUI.DeleteActivity;
using ActivityModuleUI.ModifyActivity;
using CoreGeneralization;
using MainComponents;
using PaymentModuleUI;
using PaymentModuleUI.PayActivity;
using PaymentModuleUI.PayFee;
using StudentModuleUI;
using StudentModuleUI.AddStudent;
using StudentModuleUI.DeleteStudent;
using StudentModuleUI.ListStudents;
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
using VehicleModuleUI.CalculateRoutes;
using VehicleModuleUI.DeleteVehicle;
using VehicleModuleUI.ListVehicles;
using VehicleModuleUI.ModifyVehicle;

namespace MainModuleUI
{
    static class Program
    {
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
            mainModule.AddModule(CreateActivityModule());
            mainModule.AddModule(CreatePaymentModule());

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
            IAction deleteAction = new DeleteStudentAction();
            IAction listAction = new ListStudentsAction();
            studentActions.Add(addAction);
            studentActions.Add(modifyAction);
            studentActions.Add(deleteAction);
            studentActions.Add(listAction);

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
            IAction listAction = new ListVehiclesAction();
            IAction calculateRoutesAction = new CalculateRoutesAction();
            VehicleActions.Add(addAction);
            VehicleActions.Add(deleteAction);
            VehicleActions.Add(modifyAction);
            VehicleActions.Add(listAction);
            VehicleActions.Add(calculateRoutesAction);

            return new VehicleModule(VehicleActions);
        }

        private static Module CreateActivityModule()
        {
            List<IAction> ActivityActions = new List<IAction>();

            IAction addAction = new AddActivityAction();
            IAction modifyAction = new ModifyActivityAction();
            IAction deleteAction = new DeleteActivityAction();

            ActivityActions.Add(addAction);
            ActivityActions.Add(modifyAction);
            ActivityActions.Add(deleteAction);

            return new ActivityModule(ActivityActions);
        }

        private static Module CreatePaymentModule()
        {
            List<IAction> PaymentActions = new List<IAction>();

            IAction payFeeAction = new PayFeeAction();
            IAction payActivityAction = new PayActivityAction();

            PaymentActions.Add(payFeeAction);
            PaymentActions.Add(payActivityAction);

            return new PaymentModule(PaymentActions);
        }
    }
}