using CoreGeneralization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityModuleUI
{
    public class ActivityModule : Module
    {
        public ActivityModule(List<IAction> newActions)
        {
            base.actions = newActions;
            base.name = "Activity";
            base.description = "Activity management";
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
