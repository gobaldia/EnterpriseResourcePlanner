using CoreGeneralization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentModuleUI.ListStudents
{
    public class ListStudentsAction : IAction
    {
        private string Name { get; set; }

        public ListStudentsAction()
        {
            this.Name = "List";
        }

        public string GetName()
        {
            return this.Name;
        }
        public void Call()
        {
            ListOfStudentsForm listOfStudentsFormInstance = new ListOfStudentsForm();
            listOfStudentsFormInstance.Show();
        }
    }
}
