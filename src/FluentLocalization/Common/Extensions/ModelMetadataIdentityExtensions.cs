using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

namespace FluentLocalization.Common.Extensions;

public static class ModelMetadataIdentityExtensions
{
    /// <summary>
    /// Get full property name in next format: ContainerType.FullName + "." + PropertyName
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public static string GetFullPropertyName(this ModelMetadataIdentity key)
    {
        return key.ContainerType.FullName + "." + key.Name;
    }
}