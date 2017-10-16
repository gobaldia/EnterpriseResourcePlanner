using CoreGeneralization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleModuleUI.ListVehicles
{
    public class ListVehiclesAction : IAction
    {
        private string Name { get; set; }

        public ListVehiclesAction()
        {
            this.Name = "List";
        }

        public void Call()
        {
            ListVehiclesForm listVehiclesForm = new ListVehiclesForm();
            listVehiclesForm.Show();
        }

        public string GetName()
        {
            return this.Name;
        }
    }
}
