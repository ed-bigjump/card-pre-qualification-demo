using Microsoft.AspNetCore.Mvc.Testing;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace CreditCard.PreQualification.Demo.AcceptanceTests
{
    public class EntryTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public EntryTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task CanViewHomepage()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("/");

            response.EnsureSuccessStatusCode();
            Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());

            var content = await response.Content.ReadAsStringAsync();
            Assert.Contains("Credit Card Pre-Qualification", content);
        }

        [Fact]
        public async Task GetValidationErrorForMissingFields()
        {
            var client = _factory.CreateClient();

            var formContent = new FormUrlEncodedContent(new KeyValuePair<string, string>[] { });

            var response = await client.PostAsync("/", formContent);

            response.EnsureSuccessStatusCode();
            Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());

            var content = await response.Content.ReadAsStringAsync();
            Assert.Contains("Please enter your first name", content);
            Assert.Contains("Please enter your last name", content);
            Assert.Contains("Please enter a valid date of birth", content);
            Assert.Contains("Please enter your annual income", content);
        }

        [Fact]
        public async Task GetValidationErrorForInvalidDate()
        {
            var client = _factory.CreateClient();

            var formContent = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("FirstName", "Joe" ),
                new KeyValuePair<string, string>("LastName", "Bloggs"),
                new KeyValuePair<string, string>("BirthDay", "31"),
                new KeyValuePair<string, string>("BirthMonth", "2"),
                new KeyValuePair<string, string>("BirthYear", "2020"),
                new KeyValuePair<string, string>("AnnualIncome", "30000")
            });

            var response = await client.PostAsync("/", formContent);

            response.EnsureSuccessStatusCode();
            Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());

            var content = await response.Content.ReadAsStringAsync();
            Assert.Contains("Please enter a valid date of birth", content);
        }

        [Fact]
        public async Task ShouldShowNoCardForUnder18()
        {
            var client = _factory.CreateClient();

            var formContent = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("FirstName", "Joe" ),
                new KeyValuePair<string, string>("LastName", "Bloggs"),
                new KeyValuePair<string, string>("BirthDay", "1"),
                new KeyValuePair<string, string>("BirthMonth", "1"),
                new KeyValuePair<string, string>("BirthYear", "2020"),
                new KeyValuePair<string, string>("AnnualIncome", "30000")
            });

            var response = await client.PostAsync("/", formContent);

            response.EnsureSuccessStatusCode();
            Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());

            var content = await response.Content.ReadAsStringAsync();
            Assert.Contains("We cannot currently recommend any credit cards", content);
        }

        [Fact]
        public async Task ShouldShowBarclayCardForOver18Over30K()
        {
            var client = _factory.CreateClient();

            var formContent = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("FirstName", "Joe" ),
                new KeyValuePair<string, string>("LastName", "Bloggs"),
                new KeyValuePair<string, string>("BirthDay", "1"),
                new KeyValuePair<string, string>("BirthMonth", "1"),
                new KeyValuePair<string, string>("BirthYear", "2000"),
                new KeyValuePair<string, string>("AnnualIncome", "30000")
            });

            var response = await client.PostAsync("/", formContent);

            response.EnsureSuccessStatusCode();
            Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());

            var content = await response.Content.ReadAsStringAsync();
            Assert.Contains("BarclayCard", content);
        }

        [Fact]
        public async Task ShouldShowVanquisCardForOver18Under30K()
        {
            var client = _factory.CreateClient();

            var formContent = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("FirstName", "Joe" ),
                new KeyValuePair<string, string>("LastName", "Bloggs"),
                new KeyValuePair<string, string>("BirthDay", "1"),
                new KeyValuePair<string, string>("BirthMonth", "1"),
                new KeyValuePair<string, string>("BirthYear", "2000"),
                new KeyValuePair<string, string>("AnnualIncome", "29999")
            });

            var response = await client.PostAsync("/", formContent);

            response.EnsureSuccessStatusCode();
            Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());

            var content = await response.Content.ReadAsStringAsync();
            Assert.Contains("Vanquis Card", content);
        }
    }
}
