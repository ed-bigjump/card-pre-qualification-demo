using CreditCard.PreQualification.Demo.Web.Data;
using CreditCard.PreQualification.Demo.Web.Infrastructure.Cqs;
using CreditCard.PreQualification.Demo.Web.Infrastructure.DateTime;
using CreditCard.PreQualification.Demo.Web.Infrastructure.IpAddress;
using Microsoft.AspNetCore.Http;

namespace CreditCard.PreQualification.Demo.Web.Recommendation.Commands
{
    public class LogCustomerApplicationHandler : ICommandHandler<LogCustomerApplication>
    {
        private readonly IDbContext _db;
        private readonly IDateTimeService _dateTime;
        private readonly IClientIpAddressService _ipAddressService;

        public LogCustomerApplicationHandler(IDbContext db, IDateTimeService dateTime, IClientIpAddressService ipAddressService)
        {
            _db = db;
            _dateTime = dateTime;
            _ipAddressService = ipAddressService;
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
                IpAddress = _ipAddressService.ClientIpAddress,
                CreatedDate = _dateTime.Now
            });

            _db.SaveChanges();
        }
    }
}