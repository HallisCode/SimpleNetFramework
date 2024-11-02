using Microsoft.Extensions.DependencyInjection;
using SimpleNetFramework.Core.Server;

namespace SimpleNetFramework.Core
{
    /// <summary>
    /// Представляет builder для <see cref="IWebApplication"/>.
    /// </summary>
    public interface IWebApplicationBuilder<TRequestPipline> where TRequestPipline : class
    {
        IServiceCollection Services { get; }
        IServer? Server { get; }

        public void SetServer(IServer server);

        IWebApplication<TRequestPipline> Build();
    }
}