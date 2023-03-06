using System.Linq.Expressions;
using System.Reflection;

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
        
        if (memberExpression == null)
        {
            throw new ArgumentException("Expression is not a member access", nameof(expression));
        }
        
        var propertyInfo = memberExpression.Member as PropertyInfo;
        
        if (propertyInfo == null)
        {
            throw new ArgumentException("Expression is not a property access", nameof(expression));
        }
        
        return propertyInfo.Name;
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="expression"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    /// <returns></returns>
    public static string GetFullPropertyName<T, TKey>(this Expression<Func<T, TKey>> expression)
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
        
        if (memberExpression == null)
        {
            throw new ArgumentException("Expression is not a member access", nameof(expression));
        }
        
        var propertyInfo = memberExpression.Member as PropertyInfo;
        if (propertyInfo == null)
        {
            throw new ArgumentException("Expression is not a property access", nameof(expression));
        }
        
        var declaringType = propertyInfo.DeclaringType;
        if (declaringType == null)
        {
            throw new ArgumentException("Expression is not a property access", nameof(expression));
        }
        
        var propertyPath = new List<string>();
        while (declaringType != null)
        {
            propertyPath.Add(memberExpression.Member.Name);
            memberExpression = memberExpression.Expression as MemberExpression;
            if (memberExpression == null)
            {
                break;
            }
            declaringType = memberExpression.Member.DeclaringType;
        }
        
        propertyPath.Reverse();
        return string.Join(".", propertyPath);
    }

    public static Type GetContainerType<T, TKey>(this Expression<Func<T, TKey>> expression)
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
        
        if (memberExpression == null)
        {
            throw new ArgumentException("Expression is not a member access", nameof(expression));
        }
        
        var propertyInfo = memberExpression.Member as PropertyInfo;

        if (propertyInfo == null)
        {
            throw new ArgumentException("Expression is not a property access", nameof(expression));
        }
        
        var declaringType = propertyInfo.DeclaringType;
        if (declaringType == null)
        {
            throw new ArgumentException("Expression is not a property access", nameof(expression));
        }
        
        return declaringType;
    }
}