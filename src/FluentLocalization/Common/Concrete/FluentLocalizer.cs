using FluentLocalization.Common.Abstract;

namespace FluentLocalization.Common.Concrete;

public class FluentLocalizer : IFluentLocalizer
{
    public FluentConfigurations FluentConfigurations { get; }
    
    public FluentLocalizer(FluentConfigurations fluentConfigurations)
    {
        FluentConfigurations = fluentConfigurations;
    }
    
    public string? GetDisplayName(Type modelType, string propertyName)
    {
        if (FluentConfigurations.GetConfigurations(modelType).TryGetValue(propertyName, out var configuration))
        {
            return configuration.GetDisplayName;
        }
        return null;
    }

    public string? GetDescription(Type modelType, string propertyName)
    {
        if (FluentConfigurations.GetConfigurations(modelType).TryGetValue(propertyName, out var configuration))
        {
            return configuration.GetDescription;
        }
        return null;
    }

    public string? GetPlaceholder(Type modelType, string propertyName)
    {
        if (FluentConfigurations.GetConfigurations(modelType).TryGetValue(propertyName, out var configuration))
        {
            return configuration.GetPlaceholder;
        }
        return null;
    }
}