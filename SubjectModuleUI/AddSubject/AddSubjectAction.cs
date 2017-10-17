using CoreGeneralization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubjectModuleUI.AddSubject
{
    public class AddSubjectAction : IAction
    {
        private string Name { get; set; }

        public AddSubjectAction()
        {
            this.Name = "Add";
        }

        public string GetName()
        {
            return this.Name;
        }
        public void Call()
        {
            AddSubjectForm addSubjectFormInstance = new AddSubjectForm();
            addSubjectFormInstance.Show();
        }
    }
}
