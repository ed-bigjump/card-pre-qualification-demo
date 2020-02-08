using CreditCard.PreQualification.Demo.Web.Controllers;
using System;
using System.Linq;
using Xunit;

namespace CreditCard.PreQualification.Demo.UnitTests.Recommendation
{
    public class RecommendedCardsQuerierTests
    {
        private RecommendedCardsQuerier _sut;

        public RecommendedCardsQuerierTests()
        {
            _sut = new RecommendedCardsQuerier();
        }

        [Fact]
        public void ReturnsNoCardsIfUnder18()
        {
            var results = _sut.Query(new DateTime(2004, 1, 1), 10000);

            Assert.False(results.Any());
        }

        [Fact]
        public void ReturnsBarclayCardIfOver18Over30k()
        {
            var results = _sut.Query(new DateTime(2000, 1, 1), 30000);

            Assert.Single(results);

            var first = results.First();
            Assert.Equal("BarclayCard", first.Name);
        }

        [Fact]
        public void ReturnsVanquisCardIfOver18Under30k()
        {
            var results = _sut.Query(new DateTime(2000, 1, 1), 29999);

            Assert.Single(results);

            var first = results.First();
            Assert.Equal("Vanquis Card", first.Name);
        }
    }
}
