using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using BookManager.Persistence.SqlServer;

namespace BookManager.FunctionalTests.TestSupport
{
    internal class IntegrationTest
        : IDisposable
    {

        private readonly IServiceProvider _serviceProvider;
        protected HttpClient HttpClient { get; }
        protected IntegrationTest()
        {
            var server =
                new TestServer(
                    new WebHostBuilder()
                        .UseStartup<Startup>()
                        .UseEnvironment("Test")
                        //.UseCommonConfiguration()
                        /*.ConfigureTestServices(ConfigureTestServices)*/);

            HttpClient = server.CreateClient();

            // Strategy to use a unique DB schema per test execution
            _serviceProvider = server.Services;
            // Apply Migrations
            using var dbContext = _serviceProvider.CreateScope().ServiceProvider.GetRequiredService<BookDbContext>();
            dbContext.Database.Migrate();
        }


        private void RemoveDependencyInjectionRegisteredService<TService>(IServiceCollection services)
        {
            var serviceDescriptor = services.SingleOrDefault(d => d.ServiceType == typeof(TService));
            if (serviceDescriptor != null)
            {
                services.Remove(serviceDescriptor);
            }
        }

        public void Dispose()
        {   
            using var dbContext = _serviceProvider.GetService<BookDbContext>();
            dbContext?.Database.EnsureDeleted();
        }

    }
}
