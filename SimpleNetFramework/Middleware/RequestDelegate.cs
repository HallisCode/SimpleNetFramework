using System.Threading.Tasks;
using ThinServer;
using ThinServer.HTTP;

namespace SimpleNetFramework.Middleware
{
    public delegate Task RequestDelegate(IServerHttpRequest httpRequest);
}