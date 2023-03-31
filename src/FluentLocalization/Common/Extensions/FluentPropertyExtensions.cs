using System.Linq.Expressions;
using FluentLocalization.Common.Abstract;

namespace FluentLocalization.Common.Extensions;

public static class FluentPropertyExtensions
{
    public static IFluentPropertyConfiguration<TEntity, TProperty> AndFor<TEntity, TPreviousProperty, TProperty>(
        this IFluentPropertyConfiguration<TEntity, List<TPreviousProperty>> source,
        Expression<Func<TPreviousProperty, TProperty>> expression)
    {
        throw new NotImplementedException();
    }

}

