namespace SimpleNetFramework.Core.Server
{
    /// <summary>
    /// Представляет запрос от сервера.
    /// </summary>
    public interface IServerRequest
    {
        IHttpRequest Request { get; }
        IHttpResponse? Response { get; set; }

        bool isResponseSet { get; }
    }
}