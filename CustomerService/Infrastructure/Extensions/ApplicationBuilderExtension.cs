using CustomerService.Infrastructure.Middlewares;

namespace CustomerService.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseGlobalExceptionHandler(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
