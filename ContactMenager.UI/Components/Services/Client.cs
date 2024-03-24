
using ContactMenager.UI.Services.Interfaces;
using ContactMenager.UI.ViewModels;

namespace ContactMenager.UI.Services
{
    public class ClientService : IClientService
    {
        private readonly HttpClient _httpClient;

        public ClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public HttpClient HttpClient
        {
            get { return _httpClient; }
        }

        public async Task<ContactViewModel[]> GetContacts()
        {
            return await _httpClient.GetFromJsonAsync<ContactViewModel[] >("contacts") ?? [];
        }
    }
}
