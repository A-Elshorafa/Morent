using FastEndpoints;
using MediatR;
using Morent.UseCases.Features.Cars.GetRecommendedCars;
using Morent.Web.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.AddLoggerConfigs();

using var loggerFactory = LoggerFactory.Create(config => config.AddConsole());
var startupLogger = loggerFactory.CreateLogger<Program>();

startupLogger.LogInformation("Starting web host");

builder.Services.AddOptionConfigs(builder.Configuration, startupLogger, builder);
builder.Services.AddServiceConfigs(startupLogger, builder);

// ✅ Register MediatR (this is what you chose)
builder.Services.AddMediatR(cfg =>
{
  cfg.RegisterServicesFromAssembly(typeof(GetRecommendedCarsQuery).Assembly);
});

// ✅ Register FastEndpoints and scan both Web + UseCases
builder.Services.AddFastEndpoints(o =>
  {
    o.Assemblies = new[]
    {
      typeof(Program).Assembly,
      typeof(GetRecommendedCarsQuery).Assembly
    };
  })
  .SwaggerDocument();

var app = builder.Build();

app.UseFastEndpoints();
app.UseSwaggerGen();

await app.UseAppMiddlewareAndSeedDatabase();

app.Run();

public partial class Program { }
