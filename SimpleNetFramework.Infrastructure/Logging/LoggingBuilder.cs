using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace SimpleNetFramework.Infrastructure.Logging
{
    public class LoggingBuilder : ILoggingBuilder
    {
        public IServiceCollection Services { get; }
    }
}