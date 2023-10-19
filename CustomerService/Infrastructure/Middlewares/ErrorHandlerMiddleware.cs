using System.Net.Mime;
using System.Net;
using Shared.Wrappers;

namespace CustomerService.Infrastructure.Middlewares
{
    public class ErrorHandlerMiddleware
    {

        private readonly RequestDelegate _nex;
        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _nex = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _nex(httpContext);
            }
            catch (Exception exception)
            {

                await ExceptionHandleAsync(httpContext, exception);
            }
        }
        private Task ExceptionHandleAsync(HttpContext context, Exception exception)
        {
            var result = System.Text.Json.JsonSerializer.Serialize(new ExceptionResponse() { Message = exception.Message, StatusCode = (int)HttpStatusCode.InternalServerError });
            context.Response.ContentType = MediaTypeNames.Application.Json;
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return context.Response.WriteAsync(result);
        }
    }
}
