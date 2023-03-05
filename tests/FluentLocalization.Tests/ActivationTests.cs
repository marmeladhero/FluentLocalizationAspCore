using FluentLocalization.Common.Abstract;
using FluentLocalization.Common.Concrete;

namespace FluentLocalization.Tests;

public class ActivationTests
{
    private readonly IEnumerable<IFluentConfiguration> _configuration;
    private readonly IFluentConfigurations _configurations;

    public ActivationTests(IFluentRegisterService configuration)
    {
        
    }


    [Fact]
    public void RegisterConfigurationTests()
    {
        foreach (var cfg in _configuration)
        {
            var a = cfg.GetType();
            var typeParameters = a.BaseType.GetGenericArguments(); // Get an array of the type parameters for the class

            Type typeParameter = typeParameters[0]; // Get the first (and only) type parameter

            _configurations.AddRangeConfiguration(typeParameter , cfg.Configurations);
        }
        
        Assert.True(true);
    }
}