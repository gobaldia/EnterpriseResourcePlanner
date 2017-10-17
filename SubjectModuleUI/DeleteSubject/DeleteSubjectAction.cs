using CoreGeneralization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubjectModuleUI.DeleteSubject
{
    public class DeleteSubjectAction : IAction
    {
        private string Name { get; set; }

        public DeleteSubjectAction()
        {
            this.Name = "Delete";
        }

        public string GetName()
        {
            return this.Name;
        }
        public void Call()
        {
            DeleteSubjectForm deleteSubjectFormInstance = new DeleteSubjectForm();
            deleteSubjectFormInstance.Show();
        }
    }
}
