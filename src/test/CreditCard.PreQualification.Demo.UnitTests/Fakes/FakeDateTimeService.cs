using CreditCard.PreQualification.Demo.Web.Infrastructure.DateTime;
using System;

namespace CreditCard.PreQualification.Demo.UnitTests.Recommendation
{
    internal class FakeDateTimeService : IDateTimeService
    {
        private readonly DateTime _dateTime;

        public FakeDateTimeService(DateTime dateTime)
        {
            _dateTime = dateTime;
        }

        public DateTime Now { get { return _dateTime; } }
    }
}