using CreditCard.PreQualification.Demo.Web.Infrastructure.DateTime;
using Xunit;

namespace CreditCard.PreQualification.Demo.UnitTests.Infrastructure
{
    public class DateHelperTests
    {
        [Fact]
        public void ShouldReturnTrueForValidDate()
        {
            Assert.True(DateHelper.IsValidDateTime(1, 1, 1980));
            Assert.True(DateHelper.IsValidDateTime(29, 2, 2020));
            Assert.True(DateHelper.IsValidDateTime(31, 12, 2020));
        }

        [Fact]
        public void ShouldReturnFalseForInvalidDate()
        {
            var sut = new DateHelper();

            Assert.False(DateHelper.IsValidDateTime(30, 2, 2020));
            Assert.False(DateHelper.IsValidDateTime(99, 99, 2020));
            Assert.False(DateHelper.IsValidDateTime(null, null, null));
            Assert.False(DateHelper.IsValidDateTime(1, 1, null));
        }
    }
}
