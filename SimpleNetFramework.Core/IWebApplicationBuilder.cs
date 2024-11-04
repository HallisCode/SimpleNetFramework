using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SimpleNetFramework.Core.Server;

namespace SimpleNetFramework.Core
{
    /// <summary>
    /// Представляет builder для <see cref="IWebApplication"/>.
    /// </summary>
    public interface IWebApplicationBuilder<TWebApplication>
    {
        IConfigurationBuilder Configuration { get; }
        ILoggingBuilder Logging { get; }
        IServiceCollection Services { get; }
        IServer? Server { get; }

        public void SetServer(IServer server);

        TWebApplication Build();
    }
}