using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace FluentLocalization.Tests;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddFluentLocalization();
        services.ApplyFluentLocalizationFromAssemblies(Assembly.GetAssembly(typeof(Startup)));
    }
}