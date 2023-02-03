using VGLogger.API.Filters;
using VGLogger.DAL.Context;
using VGLogger.DAL.Interfaces;
using VGLogger.Service.Interfaces;
using VGLogger.Service.Profiles;
using VGLogger.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(config => config.AllowNullCollections = true, typeof(Program).Assembly,
                    typeof(DeveloperProfile).Assembly);
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
    .AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
