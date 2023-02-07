using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using VGLogger.Api.Authentication;
using VGLogger.API.Filters;
using VGLogger.DAL.Context;
using VGLogger.DAL.Interfaces;
using VGLogger.Service.Interfaces;
using VGLogger.Service.Profiles;
using VGLogger.Service.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;
using AuthenticationService = VGLogger.Service.Services.AuthenticationService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(config => config.AllowNullCollections = true, typeof(Program).Assembly, typeof(DeveloperProfile).Assembly);

builder.Services.AddControllers(x => { x.Filters.Add<ExceptionFilter>(); });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .AddScoped<IVGLoggerDatabase, VGLoggerContext>(_ => new VGLoggerContext("Server=localhost,5432;Database=vglogger;User Id=admin;Password=password;"))
    .AddScoped<IDeveloperService, DeveloperService>()
    .AddScoped<IGameService, GameService>()
    .AddScoped<IPlatformService, PlatformService>()
    .AddScoped<IReviewService, ReviewService>()
    .AddScoped<IAuthenticateService, AuthenticationService>()
    .AddScoped<IUserService, UserService>();

builder.Services.AddFluentValidationAutoValidation();

builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddAuthentication(string.Empty).AddScheme<AuthenticationSchemeOptions, AccessAuthenticationFilter>(string.Empty, options => { });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(string.Empty, policy =>
    {
        policy.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
        policy.RequireAuthenticatedUser();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers().RequireAuthorization();

app.Run();
