using System;
using System.Threading;
using System.Threading.Tasks;
using SimpleNetFramework.Middleware;

namespace SimpleNetFramework.WebApplication
{
    public interface IWebApplication : IDisposable
    {
        public IServiceProvider? Services { get; }

        Task StartAsync();

        Task StopAsync();

        void UseMiddleware<TMiddleware>() where TMiddleware : IMiddleware;
    }
}