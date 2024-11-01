using System.Threading.Tasks;
using ThinServer;
using ThinServer.HTTP;

namespace SimpleNetFramework.Middleware
{
    public interface IMiddleware
    {
        RequestDelegate Next { get; }

        Task Invoke(IServerHttpRequest httpRequest);
    }
}