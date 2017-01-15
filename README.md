# Lagos dotnet user group

this repository contains source code for the [Lagos dotnet user group](http://lagdotnetusergroup.com/)
## This application consists of:

*   Views using ASP.NET Core MVC
*   [Gulp](https://go.microsoft.com/fwlink/?LinkId=518007) and [Bower](https://go.microsoft.com/fwlink/?LinkId=518004) for managing client-side libraries
*   Theming using [Bootstrap](https://go.microsoft.com/fwlink/?LinkID=398939)

## Run & Deploy

restore the .NET core packages described in the `package.json` and verify that it works:

```bash
dotnet restore
dotnet run
```

The `dotnet restore` command first restorest the necessary packages required to run the application, 
the `dotnet restore` command simultaneously re-compiles and runs the `kestrel-server`.