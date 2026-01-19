using Microsoft.AspNetCore.Diagnostics;
using Morent.UseCases.Features.Cars.GetRecommendedCars;
using Morent.Web.Configurations;
using Morent.Web.Handlers;

var builder = WebApplication.CreateBuilder(args);

builder.AddLoggerConfigs();

using var loggerFactory = LoggerFactory.Create(config => config.AddConsole());
var startupLogger = loggerFactory.CreateLogger<Program>();

startupLogger.LogInformation("Starting web host");

builder.Services.AddProblemDetails(configure =>
{
  configure.CustomizeProblemDetails = context =>
  {
    context.ProblemDetails.Extensions.TryAdd("requestId", context.HttpContext.TraceIdentifier);
  };
});
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddOptionConfigs(builder.Configuration, startupLogger, builder);
builder.Services.AddServiceConfigs(startupLogger, builder);

// ✅ Register MediatR (this is what you chose)
builder.Services.AddMediatR(cfg =>
{
  cfg.RegisterServicesFromAssembly(typeof(GetRecommendedCarsQuery).Assembly);
});

// ✅ Register FastEndpoints and scan both Web + UseCases
builder.Services.AddFastEndpoints()
  .SwaggerDocument();

var app = builder.Build();

await app.UseAppMiddlewareAndSeedDatabase();
app.UseExceptionHandler();

app.UseFastEndpoints();
app.UseSwaggerGen();


app.Run();

public partial class Program { }
