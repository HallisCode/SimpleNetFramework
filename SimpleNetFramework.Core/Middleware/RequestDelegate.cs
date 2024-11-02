using System.Threading.Tasks;
using SimpleNetFramework.Core.Server;

namespace SimpleNetFramework.Core.Middleware
{
    /// <summary>
    /// Представляет делегат, способный принимать <see cref="IServerRequest"/>.
    /// </summary>
    public delegate Task RequestDelegate(IServerRequest httpRequest);
}