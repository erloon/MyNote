using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using MyNote.Identity.API;
using MyNote.Identity.Domain.Model;
using Newtonsoft.Json;
using NUnit.Framework;

namespace MyNote.Tests.Identity.IntegrationTest
{

    [TestFixture]
    public class OrganizationIntegrationTest
    {
        private  TestServer _server;
        private  HttpClient _client;

        [SetUp]
        public void Setup()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Test]
        public async Task Get()
        {

            var response = _client.GetAsync("api/Organization/Get");
            var responseString = await response.Result.Content.ReadAsStringAsync();

            // Assert
            var persons = JsonConvert.DeserializeObject<IEnumerable<Organization>>(responseString);
        }
    }
}