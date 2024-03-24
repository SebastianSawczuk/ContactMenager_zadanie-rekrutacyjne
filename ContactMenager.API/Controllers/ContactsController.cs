using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContactMenager.API.Models;
using Microsoft.AspNetCore.Authorization;

namespace ContactMenager.API.Controllers
{
    //URI pod którym dostępne są akcje kontrolera
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ContactMenagerContext _context;

        public ContactsController(ContactMenagerContext context)
        {
            _context = context;
        }

        // akcja zwarcająca listę wszystkich kontaktów 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContact()
        {
            await Task.Delay(500);
            return await _context.Contact.ToListAsync();
        }

        // akcja zwracająca kontakt o podanym id 
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContact(long id)
        {
            var contact = await _context.Contact.FindAsync(id);

            if (contact == null)
            {
                return NotFound();
            }

            return contact;
        }

        // akcja przyjumjąca id oraz obiekt kontaktu i jest odpowiedzialna za edycje 
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContact(long id, Contact contact)
        {
            //sprawdzam czy request napewno odwołuje się od tego samego obiektu 
            if (id != contact.Id)
            {
                return BadRequest();
            }

            //nadanie jakiejś flagi modyfikacji ?
            _context.Entry(contact).State = EntityState.Modified;

            try
            {
                //zapisanie zmian w bazie
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Contact>> PostContact(Contact contact)
        {
            _context.Contact.Add(contact);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContact", new { id = contact.Id }, contact);
        }

        // DELETE: api/Contacts/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(long id)
        {
            var contact = await _context.Contact.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }

            _context.Contact.Remove(contact);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContactExists(long id)
        {
            return _context.Contact.Any(e => e.Id == id);
        }
    }
}
