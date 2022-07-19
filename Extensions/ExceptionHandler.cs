using Api.Entities.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace Api.Extensions;

public static class ExceptionHandler
{
    public static void ConfigureGlobalExceptionHandler(this IApplicationBuilder applicationBuilder) =>
        applicationBuilder.UseExceptionHandler(builder => builder.Run(async context =>
        {
            context.Response.ContentType = "application/json";
            var errorContext = context.Features.Get<IExceptionHandlerFeature>();
            
            if (errorContext is not null)
            {
                context.Response.StatusCode = errorContext.Error switch
                {
                    NotFoundException => StatusCodes.Status404NotFound,
                    BadRequestException => StatusCodes.Status400BadRequest,
                    _ => StatusCodes.Status500InternalServerError
                };
                await context.Response.WriteAsJsonAsync(new
                {
                    context.Response.StatusCode,
                    Message = errorContext.Error.Message ?? "Internal Server error"
                });
            }
        }));
}