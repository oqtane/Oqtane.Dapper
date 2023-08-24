# Oqtane.Dapper
POC using Dapper and SQL Scripts


Package\
- debug.cmd - addition of Dapper assembly for deployment
- nuspec - addition Dapper assembly

Server\
- csproj - addition of Dapper package

Server\Manager
- Manager class implements IInstallable to execute SQL scripts

Server\Repository
- Context class for multi-tenancy
- Repository classes using Dapper, raw SQL

Server\Scripts
- SQL script files to provision table (naming convention is important)
- SQL script files must be Embedded Resources
