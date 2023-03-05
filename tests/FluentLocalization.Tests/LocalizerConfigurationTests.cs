using FluentAssertions;
using FluentLocalization.Common.Abstract;
using FluentLocalization.Common.Providers;
using FluentLocalization.Tests.Common;
using Microsoft.Extensions.DependencyInjection;

namespace FluentLocalization.Tests;

public class LocalizerConfigurationTests
{
    private readonly IFluentConfiguration<DummyClass> _dummyClassConfiguration;
    private readonly IFluentLocalizer _localizer;
    private readonly IFluentModelMetadataProvider _fluentModelMetadataProvider;

    public LocalizerConfigurationTests(IFluentConfiguration<DummyClass> dummyClassConfiguration, IFluentLocalizer localizer, IFluentModelMetadataProvider fluentModelMetadataProvider)
    {
        _dummyClassConfiguration = dummyClassConfiguration;
        _localizer = localizer;
        _fluentModelMetadataProvider = fluentModelMetadataProvider;
    }
    
    [Fact]
    public void TestClassConfiguration()
    {
        _dummyClassConfiguration.For(x => x.Property).GetDisplayName.Should().Be("DisplayNameProperty");
        _dummyClassConfiguration.For(x => x.Property).GetDescription.Should().Be("DescriptionProperty");
        _dummyClassConfiguration.For(x => x.Property).GetPlaceholder.Should().Be("PlaceholderProperty");
    }

    [Fact]
    public void TestLocalizer()
    {
        _dummyClassConfiguration.For(x => x.Property).GetDisplayName.Should().Be("DisplayNameProperty");
        _dummyClassConfiguration.For(x => x.Property).GetDescription.Should().Be("DescriptionProperty");
        _dummyClassConfiguration.For(x => x.Property).GetPlaceholder.Should().Be("PlaceholderProperty");
        
        _localizer.GetDescription(typeof(DummyClass), nameof(DummyClass.Property)).Should().Be("DescriptionProperty");
        _localizer.GetDisplayName(typeof(DummyClass), nameof(DummyClass.Property)).Should().Be("DisplayNameProperty");
        _localizer.GetPlaceholder(typeof(DummyClass), nameof(DummyClass.Property)).Should().Be("PlaceholderProperty");
    }
}
