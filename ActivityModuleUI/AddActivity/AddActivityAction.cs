using CoreGeneralization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityModuleUI.AddActivity
{
    public class AddActivityAction : IAction
    {
        public string Name { get; set; }

        public AddActivityAction()
        {
            this.Name = "Add";
        }

        public void Call()
        {
            AddActivityForm addActivityFormInstance = new AddActivityForm();
            addActivityFormInstance.Show();
        }

        public string GetName()
        {
            return this.Name;
        }
    }
}
