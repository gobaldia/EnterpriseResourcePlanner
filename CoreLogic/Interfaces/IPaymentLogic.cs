using CoreEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLogic.Interfaces
{
    public interface IPaymentLogic
    {
        List<Fee> GetCurrentYearFeesByStudentNumber(int studentNumber);
        Fee GetOldestNotPaidFee(int studentNumber);
        void PayFee(Fee feeToBePaid);
    }
}
