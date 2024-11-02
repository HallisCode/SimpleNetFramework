using System.Collections.Generic;

namespace SimpleNetFramework.Core.Server
{
    /// <summary>
    /// Представляет Http response.
    /// </summary>
    public interface IHttpResponse
    {
        string Protocol { get; }
        int StatusCode { get; }
        string Message { get; }
        
        Dictionary<string, string> Headers { get; }
        byte[] Body { get; }
    }
}