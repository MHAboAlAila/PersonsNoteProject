using Microsoft.AspNetCore.Diagnostics;
using PersonsNoteBook.Services.Exceptions;
using System.Net;
using System.Text.Json;

namespace PersonsNoteBook.Extensions
{
    public static class ExceptionHandlingMiddleware
    {
        private class ErrorDetails
        {
            public int StatusCode { get; set; }
            public string? Message { get; set; }

            public override string ToString()
            {
                return JsonSerializer.Serialize(this);
            }
        }
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {

            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    Type exceptionType;
                    HttpStatusCode statusCode;

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        exceptionType = contextFeature.Error.GetType();
                        if (exceptionType == typeof(BadRequestException))
                            statusCode = HttpStatusCode.BadRequest;
                        else if (exceptionType == typeof(NotFoundException))
                            statusCode = HttpStatusCode.NotFound;
                        else if (exceptionType == typeof(NotImplementedException))
                            statusCode = HttpStatusCode.NotImplemented;
                        else
                            statusCode = HttpStatusCode.InternalServerError;

                        context.Response.ContentType = "application/json";
                        context.Response.StatusCode = (int)statusCode;

                        await context.Response.WriteAsync(
                            new ErrorDetails()
                            {
                                StatusCode = context.Response.StatusCode,
                                Message = contextFeature.Error.Message
                            }.ToString()
                        );
                    }
                });

            });
        }
    }
}
