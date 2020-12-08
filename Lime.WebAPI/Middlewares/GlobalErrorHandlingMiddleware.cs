using Lime.Business.Services;
using Lime.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Lime.WebAPI.Middlewares
{
    public class GlobalErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private  ILoggerFactory _loggerFactory;
        private  ILoggerService _loggerService;
        private  ILogger _logger;
        public GlobalErrorHandlingMiddleware(RequestDelegate request )
        {
            _next = request;
        }
        public async Task Invoke(HttpContext context, ILoggerFactory logger,ILoggerService loggerService)
        {
            _loggerFactory = logger.Add(loggerService);
            _logger = _loggerFactory.CreateLogger("Create");

            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message
            }.ToString());
        }
    }
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
