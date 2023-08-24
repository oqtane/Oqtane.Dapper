# Oqtane.Dapper
POC using Dapper and SQL Scripts


Package
> debug.cmd - notice addition of Dapper assembly for deployment
> nuspec - notice addition Dapper assembly

Server\MyCompany.Module.Dapper.Server.csproj
> addition of Dapper package

Server\Manager
> Manager class implements IInstallable to execute SQL scripts

Server\Repository
> Context class for multi-tenancy
> Repository classes using Dapper, raw SQL

Server\Scripts
> SQL script files to provision table (naming convention is important)
