using CoreEntities.Entities;
using CoreLogic.Interfaces;
using DummyPersistance;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTesting.Utilities;

namespace UnitTesting
{
    [TestClass]
    public class PaymentTest
    {
        [TestInitialize]
        public void TestInitialization()
        {
            SystemDummyData.GetInstance.Reset();
        }

        [TestMethod]
        public void CreateFeeWithParameters()
        {
            try
            {
                Fee aFee = new Fee(50M, DateTime.Now);
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void FeeToString()
        {
            Fee aFee = new Fee();
            var feeAmount = 15M;
            var feeDate = new DateTime(2017,11,15);
            var feeIsPaid = false;

            aFee.Amount = feeAmount;
            aFee.Date = feeDate;
            aFee.IsPaid = feeIsPaid;

            DateTimeFormatInfo dateFormatInfo = new CultureInfo("en-US", false).DateTimeFormat;
            string monthName = dateFormatInfo.GetMonthName(feeDate.Month);
            string isTheFeePaid = feeIsPaid ? "Yes" : "No";

            string expectedString = string.Format("Date: {0}/{1} -- Amount: $ {2} -- Is paid: {3}", monthName, aFee.Date.Year, aFee.Amount, isTheFeePaid);
            string actualString = aFee.ToString();
            
            Assert.AreEqual(actualString, expectedString);
        }

        [TestMethod]
        public void GetStudentFees()
        {
            IStudentLogic studentOperations = DummyProvider.GetInstance.GetStudentOperations();
            IPaymentLogic paymentOperations = DummyProvider.GetInstance.GetPaymentOperations();

            var newStudent = Utility.CreateRandomStudent();
            newStudent.Fees = Utility.GenerateYearFees();
            newStudent.StudentNumber = 1;

            studentOperations.AddStudent(newStudent);

            List<Fee> studentFees = paymentOperations.GetCurrentYearFeesByStudentNumber(newStudent.StudentNumber);
            Assert.IsNotNull(studentFees);
            Assert.AreEqual(studentFees.Count, 12);
        }
        
        [TestMethod]
        public void PayFees()
        {
            try
            {
                IStudentLogic studentOperations = DummyProvider.GetInstance.GetStudentOperations();
                IPaymentLogic paymentOperations = DummyProvider.GetInstance.GetPaymentOperations();

                var newStudent = Utility.CreateRandomStudent();
                newStudent.Fees = Utility.GenerateYearFees();
                newStudent.StudentNumber = 1;

                studentOperations.AddStudent(newStudent);

                List<Fee> feesToBePaid = newStudent.Fees.Take(3).ToList();
                paymentOperations.PayFees(feesToBePaid);

                List<Fee> studentFees = paymentOperations.GetCurrentYearFeesByStudentNumber(newStudent.StudentNumber);
                List<Fee> checkFeesPaid = studentFees.Take(3).ToList();
                foreach(var fee in checkFeesPaid)
                    Assert.IsTrue(fee.IsPaid);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void PayAndAddStudentActivities()
        {
            IStudentLogic studentOperations = DummyProvider.GetInstance.GetStudentOperations();
            IPaymentLogic paymentOperations = DummyProvider.GetInstance.GetPaymentOperations();
            IActivityLogic activityOperations = DummyProvider.GetInstance.GetActivityOperations();

            var newStudent = Utility.CreateRandomStudent();
            newStudent.Fees = Utility.GenerateYearFees();
            newStudent.StudentNumber = 1;

            studentOperations.AddStudent(newStudent);

            var activityOne = new Activity("Yoga", new DateTime(2017, 11, 14), 100);
            activityOne.Id = 1;
            var activityTwo = new Activity("Karate", new DateTime(2017, 10, 22), 150);
            activityTwo.Id = 2;
            activityOperations.AddActivity(activityOne);
            activityOperations.AddActivity(activityTwo);

            List<Activity> activitiesToBePaid = activityOperations.GetActivities();
            paymentOperations.PayAndAddStudentActivities(activitiesToBePaid, newStudent);

            List<Activity> studentActivities = newStudent.Activities;
            Assert.IsNotNull(studentActivities);// Si no se agregaron
            Assert.AreNotEqual(studentActivities.Count, 0);
        }
    }
}
