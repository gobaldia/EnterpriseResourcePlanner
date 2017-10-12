using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreGeneralization
{
    public abstract class Module
    {
        protected string name { get; set; }
        protected string description { get; set; }
        protected List<IAction> actions { get; set; }

        public abstract string GetName();
        public abstract string GetDescription();
        public abstract List<IAction> GetActions();
    }
}