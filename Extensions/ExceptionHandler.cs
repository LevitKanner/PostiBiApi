using Microsoft.AspNetCore.Diagnostics;

namespace Api.Extensions;

public static class ExceptionHandler
{
    public static void ConfigureGlobalExceptionHandler(this IApplicationBuilder applicationBuilder) =>
        applicationBuilder.UseExceptionHandler(builder => builder.Run(async context =>
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";
            var errorContext = context.Features.Get<IExceptionHandlerFeature>();
            await context.Response.WriteAsJsonAsync(new
            {
                context.Response.StatusCode,
                Message = errorContext?.Error.Message ?? "Internal Server error"
            });
        }));
}