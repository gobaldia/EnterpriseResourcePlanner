using CoreGeneralization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentModuleUI.DeleteStudent
{
    public class DeleteStudentAction : IAction
    {
        private string Name { get; set; }

        public DeleteStudentAction()
        {
            this.Name = "Delete";
        }

        public string GetName()
        {
            return this.Name;
        }
        public void Call()
        {
            DeleteStudentForm deleteStudentFormInstance = new DeleteStudentForm();
            deleteStudentFormInstance.Show();
        }
    }
}
