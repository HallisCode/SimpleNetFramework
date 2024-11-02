using Microsoft.Extensions.DependencyInjection;
using SimpleNetFramework.Core.Server;

namespace SimpleNetFramework.Core
{
    /// <summary>
    /// Представляет builder для <see cref="IWebApplication"/>.
    /// </summary>
    public interface IWebApplicationBuilder
    {
        IServiceCollection Services { get; }
        IServer Server { get; }
        IWebApplication Build();
    }
}