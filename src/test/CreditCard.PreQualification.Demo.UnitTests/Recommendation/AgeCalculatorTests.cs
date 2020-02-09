using CreditCard.PreQualification.Demo.Web.Recommendation.Queries;
using System;
using Xunit;

namespace CreditCard.PreQualification.Demo.UnitTests.Recommendation
{
    public class AgeCalculatorTests
    {
        [Fact]
        public void ShouldCalculateAge()
        {
            var sut = new AgeCalculator();

            var today = new DateTime(2020, 2, 8);

            Assert.Equal(0, sut.Calculate(today, new DateTime(2020, 2, 8)));
            Assert.Equal(17, sut.Calculate(today, new DateTime(2002, 2, 9)));
            Assert.Equal(18, sut.Calculate(today, new DateTime(2002, 2, 8)));
            Assert.Equal(18, sut.Calculate(today, new DateTime(2001, 2, 9)));
            Assert.Equal(30, sut.Calculate(today, new DateTime(1990, 2, 8)));
        }
    }
}
