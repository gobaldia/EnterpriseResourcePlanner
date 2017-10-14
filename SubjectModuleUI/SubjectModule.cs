using CoreGeneralization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubjectModuleUI
{
    public class SubjectModule : Module
    {
        public SubjectModule(List<IAction> newActions)
        {
            base.actions = newActions;
            base.name = "Subject";
            base.description = "Subjects Management";
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
