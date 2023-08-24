using Oqtane.Models;
using Oqtane.Modules;

namespace MyCompany.Module.Dapper
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "Dapper Example",
            Description = "POC using Dapper and SQL Scripts",
            Version = "1.0.0",
            ReleaseVersions = "1.0.0",
            ServerManagerType = "MyCompany.Module.Dapper.Manager.ClientManager, MyCompany.Module.Dapper.Server.Oqtane",
            Dependencies = "MyCompany.Module.Dapper.Shared.Oqtane",
            PackageName = "MyCompany.Module.Dapper" 
        };
    }
}
