using System;
using System.Collections.Generic;
using System.Globalization;
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

        public override string ToString()
        {
            DateTimeFormatInfo dateFormatInfo = new CultureInfo("en-US", false).DateTimeFormat;
            string monthName = dateFormatInfo.GetMonthName(this.Date.Month);
            string isTheFeePaid = this.IsPaid ? "Yes" : "No";

            return string.Format("Date: {0}/{1} -- Amount: $ {2} -- Is paid: {3}", monthName, this.Date.Year, this.Amount, isTheFeePaid);
        }
    }
}
