using CoreGeneralization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubjectModuleUI.ModifySubject
{
    public class ModifySubjectAction : IAction
    {
        private string Name { get; set; }

        public ModifySubjectAction()
        {
            this.Name = "Modify";
        }

        public string GetName()
        {
            return this.Name;
        }
        public void Call()
        {
            ModifySubjectForm modifySubjectFormInstance = new ModifySubjectForm();
            modifySubjectFormInstance.Show();
        }
    }
}
