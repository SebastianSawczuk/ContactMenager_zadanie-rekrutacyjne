using ContactMenager.UI.ViewModels;

namespace ContactMenager.UI.Services.Interfaces
{
    //interfejs serwisu, aby skorzystać z odwrócenia zależności 
    public interface IContactService
    {
        Task<ContactViewModel[]> GetContacts();
        Task<ContactViewModel> GetContactById(long id);
        Task<HttpResponseMessage> AddContact(ContactViewModel contactViewModel);
    }
}
