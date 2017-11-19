using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEntities.Entities
{
    public class Fee
    {
        public double Amount { get; set; }

        public Fee(double amount)
        {
            this.Amount = amount;
        }
    }
}
