using eCommerce.Infrastructure;
using eCommerce.Core;
using eCommersWeb.Middleware;
using System.Text.Json.Serialization;
using eCommerce.Core.Mappers;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
// Add Infrasture services
builder.Services.AddInfrastructure();
builder.Services.AddCore();

// Add Controller Services          // Converter for json to Enum
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

// Add AutoMapper Services
builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly);

//Fluient Validation
builder.Services.AddFluentValidationAutoValidation();

var app = builder.Build();

// Exception Handling Middleware

app.UseExceptionHandleMiddleware();
app.UseRouting();

// Auth
app.UseAuthentication();
app.UseAuthorization();

//Controller Route
app.MapControllers();

app.Run();
