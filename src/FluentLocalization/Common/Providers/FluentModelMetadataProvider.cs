using FluentLocalization.Common.Abstract;
using FluentLocalization.Common.Extensions;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.Extensions.Logging;

namespace FluentLocalization.Common.Providers;

public interface IFluentModelMetadataProvider : IDisplayMetadataProvider
{
    
}

internal class FluentModelMetadataProvider : IFluentModelMetadataProvider
{
    private readonly ILogger<FluentModelMetadataProvider> _logger;
    private readonly List<IFluentConfiguration>? _configurations;

    public FluentModelMetadataProvider(ILogger<FluentModelMetadataProvider> logger, IEnumerable<IFluentConfiguration>? configurations)
    {
        _logger = logger;
        _configurations = configurations?.ToList();
    }

    public void CreateDisplayMetadata(DisplayMetadataProviderContext context)
    {
        if(_configurations == null || context == null)
            return;
        
        try
        {
            var fullPropertyName= context.Key.GetFullPropertyName();
        
            if (string.IsNullOrEmpty(fullPropertyName))
                return;
        
            var configuration = _configurations.FirstOrDefault(x => x.Configurations.ContainsKey(fullPropertyName));

            if (configuration != null)
            {
                if (configuration.Configurations.TryGetValue(fullPropertyName, out var cfg))
                {
                    var propertyDisplayName = cfg.GetDisplayName;
                    var propertyDescription = cfg.GetDescription;
                    var propertyPlaceholder = cfg.GetPlaceholder;
            
                    if (string.IsNullOrEmpty(propertyDisplayName) == false)
                    {
                        context.DisplayMetadata.DisplayName = () => propertyDisplayName;
                    }

                    if (string.IsNullOrEmpty(propertyDescription) == false)
                    {
                        context.DisplayMetadata.Description = () => propertyDescription;
                    }

                    if (string.IsNullOrEmpty(propertyPlaceholder) == false)
                    {
                        context.DisplayMetadata.Placeholder = () => propertyPlaceholder;
                    }
                }
            }
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error in FluentModelMetadataProvider");
        }
    }
}