using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SimpleNetFramework.Core.Middleware;

namespace SimpleNetFramework.Core
{
    /// <summary>
    /// Представляет веб приложение с DI контейнером и pipeline.
    /// </summary>
    public interface IWebApplication<TRequest> : IDisposable
    {
        IConfigurationRoot Configuration { get; }
        ILogger Logger { get; }
        
        public IServiceProvider? Services { get; }

        Task StartAsync();

        Task StopAsync();

        void UseMiddleware<TMiddleware>() where TMiddleware : IMiddleware<TRequest>;
    }
}