using System.Collections.Generic;

namespace SimpleNetFramework.Core.Server
{
    /// <summary>
    /// Представляет Http response.
    /// </summary>
    public interface IHttpResponse
    {
        string Protocol { get; set; }
        int StatusCode { get; set; }
        string Message { get; set; }

        Dictionary<string, string> Headers { get; set; }
        byte[] Body { get; set; }
    }
}