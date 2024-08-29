using System.Net;
using System.Text.Json;

namespace WebApiProject.Middleware
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;
        public ExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandlerException(context, ex);
            }
        }
        private static Task HandlerException(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var resposeforerror = new
            {
                StatusCode = context.Response.StatusCode,
                Message = "An Error occured while processing your request",
                Detailed = ex.Message
            };
            var josnserializer = JsonSerializer.Serialize(resposeforerror);
            return context.Response.WriteAsync(josnserializer);
        } 
    }
}
