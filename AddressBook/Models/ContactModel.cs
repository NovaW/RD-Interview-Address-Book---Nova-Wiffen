using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AddressBook.Models
{
    public class ContactModel //rename?
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<string> ContactNumbers { get; set; }
        public IEnumerable<string> EmailAddresses { get; set; }
    }
}