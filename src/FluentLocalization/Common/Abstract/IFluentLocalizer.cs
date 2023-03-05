namespace FluentLocalization.Common.Abstract;

public interface IFluentLocalizer
{
    string? GetDisplayName(Type modelType, string propertyName);
    string? GetDescription(Type modelType, string propertyName);
    string? GetPlaceholder(Type modelType, string propertyName);
}