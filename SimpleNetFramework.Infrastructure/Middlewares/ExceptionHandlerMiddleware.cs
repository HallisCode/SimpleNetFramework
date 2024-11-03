using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SimpleNetFramework.Core.Middleware;

namespace SimpleNetFramework.Infrastructure.Middlewares
{
    public class ExceptionHandlerMiddleware<TRequest> : IMiddleware<TRequest>
    {
        private int currentError = 0;
        private readonly ILogger<ExceptionHandlerMiddleware<TRequest>> _logger;
        private MiddlewareDelegate<TRequest> _next;

        public MiddlewareDelegate<TRequest> Next
        {
            set => _next = value;
        }


        public ExceptionHandlerMiddleware(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<ExceptionHandlerMiddleware<TRequest>>();
        }

        public async Task Invoke(TRequest request)
        {
            try
            {
                await _next.Invoke(request);
            }
            catch (Exception exception)
            {
                _logger.LogError(
                    new EventId(currentError++, "Unhandled error"),
                    exception,
                    "Middlewares Pipeline Request Processing"
                );
            }
        }
    }
}