using System.Collections.Generic;
using System.Threading.Tasks;
using MyCompany.Module.Dapper.Models;

namespace MyCompany.Module.Dapper.Repository
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetClients(int SiteId);
        Task<Client> GetClient(int ClientId);
        Task<Client> AddClient(Client Client);
        Task<Client> UpdateClient(Client Client);
        Task DeleteClient(int ClientId);
    }
}
