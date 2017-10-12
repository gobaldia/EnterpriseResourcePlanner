using CoreGeneralization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainComponents
{
    public class MainModule : Module
    {
        private List<Module> modules;

        public MainModule()
        {
            this.modules = new List<Module>();
        }

        public List<Module> GetModules()
        {
            return this.modules;
        }
        public void AddModule(Module newModule)
        {
            this.modules.Add(newModule);
        }

        public override List<IAction> GetActions()
        {
            throw new NotImplementedException();
        }

        public override string GetDescription()
        {
            throw new NotImplementedException();
        }

        public override string GetName()
        {
            throw new NotImplementedException();
        }
    }
}
