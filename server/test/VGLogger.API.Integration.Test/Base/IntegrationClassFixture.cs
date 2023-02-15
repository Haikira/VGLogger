using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VGLogger.DAL.Context;
using VGLogger.DAL.Interfaces;

namespace VGLogger.API.Integration.Test.Base
{
    public class IntegrationClassFixture : IDisposable
    {
        public readonly WebApplicationFactory<Program> Host;

        public IntegrationClassFixture()
        {
            Host = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureTestServices(e =>
                    {
                        e.AddDbContext<VGLoggerContext>(options => options
                                .EnableSensitiveDataLogging()
                                .UseInMemoryDatabase(Guid.NewGuid().ToString()),
                            ServiceLifetime.Singleton,
                            ServiceLifetime.Singleton);
                        e.AddTransient<IVGLoggerDatabase, VGLoggerContext>();
                    });
                });
            DatabaseSeed.SeedDatabase(Host.Services.GetService<VGLoggerContext>());
        }

        public void Dispose()
        {
            Host?.Dispose();
        }
    }
}
