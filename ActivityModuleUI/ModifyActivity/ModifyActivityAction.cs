using CoreGeneralization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityModuleUI.ModifyActivity
{
    public class ModifyActivityAction : IAction
    {
        public string Name { get; set; }

        public ModifyActivityAction()
        {
            this.Name = "Modify";
        }

        public void Call()
        {
            ModifyActivityForm modifyActivityFormInstance = new ModifyActivityForm();
            modifyActivityFormInstance.Show();
        }

        public string GetName()
        {
            return this.Name;
        }
    }
}
