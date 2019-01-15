using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;

namespace My.Extensions.Logging
{
    public class JavaScriptLoggerProvider : ILoggerProvider
    {
        private readonly ConcurrentDictionary<string, JavaScriptLogger> _loggers;

        public JavaScriptLoggerProvider()
        {
            _loggers = new ConcurrentDictionary<string, JavaScriptLogger>();
        }

        public ILogger CreateLogger(string categoryName)
        {
            if (string.IsNullOrWhiteSpace(categoryName))
            {
                throw new ArgumentNullException(nameof(categoryName));
            }

            return _loggers.GetOrAdd(categoryName, new JavaScriptLogger(categoryName));
        }

        public void Dispose()
        {

        }
    }
}
