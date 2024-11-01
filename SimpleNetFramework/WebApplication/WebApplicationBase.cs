using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using SimpleNetFramework.Middleware;

namespace SimpleNetFramework.WebApplication
{
    public abstract class WebApplicationBase : IWebApplication
    {
        protected bool _disposed;
        protected IList<IMiddleware> _middlewares = new List<IMiddleware>();
        protected IServiceProvider? _serviceProvider;

        public IServiceProvider? Services
        {
            get => _serviceProvider;
        }

        public abstract Task StartAsync();

        public abstract Task StopAsync();

        
        public void UseMiddleware<TMiddleware>() where TMiddleware : IMiddleware
        {
            ConstructorInfo? constructor = typeof(TMiddleware).GetConstructors().FirstOrDefault();

            if (constructor is null)
            {
                _middlewares.Add((TMiddleware)Activator.CreateInstance(typeof(TMiddleware)));
                return;
            }

            ParameterInfo[] neededParameters = constructor.GetParameters();

            IList<object> readyServices = new List<object>();
            foreach (ParameterInfo parameter in neededParameters)
            {
                Type neededType = parameter.ParameterType;

                object? service = _serviceProvider?.GetService(neededType);

                if (service is null)
                {
                    throw new InvalidOperationException(
                        $"Unable to resolve service for type '{neededType.FullName}' " +
                        $"while attempting to activate '{typeof(TMiddleware).FullName}'."
                    );
                }

                readyServices.Add(service);
            }

            TMiddleware middleware = (TMiddleware)constructor.Invoke(readyServices.ToArray());

            _middlewares.Add(middleware);
        }
        
        /// <summary>
        /// Связывает миддлвари по цепочке
        /// </summary>
        protected void _ChainMiddleware()
        {
            // Последний миддлварь ни на что не ссылается, поэтому убираем его из обхода
            for (int i = 0; i < _middlewares.Count - 1; i++)
            {
                PropertyInfo nextPropertyInfo = typeof(IMiddleware).GetProperty("Next");

                nextPropertyInfo.SetValue(_middlewares[i], _middlewares[i + 1]);
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

            }

            _disposed = true;
        }
    }
}