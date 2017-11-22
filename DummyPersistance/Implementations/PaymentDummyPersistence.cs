using CoreEntities.Entities;
using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyPersistance.Implementations
{
    public class PaymentDummyPersistence : IPaymentPersistence
    {
        private List<Student> dummySystemStudents = SystemDummyData.GetInstance.GetStudents();

        public List<Fee> GetCurrentYearFeesByStudentNumber(int studentNumber)
        {
            return this.dummySystemStudents
                .Find(s => s.StudentNumber.Equals(studentNumber)).Fees
                .Where(f => f.Date.Year.Equals(DateTime.Now.Year)).ToList();
        }

        public void PayFees(List<Fee> feesToBePaid)
        {
            feesToBePaid.ForEach(f => f.IsPaid = true);
        }
    }
}
