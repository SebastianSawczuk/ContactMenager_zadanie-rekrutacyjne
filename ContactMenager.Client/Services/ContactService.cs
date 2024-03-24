using ContactMenager.Client.Services.Interfaces;
using ContactMenager.Client.ViewModels;

namespace ContactMenager.Client.Services
{
    public class ContactService : IContactService
    {
        private readonly HttpClient _httpClient;

        public ContactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ContactViewModel> GetContactById(long id)
        {
            var contact = await _httpClient.GetFromJsonAsync<ContactViewModel>($"api/contacts{id}");
            return contact;
        }

        public async Task<ContactViewModel[]> GetContacts()
        {
            return await _httpClient.GetFromJsonAsync<ContactViewModel[]>("api/contacts") ?? [];
        }
    }
}
