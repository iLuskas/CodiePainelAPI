using System.Net;
using System.Text.Json;
using System;
using Codie.Painel.Domain.Exceptions;

namespace Codie.Painel.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
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
                _logger.LogError(ex, ex.Message);

                await HandleExceptionsAsync(context, ex);
            }
        }

        private async Task HandleExceptionsAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode status = HttpStatusCode.InternalServerError;
            string message = exception.Message;
            string? innerMessage = exception.InnerException?.Message;

            if (exception is ArgumentException || exception is ArgumentNullException || exception is NotImplementedException || exception is DomainValidationException)
            {
                message = exception.Message;
                status = HttpStatusCode.BadRequest;
                innerMessage = exception.InnerException?.Message;
            }                    
            
            _logger.LogTrace(exception, exception.StackTrace);

            var result = JsonSerializer.Serialize(new { statusCode = status, message, innerMessage });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;

            await context.Response.WriteAsync(result);
        }
    }
}
