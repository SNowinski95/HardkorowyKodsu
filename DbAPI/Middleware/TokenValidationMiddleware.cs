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
            //token should be store more secure eg. in DB but for this task i want to be flexible for any DB
            var token = configuration["Token"];
            //validate configuration
            if(string.IsNullOrEmpty(token))
            {
                logger.LogError("Innocrect configuration file");
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync("Invalid server configuration");
            }
            else if (context.Request.Headers.ContainsKey("Token") && token == context.Request.Headers["Token"])
            {
                logger.LogInformation("Validate request come from {Host}", context.Request.Host);
                validToken = true;
            }

            if (!validToken)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                await context.Response.WriteAsync("Invalid Token");
                logger.LogWarning("Invalidate request come from {Host}", context.Request.Host);
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
