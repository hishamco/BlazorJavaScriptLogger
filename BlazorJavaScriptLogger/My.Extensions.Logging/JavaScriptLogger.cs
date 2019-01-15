using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions.Internal;
using Microsoft.JSInterop;

namespace My.Extensions.Logging
{
    public class JavaScriptLogger : ILogger
    {
        private readonly string _name;

        public JavaScriptLogger(string name)
        {
            _name = name;
        }

        public IDisposable BeginScope<TState>(TState state) => NullScope.Instance;

        public bool IsEnabled(LogLevel logLevel)
        {
            if (logLevel == LogLevel.None)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            var message = formatter(state, exception);
            if (!string.IsNullOrEmpty(message) || exception != null)
            {
                message = $"[{_name}] {message}";
                JSRuntime.Current.InvokeAsync<object>("My.Extensions.Logging.JavaScriptLogger.Log", message);
            }
        }
    }
}
