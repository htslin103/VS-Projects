using DigitalLibraryApplication.Middleware;

namespace DigitalLibraryApplication.MiddlewareExtensions
{
    public static class SimpleMiddlewareExtension
    {
        public static IApplicationBuilder UseSimpleMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SimpleMiddleware>();
        }
    }
}