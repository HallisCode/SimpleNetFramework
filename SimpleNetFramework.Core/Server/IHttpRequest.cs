using System.Collections.Generic;
using System.Net.Http;

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