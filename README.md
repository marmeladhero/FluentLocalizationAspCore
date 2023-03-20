# Simple Fluent Localization
Fluent Localization is a simple localization library for .NET Core. It is based on the [Fluent API](https://en.wikipedia.org/wiki/Fluent_interface) and is designed to be easy to use and easy to extend.

## Installation
Fluent Localization is available on [NuGet](https://www.nuget.org/packages/FluentLocalizationAspCore/).

```
PM> Install-Package FluentLocalizationAspCore
```

## Usage
### Configuration
To use Fluent Localization, you need to configure it in your `Startup.cs` file.

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddFluentLocalization();
}
```
### Add Localization Configuration From Assemblies
To add localization configuration from assemblies, you need to call the `AddLocalizationConfigurationFromAssemblies` method in your `Startup.cs` file.
```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.ApplyFluentLocalizationFromAssemblies(Assembly.GetAssembly(typeof(Startup)));
}
```
It is also possible to add localization configuration from multiple assemblies.
```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.ApplyFluentLocalizationFromAssemblies(Assembly.GetAssembly(typeof(Startup)), Assembly.GetAssembly(typeof(OtherClass)));
}
```
### How it works
It's uses `IDisplayMetadataProvider` interface to add localization configuration to the model.

### Example usage
```csharp
public class Person 
{
    public string Name { get; set; }
}

public class PersonLocalizationConfiguration : AbstractFluentConfigurationLocalization<Person>
{
    public override void Configure()
    {
        For(x => x.Name).DisplayName("User name");
    }
}
```
And it will automatically replace the display name of the `Name` property with `User name`.
Works in razor pages 100%