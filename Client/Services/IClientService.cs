using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyCompany.Module.Dapper.Services
{
    public interface IClientService 
    {
        Task<List<Models.Client>> GetClientsAsync();

        Task<Models.Client> GetClientAsync(int ClientId);

        Task<Models.Client> AddClientAsync(Models.Client Client);

        Task<Models.Client> UpdateClientAsync(Models.Client Client);

        Task DeleteClientAsync(int ClientId);
    }
}
