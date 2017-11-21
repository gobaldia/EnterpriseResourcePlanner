using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEntities.Entities
{
    public class Fee
    {
        public int FeeOID { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public bool IsPaid { get; set; }

        public Fee()
        {
            this.Amount = 0;
            this.Date = DateTime.Now;
            this.IsPaid = false;
        }

        public Fee(decimal amount, DateTime date)
        {
            this.Amount = amount;
            this.Date = date;
            this.IsPaid = false;
        }
    }
}
