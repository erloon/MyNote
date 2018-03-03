using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyNote.Identity.API;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {

        private TestServer _server;
        private HttpClient _client;

        [TestMethod]
        public async Task TestMethod1()
        {

            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();

            var response = await _client.GetAsync("api/Organization/Get");

        }
    }
}
