using FluentLocalization.Common.Abstract;
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
        if (_configurations.Any(x => x.GetBaseType == context.Key.ContainerType))
        {
            var configuration = _configurations.First(x => x.GetBaseType == context.Key.ContainerType);
            if (configuration.Configurations.TryGetValue(context.Key.Name, out var cfg))
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