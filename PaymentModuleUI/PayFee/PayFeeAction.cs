using CoreGeneralization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentModuleUI.PayFee
{
    public class PayFeeAction : IAction
    {
        private string Name { get; set; }

        public PayFeeAction()
        {
            this.Name = "Pay Student Fees";
        }

        public string GetName()
        {
            return this.Name;
        }
        public void Call()
        {
            PayFeeForm payFeeFormInstance = new PayFeeForm();
            payFeeFormInstance.Show();
        }
    }
}
