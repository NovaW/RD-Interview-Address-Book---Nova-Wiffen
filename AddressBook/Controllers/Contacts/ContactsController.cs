using AddressBook.Models;
using AddressBookEntityFramework;
using AddressBookEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AddressBook.Contacts.Controllers
{
    public class ContactsController : ApiController, IContactsController
    {
        public Models.Contact CreateContact(ContactModel createRequest)
        {
            var contactEntity = ConvertContactModelToEntity(createRequest);
            using (var dbContext = new ContactsContext())
            {
                dbContext.Contacts.Add(contactEntity);
                dbContext.SaveChanges();
            }
            return ConvertContactEntityToContactModel(contactEntity);
        }

        public void DeleteContact(Guid ContactId)
        {
            using (var dbContext = new ContactsContext())
            {
                var itemToRemove = dbContext.Contacts.SingleOrDefault(x => x.ExternalId == ContactId);
                if (itemToRemove != null) {
                    dbContext.ContactNumbers.RemoveRange(itemToRemove.ContactNumbers);
                    dbContext.EmailAddresses.RemoveRange(itemToRemove.EmailAddresses);
                    dbContext.Contacts.Remove(itemToRemove);
                    dbContext.SaveChanges();
                }
            }
        }

        public IEnumerable<Models.Contact> GetContacts()
        {
            using (var dbContext = new ContactsContext())
            {
                var contactsList = dbContext.Contacts.Select(x => x).ToList();
                var contacts = contactsList.Select(x => ConvertContactEntityToContactModel(x)).ToList();

                return contacts;
            }
        }

        public IEnumerable<Models.Contact> SearchContacts(string searchTerm)
        {
            using (var dbContext = new ContactsContext())
            {
                var searchResults = dbContext.Contacts.Where(
                    x => x.FirstName.Contains(searchTerm)
                    || x.LastName.Contains(searchTerm)
                ).ToList();
                return searchResults.Select(x => ConvertContactEntityToContactModel(x)).ToList();
            }
        }

        public Models.Contact UpdateContact(Models.Contact updateRequest)
        {
            using (var dbContext = new ContactsContext())
            {
                var contactToUpdate = dbContext.Contacts.Where(x => x.ExternalId == updateRequest.ExternalId).First();
                contactToUpdate.FirstName = updateRequest.ContactModel.FirstName;
                contactToUpdate.LastName = updateRequest.ContactModel.LastName;
                contactToUpdate.ContactNumbers = updateRequest.ContactModel.ContactNumbers.Select(x => new ContactNumber { Number = x }).ToList();
                contactToUpdate.EmailAddresses = updateRequest.ContactModel.EmailAddresses.Select(x => new EmailAddress { Address = x }).ToList();
                dbContext.SaveChanges();
                return ConvertContactEntityToContactModel(contactToUpdate);
            }
        }

        private AddressBookEntityFramework.Models.Contact ConvertContactModelToEntity(ContactModel contactModel)
        {
            return new AddressBookEntityFramework.Models.Contact
            {
                FirstName = contactModel.FirstName,
                LastName = contactModel.LastName,
                ContactNumbers = contactModel.ContactNumbers.Select(x => new ContactNumber { Number = x }).ToList(),
                EmailAddresses = contactModel.EmailAddresses.Select(x => new EmailAddress { Address = x }).ToList()
            };

        }
        private Models.Contact ConvertContactEntityToContactModel(AddressBookEntityFramework.Models.Contact entity)
        {
            return new Models.Contact
            {
                ExternalId = entity.ExternalId,
                ContactModel = new ContactModel
                {
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    ContactNumbers = entity.ContactNumbers.Select(x => x.Number).ToList(),
                    EmailAddresses = entity.EmailAddresses.Select(x => x.Address).ToList()
                }
            };
        }

    }
}