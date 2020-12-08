using Lime.Business.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lime.WebAPI.Middlewares
{
    public class LoggerProvider : ILoggerProvider
    {
        private readonly ILoggerService _loggerService;
        public LoggerProvider(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }
        public ILogger CreateLogger(string categoryName)
        {
            return _loggerService;
        }

        public void Dispose()
        {
        }
    }
    public static class LoggerExtensions
    {
        public static ILoggerFactory Add(this ILoggerFactory factory,
                                        ILoggerService loggerService)
        {
            factory.AddProvider(new LoggerProvider(loggerService));
            return factory;
        }
    }
}
