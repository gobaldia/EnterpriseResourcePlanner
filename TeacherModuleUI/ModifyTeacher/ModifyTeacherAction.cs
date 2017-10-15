using CoreGeneralization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherModuleUI.ModifyTeacher
{
    public class ModifyTeacherAction : IAction
    {
        private string Name { get; set; }

        public ModifyTeacherAction()
        {
            this.Name = "Modify";
        }

        public string GetName()
        {
            return this.Name;
        }
        public void Call()
        {
            ModifyTeacherForm modifyTeacherFormInstance = new ModifyTeacherForm();
            modifyTeacherFormInstance.Show();
        }
    }
}
