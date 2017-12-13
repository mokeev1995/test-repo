# Test task

## Requirements

Project can be runned at all platforms supported by .Net Core (Win, Linux, macOS).

 - (optional, code editing or viewing) Visual Studio 2017 (>= 15.4) or Rider 2017.2 (or newer) or Visual Studio Code with C# extensions.
 - .Net Core 2.0 Runtime/SDK (usually installed with VS2017). Can be downloaded [\<here\>](https://www.microsoft.com/net/download/windows).

## How to run

### Auto
#### Run
- Open solution file (`ConfirmitTest.sln`)
- Run app in `Debug` or `Release` configurations.

#### Test
If you're using ReSharper than you can just select folder in VS2017 and run all tests. 
Otherwise you can use internal Visual Studio Testing features or run it manually (described below).
Possibly Rider has the same option, but I didn't check that.
AFAIK Visual Studio Code doesn't have any tests runnig option, so you should configure it yourself or just run it manually.

#### Known issues
 - If you're trying to run or debug it in Rider, you should to check option `Open in external cosole` or somthing like that in `Run configuration` window.

### Manual
#### Run
 - Open `Terminal`/`CMD`/`PowerShell`
 - Navigate to `{PATH_TO_REPO}/src/ConfirmitTest.App`
 - Run `dotnet restore`
 - Run `dotnet run`

#### Test
 - Open `Terminal`/`CMD`/`PowerShell`
 - Navigate to `{PATH_TO_REPO}/tests/{TEST_PROJECT_NAME}`
 - Run `dotnet restore`
 - Run `dotnet test`

For next test project you need to do the same operations.
