using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ContactMenager.API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

public class ContactMenagerContext : IdentityDbContext<ApplicationUser>
    {
        public ContactMenagerContext (DbContextOptions<ContactMenagerContext> options)
            : base(options)
        {
        }

        public DbSet<ContactMenager.API.Models.Contact> Contact { get; set; } = default!;
    }
