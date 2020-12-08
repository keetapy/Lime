using Lime.Business.Services.Interfaces;
using Lime.DataAccess.Repository.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lime.Business.Services
{
    public class LoggerService : ILoggerService
    {
        private readonly ILogsRepository _logsRepository;
        private static object _lock = new object();
        public LoggerService(ILogsRepository logsRepository)
        {
            _logsRepository = logsRepository;
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel == LogLevel.Trace;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (formatter != null)
            {
                lock (_lock)
                {
                    _logsRepository.Set(DateTime.Now, logLevel.ToString(), formatter(state, exception),null);
                }
            }
        }
    }
}
