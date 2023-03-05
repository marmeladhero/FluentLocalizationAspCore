using System.Linq.Expressions;

namespace FluentLocalization.Common.Extensions;

public static class ExpressionExtensions
{
    
    public static string GetMemberName<T, TKey>(this Expression<Func<T, TKey>> expression)
    {
        var memberExpression = expression.Body as MemberExpression;
        if (memberExpression == null)
        {
            var unaryExpression = expression.Body as UnaryExpression;
            if (unaryExpression != null)
            {
                memberExpression = unaryExpression.Operand as MemberExpression;
            }
        }
        return memberExpression?.Member.Name;
    }
}