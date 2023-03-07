using FluentLocalization.Common.Abstract;
using FluentLocalization.Common.Providers;

namespace FluentLocalization.Tests;

public class FluentModelMetadataProviderTests
{
    private readonly IEnumerable<IFluentConfiguration>? _configurations;

    public FluentModelMetadataProviderTests( IEnumerable<IFluentConfiguration>? configurations)
    {
        _configurations = configurations;
    }
    
    [Fact]
    public void GetMetadataForPropertyTests()
    {
        foreach (var cfg in _configurations)
        {
            var properties = cfg.Configurations;
            
            foreach (var property in properties)
            {
                
            }
        }
    }
}