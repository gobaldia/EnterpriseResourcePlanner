using CoreGeneralization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherModuleUI.ListTeachers
{
    public class ListTeachersAction : IAction
    {
        private string Name { get; set; }

        public ListTeachersAction()
        {
            this.Name = "List";
        }

        public string GetName()
        {
            return this.Name;
        }
        public void Call()
        {
            ListOfTeachersForm listOfTeachersFormInstance = new ListOfTeachersForm();
            listOfTeachersFormInstance.Show();
        }
    }
}
