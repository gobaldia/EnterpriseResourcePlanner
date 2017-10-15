using CoreGeneralization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherModuleUI.DeleteTeacher
{
    public class DeleteTeacherAction : IAction
    {
        private string Name { get; set; }

        public DeleteTeacherAction()
        {
            this.Name = "Delete";
        }

        public string GetName()
        {
            return this.Name;
        }
        public void Call()
        {
            DeleteTeacherForm deleteTeacherFormInstance = new DeleteTeacherForm();
            deleteTeacherFormInstance.Show();
        }
    }
}
