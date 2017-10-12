using CoreGeneralization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherModuleUI.AddTeacher;

namespace TeacherModuleUI.AddTeacher
{
    public class AddTeacherAction : IAction
    {
        private string Name { get; set; }

        public AddTeacherAction()
        {
            this.Name = "Add Teacher";
        }

        public string GetName()
        {
            return this.Name;
        }
        public void Call()
        {
            AddTeacherForm addTeacherFormInstance = new AddTeacherForm();
            addTeacherFormInstance.Show();
        }
    }
}
