using System.Linq.Expressions;
using FluentLocalization.Common.Abstract;

namespace FluentLocalization.Common.Concrete;

public class FluentPropertyConfiguration : IFluentPropertyConfiguration
{
    private readonly Dictionary<string, IFluentPropertyConfiguration> _fluentPropertyConfigurations;
    public Type ContainerType { get; }
    
    private string? _displayName;
    private string? _description;
    private string? _placeholder;

    public string? GetDisplayName => _displayName;
    public string? GetDescription => _description;
    public string? GetPlaceholder => _placeholder;

    public FluentPropertyConfiguration(Dictionary<string, IFluentPropertyConfiguration> fluentPropertyConfigurations,
        Type containerType)
    {
        _fluentPropertyConfigurations = fluentPropertyConfigurations;
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
    
    public void AddKey(string name)
    {
        _fluentPropertyConfigurations.Add(name, this);
    }
}

public class FluentPropertyConfiguration<TEntity, TProperty> : FluentPropertyConfiguration, IFluentPropertyConfiguration<TEntity, TProperty>
    where TEntity : class
{
    public FluentPropertyConfiguration(IFluentPropertyConfiguration cfg, Dictionary<string, IFluentPropertyConfiguration> fluentPropertyConfigurations, Type containerType) : base(fluentPropertyConfigurations, containerType)
    {
    }
    public FluentPropertyConfiguration(Dictionary<string, IFluentPropertyConfiguration> fluentPropertyConfigurations, Type containerType) : base(fluentPropertyConfigurations, containerType)
    {
    }
}