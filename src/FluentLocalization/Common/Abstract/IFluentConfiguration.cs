using System.Linq.Expressions;

namespace FluentLocalization.Common.Abstract;

public interface IFluentConfiguration
{
    Dictionary<string, IFluentPropertyConfiguration> Configurations { get; }
}

public interface IFluentConfiguration<T> : IFluentConfiguration where T : class
{
    IFluentPropertyConfiguration For<TKey>(Expression<Func<T, TKey>> expression);
    IFluentPropertyConfiguration<T, TKey> ForEnumerable<TKey>(Expression<Func<T, TKey>> expression);
}

public interface IFluentPropertyConfiguration
{
    Type ContainerType { get; }
    
    string? GetDisplayName { get; }
    string? GetDescription { get; }
    string? GetPlaceholder { get; }
    
    IFluentPropertyConfiguration DisplayName(string displayName);
    IFluentPropertyConfiguration Description(string description);
    IFluentPropertyConfiguration Placeholder(string placeholder);

}

public interface IFluentPropertyConfiguration<TEntity, TProperty> : IFluentPropertyConfiguration
{
    // IFluentPropertyConfiguration<TEntity, TProperty> For<TPreviousProperty>();
}