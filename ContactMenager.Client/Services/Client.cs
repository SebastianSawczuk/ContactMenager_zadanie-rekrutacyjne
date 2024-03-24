
using ContactMenager.Client.Services.Interfaces;
using ContactMenager.Client.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ContactMenager.Client.Services
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
