using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;
using UzmanEgitimDanismanim.Shared.Dtos.CustomDtos;

namespace UzmanEgitimDanismanim.Web.Extensions
{
    public static class UseCustomExceptionHandler
    {

        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(options =>
            {
                options.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";
                    var error = context.Features.Get<IExceptionHandlerFeature>();
                    if (error != null)
                    {
                        var ex = error.Error;
                        ErrorDto errorDto = new ErrorDto { Status = 500 };
                        errorDto.Errors.Add(ex.Message);

                        await context.Response.WriteAsync(JsonConvert.SerializeObject(errorDto));
                    }
                });
            });
        }
    }
}
