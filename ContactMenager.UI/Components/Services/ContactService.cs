using ContactMenager.UI.Services.Interfaces;
using ContactMenager.UI.ViewModels;

namespace ContactMenager.UI.Services
{
    //serwis odpowiedzialny za kontakt z api
    public class ContactService : IContactService
    {
        private readonly HttpClient _httpClient;

        public ContactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> AddContact(ContactViewModel contactViewModel)
        {
            return await _httpClient.PostAsJsonAsync<ContactViewModel>("api/contacts", contactViewModel);
        }

        public async Task<ContactViewModel> GetContactById(long id)
        {
            var contact = await _httpClient.GetFromJsonAsync<ContactViewModel>($"api/contacts/{id}");
            return contact;
        }

        public async Task<ContactViewModel[]> GetContacts()
        {
            return await _httpClient.GetFromJsonAsync<ContactViewModel[]>("api/contacts") ?? [];
        }
    }
}
