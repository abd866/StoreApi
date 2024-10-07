using Store.Services.HandlleResponse;
using System.Net;
using System.Text.Json;

namespace Store.Web.Middlware
{
    public class ExeptionMiddlware
    {
        private readonly RequestDelegate _next;
        private readonly IHostEnvironment _environment;
        private readonly ILogger<ExeptionMiddlware> _logger;

        public ExeptionMiddlware(
            RequestDelegate next,
            IHostEnvironment environment,
            ILogger<ExeptionMiddlware>logger
            )
        {
           _next = next;
           _environment = environment;
           _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;//500
                var respons = _environment.IsDevelopment()
                    ? new CustomExpetions((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace)
                    : new CustomExpetions((int)HttpStatusCode.InternalServerError, null, null);
                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var json = JsonSerializer.Serialize(respons, options);
                await context.Response.WriteAsync(json);
            }
        }
    }
}
