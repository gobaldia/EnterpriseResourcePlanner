using CoreEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts
{
    public interface IPaymentPersistence
    {
        List<Fee> GetCurrentYearFeesByStudentNumber(int studentNumber);
        Fee GetOldestNotPaidFee(int studentNumber);
        void PayFee(Fee feeToBePaid);
    }
}
