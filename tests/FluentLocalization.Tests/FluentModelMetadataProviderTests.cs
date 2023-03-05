using FluentLocalization.Common.Providers;

namespace FluentLocalization.Tests;

public class FluentModelMetadataProviderTests
{
    private readonly IFluentModelMetadataProvider _fluentModelMetadataProvider;

    public FluentModelMetadataProviderTests(IFluentModelMetadataProvider fluentModelMetadataProvider)
    {
        _fluentModelMetadataProvider = fluentModelMetadataProvider;
    }
    
    [Fact]
    public void GetMetadataForPropertyTests()
    {
        
    }
}