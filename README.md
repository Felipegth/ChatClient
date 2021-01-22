# ChatClient

Projeto modelo de estudo de aplicação de conceitos SignalR em .NET.
## Prerequisites

* .NET 5.0
* Visual Studio Community 2019

## Create project

```shell
mkdir ./src
touch README.md
git init
dotnet new gitignore
```

```shell
cd src
dotnet new console -o ChatClient
```

## Build

```shell
dotnet run --project src\ChatClient\ChatClient.csproj
```

## References

https://docs.microsoft.com/pt-br/aspnet/core/tutorials/signalr?view=aspnetcore-5.0&tabs=visual-studio
