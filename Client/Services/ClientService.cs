using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Oqtane.Modules;
using Oqtane.Services;
using Oqtane.Shared;

namespace MyCompany.Module.Dapper.Services
{
    public class ClientService : ServiceBase, IClientService, IService
    {
        public ClientService(HttpClient http, SiteState siteState) : base(http, siteState) { }

        private string Apiurl => CreateApiUrl("Client");

        public async Task<List<Models.Client>> GetClientsAsync()
        {
            List<Models.Client> Clients = await GetJsonAsync<List<Models.Client>>($"{Apiurl}", Enumerable.Empty<Models.Client>().ToList());
            return Clients.OrderBy(item => item.Name).ToList();
        }

        public async Task<Models.Client> GetClientAsync(int ClientId)
        {
            return await GetJsonAsync<Models.Client>($"{Apiurl}/{ClientId}");
        }

        public async Task<Models.Client> AddClientAsync(Models.Client Client)
        {
            return await PostJsonAsync<Models.Client>($"{Apiurl}", Client);
        }

        public async Task<Models.Client> UpdateClientAsync(Models.Client Client)
        {
            return await PutJsonAsync<Models.Client>($"{Apiurl}/{Client.ClientId}", Client);
        }

        public async Task DeleteClientAsync(int ClientId)
        {
            await DeleteAsync($"{Apiurl}/{ClientId}");
        }
    }
}
