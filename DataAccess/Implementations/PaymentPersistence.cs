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

        public void PayFees(List<Fee> feesToBePaid)
        {
            using (Context context = new Context())
            {
                foreach (var fee in feesToBePaid)
                {
                    fee.IsPaid = true;
                    context.Entry(fee).State = EntityState.Modified;
                }
                context.SaveChanges();
            }
        }

        public void PayAndAddStudentActivities(List<Activity> activitiesToBePaid, Student student)
        {
            using (Context context = new Context())
            {
                var studentOnDB = context.people.OfType<Student>().Include("Activities").Where(s => s.PersonOID.Equals(student.PersonOID)).FirstOrDefault();
                foreach (var activity in activitiesToBePaid)
                {
                    var activityOnDB = context.activities.Include("Students").Where(a => a.ActivityOID.Equals(activity.ActivityOID)).FirstOrDefault();
                    activityOnDB.IsPaid = true;
                    activityOnDB.Students.Add(studentOnDB);
                }
                context.SaveChanges();
            }
        }
    }
}
