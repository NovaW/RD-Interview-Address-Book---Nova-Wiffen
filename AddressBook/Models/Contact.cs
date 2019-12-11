using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AddressBook.Models
{
    public class Contact
    {
        public Guid ExternalId { get; set; }
        public ContactModel ContactModel { get; set; }
    }

    public class ContactModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<string> ContactNumbers { get; set; }
        public ICollection<string> EmailAddresses { get; set; }
    }
}