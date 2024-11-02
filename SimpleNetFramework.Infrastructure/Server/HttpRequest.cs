using SimpleNetFramework.Core.Server;

namespace SimpleNetFramework.Infrastructure.Server
{
    /// <summary>
    /// Реализация интерфейса IHttpRequest.
    /// </summary>
    public class HttpRequest : IHttpRequest
    {
        public HttpMethod Method { get; private set; }
        public string Route { get; private set; }
        public string Protocol { get; private set; }

        public Dictionary<string, string> Headers { get; private set; }
        public byte[] Body { get; private set; }

        public HttpRequest(HttpMethod method, string route, string protocol, byte[] body)
        {
            Method = method;
            Route = route;
            Protocol = protocol;
            Body = body;
            Headers = new Dictionary<string, string>();
        }
    }
}