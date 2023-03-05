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
        var key = expression.GetMemberName();
        
        if (Configurations.ContainsKey(key))
        {
            return Configurations[key];
        }

        var cfg = new FluentPropertyConfiguration();
        Configurations.Add(key, cfg);
        return cfg;
    }
}

