using CoreGeneralization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentModuleUI.ModifyStudent
{
    public class ModifyStudentAction : IAction
    {
        private string Name { get; set; }

        public ModifyStudentAction()
        {
            this.Name = "Modify";
        }

        public string GetName()
        {
            return this.Name;
        }
        public void Call()
        {
            ModifyStudentForm modifyStudentFormInstance = new ModifyStudentForm();
            modifyStudentFormInstance.Show();
        }
    }
}
