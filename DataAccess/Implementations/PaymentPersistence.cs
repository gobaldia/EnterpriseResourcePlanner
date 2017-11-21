using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreEntities.Entities;
using System.Data.Entity;

namespace DataAccess.Implementations
{
    public class PaymentPersistence : IPaymentPersistence
    {
        public List<Fee> GetCurrentYearFeesByStudentNumber(int studentNumber)
        {
            List<Fee> studentFees;
            using (Context context = new Context())
            {
                var student = context.people.OfType<Student>().Include("Fees").Where(s => s.StudentNumber.Equals(studentNumber));
                studentFees = student.FirstOrDefault().Fees;
            }
            return studentFees;
        }

        public Fee GetOldestNotPaidFee(int studentNumber)
        {
            throw new NotImplementedException();
        }

        public void PayFee(Fee feeToBePaid)
        {
            throw new NotImplementedException();
        }
    }
}
