<!---[![Build status](https://img.shields.io/circleci/project/github/BlazorExtensions/Storage.svg)](https://ci.dot.net/job/dotnet_orleans/job/master/)-->
[![Package Version](https://img.shields.io/nuget/v/Blazor.Extensions.Storage.svg)](https://www.nuget.org/packages/Blazor.Extensions.Storage)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Blazor.Extensions.Storage.svg)](https://www.nuget.org/packages/Blazor.Extensions.Storage)
[![License](https://img.shields.io/github/license/BlazorExtensions/Storage.svg)](https://github.com/BlazorExtensions/Storage/blob/master/LICENSE)

# Blazor Extensions

Blazor Extensions are a set of packages with the goal of adding useful things to [Blazor](https://blazor.net).

# Blazor Extensions Storage

This package wraps [HTML5 Storage](https://developer.mozilla.org/en-US/docs/Web/API/Storage) APIs. Both Session and Local storage types are supported.

# Sample configuration

## Setup

The following snippet shows how to setup the storage wrapper by registering it for dependency injection in the ```Program.cs``` of the application.

```c#
var serviceProvider = new BrowserServiceProvider(services =>
{
    // Add Blazor.Extensions.Storage
    // Both SessionStorage and LocalStorage are registered
    services.AddStorage();
});
```

## Usage

The following snippet shows how to consume the storage API in a Blazor component.

```c#
@inject SessionStorage sessionStorage
@inject LocalStorage localStorage

@functions {
  protected override async Task OnInitAsync()
  {
        var key = "forecasts";
        sessionStorage.SetItem<WeatherForecast[]>(key, forecasts);
        localStorage.SetItem<WeatherForecast[]>(key, forecasts);
        var fromSession = sessionStorage.GetItem<WeatherForecast[]>(key);
        var fromLocal = localStorage.GetItem<WeatherForecast[]>(key);
  }
}
```

If you want to consume it outside of a ```cshtml``` based component, then you can use the ```Inject``` attribute to inject it into the class.

```c#
[Inject]
protected SessionStorage sessionStorage;

[Inject]
protected LocalStorage localStorage;

public void LogSomething()
{
        var key = "forecasts";
        sessionStorage.SetItem<WeatherForecast[]>(key, forecasts);
        localStorage.SetItem<WeatherForecast[]>(key, forecasts);
        var fromSession = sessionStorage.GetItem<WeatherForecast[]>(key);
        var fromLocal = localStorage.GetItem<WeatherForecast[]>(key);
}
```

# Contributions and feedback

Please feel free to use the component, open issues, fix bugs or provide feedback.

# Contributors

The following people are the maintainers of the Blazor Extensions projects:

- [Attila Hajdrik](https://github.com/attilah)
- [Gutemberg Ribiero](https://github.com/galvesribeiro)
