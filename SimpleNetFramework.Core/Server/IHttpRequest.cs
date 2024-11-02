using System.Collections.Generic;
using System.Net.Http;
using HttpMethod = SimpleNetFramework.Core.Server.Types.HttpMethod;

namespace SimpleNetFramework.Core.Server
{
    /// <summary>
    /// Представляет Http request.
    /// </summary>
    public interface IHttpRequest
    {
        HttpMethod Method { get; }
        string Route { get; }
        string Protocol { get; }

        Dictionary<string, string> Headers { get; }
        byte[] Body { get; }
    }
}