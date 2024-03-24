using ContactMenager.Client.ViewModels;

namespace ContactMenager.Client.Services.Interfaces
{
    public interface IContactService
    {
        Task<ContactViewModel[]> GetContacts();
        Task<ContactViewModel> GetContactById(long id);
    }
}
