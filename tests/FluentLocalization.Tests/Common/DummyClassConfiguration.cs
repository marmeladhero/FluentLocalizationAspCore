using FluentLocalization.Common.Abstract;
using FluentLocalization.Common.Concrete;

namespace FluentLocalization.Tests.Common;

public class DummyClassConfiguration : AbstractFluentConfigurationLocalization<DummyClass>
{
    public DummyClassConfiguration() : base()
    {
        For(x => x.Property).DisplayName("DisplayNameProperty").Description("DescriptionProperty").Placeholder("PlaceholderProperty");
    }
}