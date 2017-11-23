using CoreGeneralization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentModuleUI.PayActivity
{
    public class PayActivityAction : IAction
    {
        private string Name { get; set; }

        public PayActivityAction()
        {
            this.Name = "Pay Student Activities";
        }

        public string GetName()
        {
            return this.Name;
        }
        public void Call()
        {
            PayActivityForm payActivityFormInstance = new PayActivityForm();
            payActivityFormInstance.Show();
        }

    }
}
