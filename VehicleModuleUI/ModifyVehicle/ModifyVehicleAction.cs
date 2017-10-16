using CoreGeneralization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleModuleUI.ModifyVehicle
{
    public class ModifyVehicleAction : IAction
    {
        private string Name { get; set; }

        public ModifyVehicleAction()
        {
            this.Name = "Modify";
        }

        public void Call()
        {
            ModifyVehicleForm modifyVehicleForm = new ModifyVehicleForm();
            modifyVehicleForm.Show();
        }

        public string GetName()
        {
            return this.Name;
        }
    }
}
