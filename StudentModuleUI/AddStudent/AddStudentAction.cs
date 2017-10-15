using CoreGeneralization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentModuleUI.AddStudent
{
    public class AddStudentAction : IAction
    {
        private string Name { get; set; }

        public AddStudentAction()
        {
            this.Name = "Add";
        }

        public string GetName()
        {
            return this.Name;
        }
        public void Call()
        {
            AddStudentForm addStudentFormInstance = new AddStudentForm();
            addStudentFormInstance.Show();
        }
    }
}
