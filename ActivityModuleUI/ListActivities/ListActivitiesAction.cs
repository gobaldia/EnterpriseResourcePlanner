using CoreGeneralization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityModuleUI.ListActivities
{
    public class ListActivitiesAction : IAction
    {
        public string Name { get; set; }

        public void Call()
        {
            ListActivitiesForm listActivitiesFormInstance = new ListActivitiesForm();
            listActivitiesFormInstance.Show();
        }

        public string GetName()
        {
            return this.Name = "List";
        }
    }
}
