using System;
using SurveyManagement.Application.Wrappers;
using System.Net;
using System.Text.Json;
using SurveyManagement.Application.Exceptions;

namespace SurveyManagement.API.Middlewares
{

    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context); // Sonraki middleware'e geç
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Unhandled Exception: {ex.Message}");
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var response = new SurveyResult<string>();

            switch (exception)
            {
                case NotFoundException:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    response.Succeeded = false;
                    response.Errors = new List<string> { exception.Message };
                    break;

                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    response.Succeeded = false;
                    response.Errors = new List<string> { "Sunucu hatası: " + exception.Message };
                    break;
            }

            var json = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(json);
        }
    }
}



