using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Morent.Core.Interfaces.Services;
using Morent.Infrastructure.Services;
using Morent.UseCases.Features.Cars.GetRecommendedCars;
using Morent.Web.Configurations;
using Morent.Web.Extensions;
using Morent.Web.Handlers;

var builder = WebApplication.CreateBuilder(args);

builder.AddLoggerConfigs();

using var loggerFactory = LoggerFactory.Create(config => config.AddConsole());
var startupLogger = loggerFactory.CreateLogger<Program>();

startupLogger.LogInformation("Starting web host");

builder.Services.AddAuthorization(options =>
{
  options.FallbackPolicy =
    new AuthorizationPolicyBuilder()
      .RequireAuthenticatedUser()
      .Build();
  
  options.AddPolicy("SwaggerPolicy", policy =>
    policy.RequireAssertion(_ => true));
});
builder.Services.AddProblemDetails(configure =>
{
  configure.CustomizeProblemDetails = context =>
  {
    context.ProblemDetails.Extensions.TryAdd("requestId", context.HttpContext.TraceIdentifier);
  };
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGenWithAuth();
builder.Services.AddFastEndpoints();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<TokenProvider>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddOptionConfigs(builder.Configuration, startupLogger, builder);
builder.Services.AddServiceConfigs(startupLogger, builder);

builder.Services.AddAuthentication(options =>
  {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
  })
  .AddJwtBearer(o =>
  {
    o.RequireHttpsMetadata = false;
    o.TokenValidationParameters = new TokenValidationParameters
    {
      ValidateIssuerSigningKey = true,
      ValidateIssuer = true,
      ValidateAudience = true,
      ValidateLifetime = true,
  
      IssuerSigningKey = new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)
      ),
  
      ValidIssuer = builder.Configuration["Jwt:Issuer"],
      ValidAudience = builder.Configuration["Jwt:Audience"],
      ClockSkew = TimeSpan.Zero
    };
  });

// ✅ Register MediatR (this is what you chose)
builder.Services.AddMediatR(cfg =>
{
  cfg.RegisterServicesFromAssembly(typeof(GetRecommendedCarsQuery).Assembly);
});

// ✅ Register FastEndpoints and scan both Web + UseCases

var app = builder.Build();

await app.UseAppMiddlewareAndSeedDatabase();
app.UseExceptionHandler();

app.UseAuthentication();
app.UseAuthorization();

app.UseFastEndpoints();

app.UseSwagger();
app.UseSwaggerUI();
app.MapSwagger()
  .AllowAnonymous();

app.Run();

public partial class Program { }
