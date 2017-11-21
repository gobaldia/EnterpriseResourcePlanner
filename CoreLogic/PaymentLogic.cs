using CoreLogic.Interfaces;
using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreEntities.Entities;

namespace CoreLogic
{
    public class PaymentLogic : IPaymentLogic
    {
        private IPaymentPersistence persistenceProvider;
        public PaymentLogic(IPaymentPersistence provider)
        {
            this.persistenceProvider = provider;
        }

        public List<Fee> GetCurrentYearFeesByStudentNumber(int studentNumber)
        {
            throw new NotImplementedException();
        }
    }
}
