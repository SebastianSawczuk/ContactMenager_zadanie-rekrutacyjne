using ContactMenager.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace ContactMenager.API.Services
{
    public interface IContactService
    {
        public ActionResult<IEnumerable> GetAll();
        public ActionResult<Contact> GetById(long id);
        public ActionResult<Contact> GetByName();

    }
}
