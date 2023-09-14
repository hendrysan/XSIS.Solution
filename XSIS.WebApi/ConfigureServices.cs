using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using XSIS.Contexts;
using XSIS.Models.Entities;
using XSIS.Models.Others;
using XSIS.Services.Implements;
using XSIS.Services.Interfaces;

namespace XSIS.WebApi
{
    public static class ConfigureServices
    {
        public static IConfiguration? Configuration { get; }

        public static IServiceCollection AddWebAPIServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

            services.AddMvcCore().ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    //var message = context

                    var result = new ErrorModel()
                    {
                        IsSuccess = false,
                        ErrorCode = 400,
                        Message = "Bad Request",
                        Data = context.ModelState.Values.SelectMany(x => x.Errors.Select(p => p.ErrorMessage)).ToList()
                    };
                    return new BadRequestObjectResult(result);
                };
            });

            services.AddDbContext<DatabaseContext>(options =>
            {
            });

            services.Configure<SecurityStampValidatorOptions>(options =>
            {
                // enables immediate logout, after updating the user's stat.
                options.ValidationInterval = TimeSpan.Zero;
            });

            services.AddHttpContextAccessor();

            services.AddScoped<IMovie, MovieRepository>();

            return services;
        }
    }
}
