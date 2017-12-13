# Test task

## Requirements

 - Visual Studio 2017 (>= 15.4) or Rider 2017.2 (or newer)
 - .Net Core 2.0 SDK (usually installed with VS2017)

## How to run

### Auto

- Open solution file (`ConfirmitTest.sln`)
- Run app in `Debug` or `Release` configurations.

#### Known issues
 - if you're trying to run it in Rider, you should to check option `Open in external cosole` or somthing like that in `Run configuration` window.

### Manual
 - Open Terminal/CMD/PowerShell
 - Navigate to `{PATH_TO_DIST}/src/ConfirmitTest.App`
 - Run `dotnet restore`
 - Run `dotnet run`
