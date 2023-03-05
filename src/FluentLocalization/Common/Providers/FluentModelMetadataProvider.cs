using FluentLocalization.Common.Abstract;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

namespace FluentLocalization.Common.Providers;

public interface IFluentModelMetadataProvider : IDisplayMetadataProvider
{
    
}

internal class FluentModelMetadataProvider : IFluentModelMetadataProvider
{
    private readonly IFluentLocalizer _localizer;

    public FluentModelMetadataProvider(IFluentLocalizer localizer)
    {
        _localizer = localizer;
    }

    public void CreateDisplayMetadata(DisplayMetadataProviderContext context)
    {
        
        var modelType = context.Key.ModelType;
        var modelMetadata = context.DisplayMetadata;

        if (modelType.IsClass)
        {
            var properties = modelType.GetProperties();
            foreach (var property in properties)
            {
                var propertyName = property.Name;

                var propertyDisplayName = _localizer.GetDisplayName(modelType, propertyName) ?? propertyName;
                var propertyDescription = _localizer.GetDescription(modelType, propertyName);
                var propertyPlaceholder = _localizer.GetPlaceholder(modelType, propertyName);
                
                if (!string.IsNullOrEmpty(propertyDisplayName))
                {
                    modelMetadata.DisplayName = () => propertyDisplayName;
                    modelMetadata.Placeholder = () => propertyPlaceholder;
                    modelMetadata.Description = () => propertyDescription;
                }
            }
        }
    }
}