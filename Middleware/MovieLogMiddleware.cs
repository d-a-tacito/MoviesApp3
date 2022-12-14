using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
namespace MoviesApp.Middleware
{
    public class MovieLogMiddleware
    {
        private readonly RequestDelegate _next;

        public MovieLogMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, ILogger<MovieLogMiddleware> logger)
        {
            if (httpContext.Request.Path.Equals("/Movies"))
            {
                logger.LogInformation("OPENED MOVIES' LIST\n"+$"Request: {httpContext.Request.Path}  Method: {httpContext.Request.Method}");
            }
            else if (httpContext.Request.Path.Equals("/Movies/Index"))
            {
                logger.LogInformation("OPENED MOVIES' LIST INDEX\n"+$"Request: {httpContext.Request.Path}  Method: {httpContext.Request.Method}");
            }
            await _next(httpContext);
        }
    }
}