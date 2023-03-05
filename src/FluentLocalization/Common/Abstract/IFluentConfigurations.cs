namespace FluentLocalization.Common.Abstract;

public interface IFluentConfigurations
{
    Dictionary<string, IFluentPropertyConfiguration> GetConfigurations<T>() where T : class;
    Dictionary<string, IFluentPropertyConfiguration> GetConfigurations(Type type);
    void AddRangeConfiguration(Type type, Dictionary<string, IFluentPropertyConfiguration> fluentPropertyConfigurations);
}