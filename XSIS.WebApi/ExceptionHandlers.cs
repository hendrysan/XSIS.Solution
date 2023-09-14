using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using XSIS.Models.Others;

namespace XSIS.WebApi
{
    public static class ExceptionHandlers
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        await context.Response.WriteAsJsonAsync(new ErrorModel()
                        {
                            IsSuccess = false,
                            ErrorCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message
                        });

                    }
                });
            });
        }
    }
}
