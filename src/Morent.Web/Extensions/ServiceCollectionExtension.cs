using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi;

namespace Morent.Web.Extensions;

internal static class ServiceCollectionExtension
{
  internal static IServiceCollection AddSwaggerGenWithAuth(this IServiceCollection services)
  {
    services.AddSwaggerGen(o =>
    {

      var securityScheme = new OpenApiSecurityScheme
      {
        Name = "JWT Authentication",
        Description = "Enter JWT Bearer token",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        BearerFormat = "JWT"
      };
      
      o.AddSecurityDefinition("Bearer", securityScheme);

      o.AddSecurityRequirement(_ => new OpenApiSecurityRequirement
      {
        { new OpenApiSecuritySchemeReference("Bearer"), new List<string>() }
      });
    });
    
    return services;
  }
}
