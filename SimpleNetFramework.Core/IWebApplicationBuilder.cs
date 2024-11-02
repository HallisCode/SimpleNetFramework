using Microsoft.Extensions.DependencyInjection;
using SimpleNetFramework.Core.Server;

namespace SimpleNetFramework.Core
{
    /// <summary>
    /// Представляет builder для <see cref="IWebApplication"/>.
    /// </summary>
    public interface IWebApplicationBuilder<TWebApplication> where TWebApplication : class
    {
        IServiceCollection Services { get; }
        IServer? Server { get; }

        public void SetServer(IServer server);

        TWebApplication Build();
    }
}