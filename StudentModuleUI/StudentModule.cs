using CoreGeneralization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentModuleUI
{
    public class StudentModule : Module
    {
        public StudentModule(List<IAction> newActions)
        {
            base.actions = newActions;
            base.name = "Student";
            base.description = "Student management";
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
