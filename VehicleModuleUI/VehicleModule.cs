using CoreGeneralization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleModuleUI
{
    public class VehicleModule : Module
    {
        public VehicleModule(List<IAction> newActions)
        {
            base.actions = newActions;
            base.name = "Vehicle";
            base.description = "Vehicle's management";
        }

        public override string GetName()
        {
            return this.name;
        }

        public override string GetDescription()
        {
            return this.description;
        }
        public override List<IAction> GetActions()
        {
            return this.actions;
        }
    }
}
