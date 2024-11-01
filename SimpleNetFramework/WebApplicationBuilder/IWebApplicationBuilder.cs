using Microsoft.Extensions.DependencyInjection;

namespace SimpleNetFramework.WebApplication
{
    public interface IWebApplicationBuilder
    {
        IServiceCollection Services { get; }

        IWebApplication Build();
    }
}