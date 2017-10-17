using CoreGeneralization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleModuleUI.CalculateRoutes
{
    public class CalculateRoutesAction : IAction
    {
        private string Name { get; set; }

        public CalculateRoutesAction()
        {
            this.Name = "Calculate Routes";
        }

        public void Call()
        {
            CalculateRoutesForm calculateRoutesForm = new CalculateRoutesForm();
            calculateRoutesForm.Show();
        }

        public string GetName()
        {
            return this.Name;
        }
    }
}
