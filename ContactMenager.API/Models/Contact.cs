﻿namespace ContactMenager.API.Models
{
    public class Contact
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ContactTypeEnum Type { get; set; }
        public string Other { get; set; }
        public int PhoneNumber { get; set; }
        public DateOnly BirthDate { get; set; }
    }
}
