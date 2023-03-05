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
    services.ApplyFluentLocalizationFromAssembly();
}
```