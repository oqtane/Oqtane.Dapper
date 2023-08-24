using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Oqtane.Modules;
using MyCompany.Module.Dapper.Models;
using Dapper;
using System.Threading.Tasks;
using System.Data;
using System;

namespace MyCompany.Module.Dapper.Repository
{
    public class ClientRepository : IClientRepository, ITransientService
    {
        private readonly Context _context;

        public ClientRepository(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Models.Client>> GetClients(int SiteId)
        {
            var query = "SELECT * FROM MyCompanyClient WHERE SiteId = @SiteId";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<Client>(query, new { SiteId });
            }
        }

        public async Task<Models.Client> GetClient(int ClientId)
        {
            var query = "SELECT * FROM MyCompanyClient WHERE ClientId = @ClientId";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<Client>(query, new { ClientId });
            }
        }

        public async Task<Models.Client> AddClient(Models.Client Client)
        {
            var query = "INSERT INTO MyCompanyClient (SiteId, Name, CreatedBy, CreatedOn, ModifiedBy, ModifiedOn) VALUES (@SiteId, @Name, @CreatedBy, @CreatedOn, @ModifiedBy, @ModifiedOn) SELECT CAST(SCOPE_IDENTITY() as int)";    
            var parameters = new DynamicParameters();
            parameters.Add("SiteId", Client.SiteId, DbType.Int32);
            parameters.Add("Name", Client.Name, DbType.String);
            parameters.Add("CreatedBy", "", DbType.String);
            parameters.Add("CreatedOn", DateTime.UtcNow, DbType.DateTime);
            parameters.Add("ModifiedBy", "", DbType.String);
            parameters.Add("ModifiedOn", DateTime.UtcNow, DbType.DateTime);
            using (var connection = _context.CreateConnection())
            {
                Client.ClientId = await connection.QuerySingleAsync<int>(query, parameters);
                return Client;
            }
        }

        public async Task<Models.Client> UpdateClient(Models.Client Client)
        {
            var query = "UPDATE MyCompanyClient SET SiteId = @SiteId, Name = @Name, CreatedBy = @CreatedBy, CreatedOn = @CreatedOn, ModifiedBy = @ModifiedBy, ModifiedOn = @ModifiedOn WHERE ClientId = @ClientId";
            var parameters = new DynamicParameters();
            parameters.Add("ClientId", Client.ClientId, DbType.Int32);
            parameters.Add("SiteId", Client.SiteId, DbType.Int32);
            parameters.Add("Name", Client.Name, DbType.String);
            parameters.Add("CreatedBy", "", DbType.String);
            parameters.Add("CreatedOn", DateTime.UtcNow, DbType.DateTime);
            parameters.Add("ModifiedBy", "", DbType.String);
            parameters.Add("ModifiedOn", DateTime.UtcNow, DbType.DateTime);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
            return Client;
        }

        public async Task DeleteClient(int ClientId)
        {
            var query = "DELETE FROM MyCompanyClient WHERE ClientId = @ClientId";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { ClientId });
            }
        }
    }
}
