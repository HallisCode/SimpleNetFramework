namespace SimpleNetFramework.Core.Server
{
    /// <summary>
    /// Представляет запрос от сервера.
    /// </summary>
    public interface IServerRequest
    {
        IHttpRequest HttpRequest { get; }
        IHttpResponse HttpResponse { get; set; }

        bool isResponseSet { get; }
    }
}