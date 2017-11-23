using CoreGeneralization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentModuleUI
{
    public class PaymentModule : Module
    {
        public PaymentModule(List<IAction> newActions)
        {
            base.actions = newActions;
            base.name = "Payments";
            base.description = "Payments management";
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
