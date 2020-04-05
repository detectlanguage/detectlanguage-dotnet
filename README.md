Language Detection API Client for .NET
========

[![Build Status](https://secure.travis-ci.org/detectlanguage/detectlanguage-dotnet.svg)](https://travis-ci.org/detectlanguage/detectlanguage-dotnet)

Detects language of the given text. Returns detected language codes and scores.

## Installation

Using the [.NET Core command-line interface (CLI) tools][dotnet-core-cli-tools]:

```sh
dotnet add package DetectLanguage
```

Using the [NuGet Command Line Interface (CLI)][nuget-cli]:

```sh
nuget install DetectLanguage
```

Using the [Package Manager Console][package-manager-console]:

```powershell
Install-Package DetectLanguage
```

From within Visual Studio:

1. Open the Solution Explorer.
2. Right-click on a project within your solution.
3. Click on *Manage NuGet Packages...*
4. Click on the *Browse* tab and search for "DetectLanguage".
5. Click on the DetectLanguage package, select the appropriate version in the
   right-tab and click *Install*.

## Documentation

For a comprehensive list of examples, check out the [API documentation][api-docs].

## Configuration

Before using Detect Language API client you have to setup your personal API key.
You can get it for free by signing up at https://detectlanguage.com

```c#
using DetectLanguage;

DetectLanguageClient client = new DetectLanguageClient("YOUR API KEY");
```

## Usage

### Language detection

```c#
DetectResult[] results = await client.DetectAsync("Buenos dias señor");
```

### Single language code detection

If you need just a language code you can use `DetectCodeAsync`. It returns first detected language code.

```c#
string languageCode = await client.DetectCodeAsync("Buenos dias señor");
```

### Batch detection

It is possible to detect language of several texts with one request.
This method is significantly faster than doing one request per text.
To use batch detection just pass multiple texts to `BatchDetectAsync` method.

```c#
string[] texts = {"labas rytas", "good morning"};
DetectResult[][] results = await client.BatchDetectAsync(texts);
```

### Getting your account status

```c#
UserStatus userStatus = client.GetUserStatusAsync();
```

### Getting list supported languages

```c#
Language[] languages = client.GetLanguagesAsync();
```

## License

Detect Language API .NET Client is free software, and may be redistributed under the terms specified in the MIT-LICENSE file.

[api-docs]: https://detectlanguage.com/documentation
[dotnet-core-cli-tools]: https://docs.microsoft.com/en-us/dotnet/core/tools/
[nuget-cli]: https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference
[package-manager-console]: https://docs.microsoft.com/en-us/nuget/tools/package-manager-console
