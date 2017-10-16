using CoreGeneralization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleModuleUI.DeleteVehicle
{
    public class DeleteVehicleAction : IAction
    {
        private string Name { get; set; }

        public DeleteVehicleAction()
        {
            this.Name = "Delete";
        }

        public void Call()
        {
            DeleteVehicleForm deleteVehicleForm = new DeleteVehicleForm();
            deleteVehicleForm.Show();
        }

        public string GetName()
        {
            return this.Name;
        }
    }
}
