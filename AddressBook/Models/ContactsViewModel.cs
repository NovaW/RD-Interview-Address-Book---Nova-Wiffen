using System;
using System.Collections.Generic;

namespace AddressBook.Models
{
    public class ContactsViewModel
    {
        public IEnumerable<Contact> Contacts { get; set; }
        public string SearchTerm { get; set; }
    }
}