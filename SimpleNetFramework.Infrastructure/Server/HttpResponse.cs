using System.Collections.Generic;
using System.Net;
using SimpleNetFramework.Core.Server;

namespace SimpleNetFramework.Infrastructure.Server
{
    /// <summary>
    /// Реализация интерфейса IHttpResponse.
    /// </summary>
    public class HttpResponse : IHttpResponse
    {
        public string Protocol { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }

        public Dictionary<string, string> Headers { get; set; } = new Dictionary<string, string>();
        public byte[] Body { get; set; }

        public HttpResponse()
        {
        }

        public HttpResponse(HttpStatusCode statusCode, string message, byte[] body, string protocol)
        {
            StatusCode = statusCode;
            Message = message;
            Body = body ?? new byte[0];
            Protocol = protocol;
        }
    }
}