using Microsoft.Extensions.DependencyInjection;


namespace SimpleNetFramework.WebApplication
{
    public abstract class WebApplicationBuilderBase : IWebApplicationBuilder
    {
        public IServiceCollection Services { get; }
        
        public abstract IWebApplication Build();
    }
}