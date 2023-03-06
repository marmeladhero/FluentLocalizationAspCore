using System.Linq.Expressions;
using FluentLocalization.Common.Abstract;
using FluentLocalization.Common.Extensions;

namespace FluentLocalization.Common.Concrete;

public abstract class AbstractFluentConfigurationLocalization<T> : IFluentConfiguration<T> where T : class
{
    public Dictionary<string, IFluentPropertyConfiguration> Configurations { get; }
    public AbstractFluentConfigurationLocalization()
    {
        Configurations = new Dictionary<string, IFluentPropertyConfiguration>();
    }
    
    public IFluentPropertyConfiguration For<TKey>(Expression<Func<T, TKey>> expression)
    {
        var mainType = typeof(T);
       
        var key = expression.GetMemberName();
        
        var containerType = expression.GetContainerType();
        
        string name = string.Empty;
        
        name = containerType.FullName + "." + key; 
        
        if (Configurations.ContainsKey(name))
        {
            return Configurations[name];
        }
        FluentPropertyConfiguration cfg = new FluentPropertyConfiguration(containerType);
        Configurations.Add(name, cfg);
        return cfg;
    }
}

