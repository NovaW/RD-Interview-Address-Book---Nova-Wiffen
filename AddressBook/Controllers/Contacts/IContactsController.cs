using AddressBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AddressBook.Contacts.Controllers
{
    public interface IContactsController
    {
        IEnumerable<Contact> GetContacts();
        IEnumerable<Contact> SearchContacts(string searchTerm);
        Contact CreateContact(ContactModel createRequest);
        Contact UpdateContact(Contact updateRequest);
        bool DeleteContact(Guid ContactId);
    }
}