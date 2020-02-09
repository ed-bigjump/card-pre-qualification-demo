using CreditCard.PreQualification.Demo.UnitTests.Fakes;
using CreditCard.PreQualification.Demo.UnitTests.Recommendation;
using CreditCard.PreQualification.Demo.Web.Controllers;
using System;
using System.Linq;
using Xunit;

namespace CreditCard.PreQualification.Demo.UnitTests.Controllers
{
    public class HomeControllerTests
    {
        [Fact]
        public void ShouldLogCustomerApplication()
        {
            using (var db = new FakeDbContext())
            {
                var dateTime = new FakeDateTimeService(new DateTime(2020, 2, 8));
                var handler = new LogCustomerApplicationHandler(db, dateTime);

                var sut = new HomeController(dateTime, handler);

                var model = new IndexPostModel
                {
                    FirstName = "Joe",
                    LastName = "Bloggs",
                    BirthDay = 1,
                    BirthMonth = 1,
                    BirthYear = 1980,
                    AnnualIncome = 30000
                };

                sut.Index(model);

                var applications = db.CustomerApplications.ToArray();

                Assert.Single(applications);

                var first = applications.First();

                Assert.Equal(model.FirstName, first.FirstName);
                Assert.Equal(model.LastName, first.LastName);
                Assert.Equal(model.GetDateOfBirth(), first.DateOfBirth);
                Assert.Equal(model.AnnualIncome, first.AnnualIncome);
                Assert.Equal(dateTime.Now, first.CreatedDate);
            }
        }
    }
}
