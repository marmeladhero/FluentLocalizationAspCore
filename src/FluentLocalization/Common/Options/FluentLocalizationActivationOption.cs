using FluentLocalization.Common.Providers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FluentLocalization.Common.Options;

public class FluentLocalizationActivationOption : IConfigureOptions<MvcOptions>
{
    private readonly IFluentModelMetadataProvider _fluentModelMetadataProvider;

    public FluentLocalizationActivationOption(IFluentModelMetadataProvider fluentModelMetadataProvider)
    {
        _fluentModelMetadataProvider = fluentModelMetadataProvider;
    }
    
    public void Configure(MvcOptions options)
    {
        options.ModelMetadataDetailsProviders.Add(_fluentModelMetadataProvider);
    }
}