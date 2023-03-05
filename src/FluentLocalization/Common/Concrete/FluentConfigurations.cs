using FluentLocalization.Common.Abstract;

namespace FluentLocalization.Common.Concrete;


public class FluentConfigurations : IFluentConfigurations
{
    private readonly Dictionary<Type, Dictionary<string, IFluentPropertyConfiguration>> _configurations;

    public FluentConfigurations()
    {
        _configurations = new Dictionary<Type, Dictionary<string, IFluentPropertyConfiguration>>();
    }
    
    
    
    public Dictionary<string, IFluentPropertyConfiguration> GetConfigurations<T>() where T : class
    {
        if (_configurations.ContainsKey(typeof(T)))
        {
            return _configurations[typeof(T)];
        }
        _configurations.Add(typeof(T), new Dictionary<string, IFluentPropertyConfiguration>());
        return _configurations[typeof(T)];
    }
    
    public Dictionary<string, IFluentPropertyConfiguration> GetConfigurations(Type type)
    {
        if (_configurations.ContainsKey(type))
        {
            return _configurations[type];
        }
        _configurations.Add(type, new Dictionary<string, IFluentPropertyConfiguration>());
        return _configurations[type];
    }

    public void AddRangeConfiguration(Type type, Dictionary<string, IFluentPropertyConfiguration> fluentPropertyConfigurations)
    {
        _configurations.Add(type, fluentPropertyConfigurations);
    }
}