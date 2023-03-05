using FluentLocalization.Common.Abstract;

namespace FluentLocalization.Common.Concrete;

public class FluentRegisterService : IFluentRegisterService
{
    private readonly IEnumerable<IFluentConfiguration> _configurations;
    private readonly IFluentConfigurations _fluentConfigurations;

    public FluentRegisterService(IEnumerable<IFluentConfiguration> configurations, IFluentConfigurations fluentConfigurations)
    {
        _configurations = configurations;
        _fluentConfigurations = fluentConfigurations;
    }

    public void Register()
    {
        foreach (var cfg in _configurations)
        {
            var a = cfg.GetType();
            
            var typeParameters = a.BaseType.GetGenericArguments(); // Get an array of the type parameters for the class

            Type typeParameter = typeParameters[0]; // Get the first (and only) type parameter

            _fluentConfigurations.AddRangeConfiguration(typeParameter, cfg.Configurations);
        }
    }
}