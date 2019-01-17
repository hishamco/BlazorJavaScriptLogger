using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;

namespace My.Extensions.Logging
{
    public static class JavaScriptLoggerFactoryExtensions
    {
        public static ILoggingBuilder AddWebConsole(this ILoggingBuilder builder)
        {
            builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<ILoggerProvider, JavaScriptLoggerProvider>());
            return builder;
        }
    }
}
