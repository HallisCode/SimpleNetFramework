using System;
using System.Threading.Tasks;

namespace SimpleNetFramework.Core.Server
{
    /// <summary>
    /// Представляет сервер который обрабатывает http запросы.
    /// </summary>
    public interface IServer : IDisposable
    {
        void SetHandler(Func<IServerRequest, Task> handler);
        Task StartAsync();
        Task StopAsync();
    }
}