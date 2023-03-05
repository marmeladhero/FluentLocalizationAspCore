using System.Reflection;
using FluentLocalization.Common.Abstract;
using FluentLocalization.Common.Concrete;
using FluentLocalization.Common.Options;
using FluentLocalization.Common.Providers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace FluentLocalization;

public static class RegisterServices
{
    public static IServiceCollection AddFluentLocalization(this IServiceCollection services)
    {
        services.AddSingleton<IFluentModelMetadataProvider, FluentModelMetadataProvider>();
        services.AddTransient<IConfigureOptions<MvcOptions>, FluentLocalizationActivationOption>();
        services.AddOptions<MvcOptions>()
            .Configure<IFluentModelMetadataProvider>((options, provider) =>
            {
                options.ModelMetadataDetailsProviders.Add(provider);
            });
        return services;
    }
    
    public static void ApplyFluentLocalizationFromAssembly(this IServiceCollection services, params Assembly[] assemblies)
    {
        var a = assemblies.SelectMany(x => x.GetTypes())
            .Where(t => t.IsClass && !t.IsAbstract && t.GetInterfaces()
                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IFluentConfiguration<>)))
            .ToList();
        
        foreach (var e in a)
        {
            services.AddTransient(e.GetInterfaces().Single(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IFluentConfiguration<>)), e);
            services.AddTransient(typeof(IFluentConfiguration), e);
        }
        
    }
}
