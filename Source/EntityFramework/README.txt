1./ EntityFramework6 .NET 4.6 project (Database First model)
- Install:
 + Download installer "sqlite-netFx46-setup-bundle-x86-2015-1.0.102.0.exe" on page https://system.data.sqlite.org/index.html/doc/trunk/www/downloads.wiki.
 + Download package "System.Data.SQLite" (version 1.0.102) on NuGet.
 + Open "App.config", change database location at "connectionString" node.
- References:
 + https://erazerbrecht.wordpress.com/2015/06/11/sqlite-entityframework-6-tutorial/

- Update model: Open "RiceModel.edmx" -> Right click on diagram -> "Update Model from Database..."
- Generate database: Open "RiceModel.edmx" -> Right click on diagram -> "Generate Database from Model..."
- Validate model: Open "RiceModel.edmx" -> Right click on diagram -> "Validate"

2./ EntityFrameworkCore1 .NET Core 1 project (Database First model)
- Install:
 + Download packages "Microsoft.EntityFrameworkCore.Tools" & "Microsoft.EntityFrameworkCore.Sqlite.Design"
 + Open "project.json", add "Microsoft.EntityFrameworkCore.Tools" to "tools" section.
 + Set as startup project.
 + Build project.
 + Tools –> NuGet Package Manager –> Package Manager Console, run the following command:
   "Scaffold-DbContext "Filename=<database location>\Rice.db" Microsoft.EntityFrameworkCore.Sqlite -OutputDir Models"
 + Open "Models" folder -> "RiceContext.cs", change database location at "OnConfiguring" method.

- References:
 + https://docs.efproject.net/en/latest/index.html
 + https://docs.efproject.net/en/latest/platforms/aspnetcore/existing-db.html