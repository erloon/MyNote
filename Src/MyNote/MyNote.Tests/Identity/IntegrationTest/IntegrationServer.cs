using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;

namespace MyNote.Tests.Identity.IntegrationTest
{
    public class IntegrationServer
    {
        public TestServer Create()
        {
            var webHostBuilder = WebHost.CreateDefaultBuilder();
            webHostBuilder.UseContentRoot(Directory.GetCurrentDirectory() + "\\Identity\\IntegrationTest");
            webHostBuilder.UseStartup<IdentityIntegrationTestStartup>();
            webHostBuilder.ConfigureAppConfiguration((builder, config) => { config.AddJsonFile("settings.json"); });
            return new TestServer(webHostBuilder);
        }
    }
}