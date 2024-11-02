using System;
using System.Threading.Tasks;
using SimpleNetFramework.Core.Middleware;

namespace SimpleNetFramework.Core
{
    /// <summary>
    /// Представляет веб приложение с DI контейнером и pipeline.
    /// </summary>
    public interface IWebApplication<TRequest> : IDisposable where TRequest : class
    {
        public IServiceProvider? Services { get; }

        Task StartAsync();

        Task StopAsync();

        void UseMiddleware<TMiddleware>() where TMiddleware : IMiddleware<TRequest>;
    }
}