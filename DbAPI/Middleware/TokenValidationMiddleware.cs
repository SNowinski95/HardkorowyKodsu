using System.Net;

namespace DbAPI.Middleware
{
    public class TokenValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public TokenValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            bool validToken = false;
            var configuration = context.RequestServices.GetService<IConfiguration>();
            ArgumentNullException.ThrowIfNull(configuration);
            var logger = context.RequestServices.GetService<ILogger<TokenValidationMiddleware>>();
            ArgumentNullException.ThrowIfNull(logger);
            var token = configuration["Token"];
            if(string.IsNullOrEmpty(token))
            {
                logger.LogError("Innocrect configuration file");
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync("Invalid server configuration");
            }
            else if (context.Request.Headers.TryGetValue("Token", out Microsoft.Extensions.Primitives.StringValues value) && token == value)
            {
                validToken = true;
            }

            if (!validToken)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                await context.Response.WriteAsync("Invalid Token");
                logger.LogWarning("Invalidate request appear");
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }

    public static class TokenExtensions
    {
        public static IApplicationBuilder UseTokenValidation(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TokenValidationMiddleware>();
        }
    }
}
