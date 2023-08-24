using Oqtane.Models;
using Oqtane.Infrastructure;
using Oqtane.Repository;

namespace MyCompany.Module.Dapper.Manager
{
    public class ClientManager : IInstallable
    {
        private ISqlRepository _sql;

        public ClientManager(ISqlRepository sql)
        {
            _sql = sql;
        }

        public bool Install(Tenant tenant, string version)
        {
            return _sql.ExecuteScript(tenant, GetType().Assembly, "MyCompany.Module.Dapper." + version + ".sql");
        }

        public bool Uninstall(Tenant tenant)
        {
            return _sql.ExecuteScript(tenant, GetType().Assembly, "MyCompany.Module.Dapper.Uninstall.sql");
        }
    }
}
