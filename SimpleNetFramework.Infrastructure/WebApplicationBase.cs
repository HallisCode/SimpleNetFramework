using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SimpleNetFramework.Core;
using SimpleNetFramework.Core.Middleware;
using SimpleNetFramework.Core.Server;

namespace SimpleNetFramework.Infrastructure
{
    /// <summary>
    /// Базовая заготовка для реализации собственного WebApplication.
    /// </summary>
    public abstract class WebApplicationBase<TRequestPipline> : IWebApplication<TRequestPipline>
    {
        // Handle logic
        protected IList<IMiddleware<TRequestPipline>> _middlewares = new List<IMiddleware<TRequestPipline>>();
        protected readonly IServer _server;

        protected bool _disposed;

        // DI logic
        public IServiceProvider? Services { get; init; }
        public IConfigurationRoot Configuration { get; init; }
        public ILogger Logger { get; init; }


        public WebApplicationBase(
            IServer server,
            IServiceProvider provider,
            IConfigurationRoot configuration,
            ILogger logger
        )
        {
            _server = server;

            Services = provider;
            Configuration = configuration;
            Logger = Logger;

            _server.SetHandler(HandleServerRequest);
        }

        public virtual async Task StartAsync()
        {
            _ChainMiddleware();

            await _server.StartAsync();
        }

        public virtual async Task StopAsync()
        {
            await _server.StopAsync();
        }

        /// <summary>
        /// Добавляет миддлварь в pipeline обработки.
        /// </summary>
        /// <exception cref="InvalidOperationException">Не удалось найти зависимости для этого миддлваря.</exception>
        public void UseMiddleware<TMiddleware>() where TMiddleware : IMiddleware<TRequestPipline>
        {
            ConstructorInfo? constructor = typeof(TMiddleware).GetConstructors().FirstOrDefault();

            if (constructor is null)
            {
                _middlewares.Add((TMiddleware)Activator.CreateInstance(typeof(TMiddleware))!);
                return;
            }

            ParameterInfo[] neededParameters = constructor.GetParameters();

            IList<object> resolvedServices = new List<object>();
            foreach (ParameterInfo parameter in neededParameters)
            {
                Type neededType = parameter.ParameterType;

                object? service = Services?.GetService(neededType);

                if (service is null)
                {
                    throw new InvalidOperationException(
                        $"Unable to resolve service for type '{neededType.FullName}' " +
                        $"while attempting to activate '{typeof(TMiddleware).FullName}'."
                    );
                }

                resolvedServices.Add(service);
            }

            TMiddleware middleware = (TMiddleware)constructor.Invoke(resolvedServices.ToArray());

            _middlewares.Add(middleware);
        }

        /// <summary>
        /// Обрабатывает входящий запрос <see cref="IServerRequest"/> от сервера <see cref="IServer"/>.
        /// </summary>
        /// <returns></returns>
        protected abstract Task HandleServerRequest(IServerRequest request);

        /// <summary>
        /// Связывает миддлвари по цепочке.
        /// </summary>
        protected void _ChainMiddleware()
        {
            // Последний миддлварь ни на что не ссылается, поэтому убираем его из обхода
            for (int i = 0; i < _middlewares.Count - 1; i++)
            {
                PropertyInfo nextPropertyInfo = typeof(IMiddleware<TRequestPipline>).GetProperty("Next")!;

                MiddlewareDelegate<TRequestPipline> nextInvoke = new MiddlewareDelegate<TRequestPipline>(
                    _middlewares[i + 1].Invoke
                );

                nextPropertyInfo.SetValue(_middlewares[i], nextInvoke);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                _server.Dispose();
            }

            _disposed = true;
        }
    }
}