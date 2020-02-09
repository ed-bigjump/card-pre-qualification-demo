using CreditCard.PreQualification.Demo.UnitTests.Fakes;
using CreditCard.PreQualification.Demo.Web.Controllers;
using System;
using System.Linq;
using Xunit;

namespace CreditCard.PreQualification.Demo.UnitTests.Recommendation
{
    public class LogCustomerApplicationHandlerTests
    {
        [Fact]
        public void ShouldLogCustomerApplication()
        {
            using (var db = new FakeDbContext())
            {
                var dateTime = new FakeDateTimeService(new DateTime(2020, 2, 8));
                var sut = new LogCustomerApplicationHandler(db, dateTime);

                var command = new LogCustomerApplication
                {
                    FirstName = "Joe",
                    LastName = "Bloggs",
                    DateOfBirth = new DateTime(1980, 1, 1),
                    AnnualIncome = 30000,
                    RecommendedCards = new[] { "BarclayCard" }
                };

                sut.Handle(command);

                var applications = db.CustomerApplications.ToArray();

                Assert.Single(applications);

                var first = applications.First();

                Assert.Equal(command.FirstName, first.FirstName);
                Assert.Equal(command.LastName, first.LastName);
                Assert.Equal(command.DateOfBirth, first.DateOfBirth);
                Assert.Equal(command.AnnualIncome, first.AnnualIncome);
                Assert.Equal(string.Join(",", command.RecommendedCards), first.RecommendedCards);
                Assert.Equal(dateTime.Now, first.CreatedDate);
            }
        }
    }
}
