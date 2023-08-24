using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using Oqtane.Modules;
using Oqtane.Models;
using System;
using Oqtane.Infrastructure;
using Oqtane.Shared;

namespace MyCompany.Module.Dapper.Repository
{
    public class Context : IService
    {
        private readonly ITenantManager _tenantManager;
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public Context(ITenantManager tenantManager, IConfiguration configuration)
        {
            _tenantManager = tenantManager;
            _configuration = configuration;

            Tenant tenant = _tenantManager.GetTenant();
            if (tenant != null)
            {
                _connectionString = _configuration.GetConnectionString(tenant.DBConnectionString)
                    .Replace($"|{Constants.DataDirectory}|", AppDomain.CurrentDomain.GetData(Constants.DataDirectory)?.ToString());
            }
        }
        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}
