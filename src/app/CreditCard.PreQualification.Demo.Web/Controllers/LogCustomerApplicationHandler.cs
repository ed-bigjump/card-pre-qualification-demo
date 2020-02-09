using CreditCard.PreQualification.Demo.Web.Data;
using CreditCard.PreQualification.Demo.Web.Infrastructure.Cqs;
using CreditCard.PreQualification.Demo.Web.Infrastructure.DateTime;

namespace CreditCard.PreQualification.Demo.Web.Controllers
{
    public class LogCustomerApplicationHandler : ICommandHandler<LogCustomerApplication>
    {
        private readonly IDbContext _db;
        private readonly IDateTimeService _dateTime;

        public LogCustomerApplicationHandler(IDbContext db, IDateTimeService dateTime)
        {
            _db = db;
            _dateTime = dateTime;
        }

        public void Handle(LogCustomerApplication command)
        {
            _db.CustomerApplications.Add(new CustomerApplication
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                DateOfBirth = command.DateOfBirth,
                AnnualIncome = command.AnnualIncome,
                RecommendedCards = string.Join(",", command.RecommendedCards),
                CreatedDate = _dateTime.Now
            });

            _db.SaveChanges();
        }
    }
}