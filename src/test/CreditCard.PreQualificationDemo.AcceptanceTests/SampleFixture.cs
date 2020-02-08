using CreditCard.PreQualification.Demo;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using Xunit;

namespace CreditCard.PreQualificationDemo.AcceptanceTests
{
    public class SampleFixture
    {
        [Fact]
        public async Task SampleTest()
        {
            var factory = new WebApplicationFactory<Startup>();
            var client = factory.CreateClient();

            var response = await client.GetAsync("/");

            response.EnsureSuccessStatusCode();
            Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }
    }
}
