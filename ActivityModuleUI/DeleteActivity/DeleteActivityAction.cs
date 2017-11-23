using CoreGeneralization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityModuleUI.DeleteActivity
{
    public class DeleteActivityAction : IAction
    {
        public string Name { get; set; }

        public DeleteActivityAction()
        {
            this.Name = "Delete";
        }

        public void Call()
        {
            DeleteActivityForm deleteActivityFormInstance = new DeleteActivityForm();
            deleteActivityFormInstance.Show();
        }

        public string GetName()
        {
            return this.Name;
        }
    }
}
