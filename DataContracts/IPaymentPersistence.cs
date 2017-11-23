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
        void PayFees(List<Fee> feesToBePaid);
        void PayAndAddStudentActivities(List<Activity> activitiesToBePaid, Student student);
    }
}
