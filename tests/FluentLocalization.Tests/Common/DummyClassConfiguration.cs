using FluentLocalization.Common.Abstract;
using FluentLocalization.Common.Concrete;
using FluentLocalization.Common.Extensions;

namespace FluentLocalization.Tests.Common;

public class DummyClassConfiguration : AbstractFluentConfigurationLocalization<DummyClass>
{
    public DummyClassConfiguration()
    {
        For(x => x.Property).DisplayName("DisplayNameProperty").Description("DescriptionProperty").Placeholder("PlaceholderProperty");
        For(x => x.Property1).DisplayName("DisplayNameProperty1").Description("DescriptionProperty1").Placeholder("PlaceholderProperty1");
        For(x => x.NestedClass.Property2).DisplayName("DisplayNameProperty2").Description("DescriptionProperty2").Placeholder("PlaceholderProperty2");
        For(x => x.NestedClass.NestedNestedClass.Property3).DisplayName("DisplayNameProperty3").Description("DescriptionProperty3").Placeholder("PlaceholderProperty3");
        ForEnumerable(x => x.NestedClasses).AndFor(x => x.Property2)
            .DisplayName("DisplayNameProperty2").Placeholder("PlaceholderProperty2");
    }
}