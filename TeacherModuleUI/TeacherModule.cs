using CoreGeneralization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherModuleUI
{
    public class TeacherModule : Module
    {
        public TeacherModule(List<IAction> newActions)
        {
            base.actions = newActions;
            base.name = "Teacher";
            base.description = "Teachers management";
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
