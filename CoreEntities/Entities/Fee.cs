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
        public DateTime Date { get; set; }

        public Fee()
        {
            this.Amount = 0;
            this.Date = DateTime.Now;
        }

        public Fee(double amount, DateTime date)
        {
            this.Amount = amount;
            this.Date = date;
        }
    }
}
