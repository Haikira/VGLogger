using FluentAssertions.Common;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VGLogger.API.Authorization.Development;
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

                        e.AddAuthentication(Constants.Authentication.DevAuthScheme)
                        .AddScheme<DevelopmentAuthenticationSchemeOptions, DevelopmentAuthenticationFilter>(
                            Constants.Authentication.DevAuthScheme, options =>
                            {
                                options.DefaultEmail = Constants.Authentication.DevEmail;
                                options.DefaultName = Constants.Authentication.DevName;
                            });
                        
                        e.AddAuthorization(options =>
                        {
                            options.AddPolicy(string.Empty, builder =>
                            {
                                builder.AuthenticationSchemes.Add(Constants.Authentication.DevAuthScheme);
                                builder.RequireAuthenticatedUser();
                            });
                        });
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
