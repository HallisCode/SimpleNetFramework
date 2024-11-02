using System.Threading.Tasks;
using SimpleNetFramework.Core.Server;

namespace SimpleNetFramework.Core.Middleware
{
    /// <summary>
    /// Представляет Middleware, участвующий в pipeline.
    /// </summary>
    public interface IMiddleware
    {
        RequestDelegate Next { get; }
        Task Invoke(IServerRequest httpRequest);
    }
}