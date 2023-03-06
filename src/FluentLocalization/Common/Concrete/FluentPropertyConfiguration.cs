using System.Linq.Expressions;
using FluentLocalization.Common.Abstract;

namespace FluentLocalization.Common.Concrete;

public class FluentPropertyConfiguration : IFluentPropertyConfiguration
{
    public Type ContainerType { get; }
    
    private string? _displayName;
    private string? _description;
    private string? _placeholder;

    public string? GetDisplayName => _displayName;
    public string? GetDescription => _description;
    public string? GetPlaceholder => _placeholder;

    public FluentPropertyConfiguration(Type containerType)
    {
        ContainerType = containerType;
    }

    public IFluentPropertyConfiguration DisplayName(string displayName)
    {
        _displayName = displayName;
        return this;
    }
    
    public IFluentPropertyConfiguration Description(string description)
    {
        _description = description;
        return this;
    }

    public IFluentPropertyConfiguration Placeholder(string placeholder)
    {
        _placeholder = placeholder;
        return this;
    }


}