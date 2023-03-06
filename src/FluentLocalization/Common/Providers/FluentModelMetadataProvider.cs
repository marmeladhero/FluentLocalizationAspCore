using FluentLocalization.Common.Abstract;
using FluentLocalization.Common.Extensions;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

namespace FluentLocalization.Common.Providers;

public interface IFluentModelMetadataProvider : IDisplayMetadataProvider
{
    
}

internal class FluentModelMetadataProvider : IFluentModelMetadataProvider
{
    private readonly List<IFluentConfiguration> _configurations;

    public FluentModelMetadataProvider(IEnumerable<IFluentConfiguration> configurations)
    {
        _configurations = configurations.ToList();
    }

    public void CreateDisplayMetadata(DisplayMetadataProviderContext context)
    {
        var fullPropertyName= context.Key.GetFullPropertyName();

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
}