using System.Diagnostics;

namespace WebApiProject.Middleware
{
    public class MiddlewareLogging
    {
        private readonly RequestDelegate _next;
        public MiddlewareLogging(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();
            await _next(context);
            stopwatch.Stop();

            var Loggingmessage = $" Http {context.Request.Method} - {context.Request.Path} responded {context.Response.StatusCode} in {stopwatch.ElapsedMilliseconds}";
            Debug.WriteLine(Loggingmessage);
        }
    }
}
