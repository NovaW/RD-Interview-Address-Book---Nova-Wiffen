namespace AddressBookEntityFramework.Migrations
{
    using AddressBookEntityFramework.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ContactsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ContactsContext dbContext)
        {
            var contacts = new List<Contact>
            {
                new Contact{
                    FirstName = "FirstName1",
                    LastName = "LastName1",
                    ContactNumbers = new List<ContactNumber>
                    {
                        new ContactNumber { Number = "1123581321" }
                    },
                    EmailAddresses = new List<EmailAddress>
                    {
                        new EmailAddress {Address = "email@address.com"}
                    }
                },
                new Contact{
                    FirstName = "FirstName2",
                    LastName = "LastName2",
                    ContactNumbers = new List<ContactNumber>
                    {
                        new ContactNumber { Number = "1234567890" }
                    },
                    EmailAddresses = new List<EmailAddress>
                    {
                        new EmailAddress {Address = "email1@address1.com"},
                        new EmailAddress {Address = "email2@address2.com"}
                    }
                },
                new Contact{
                    FirstName = "FirstName3",
                    LastName = "LastName3",
                    ContactNumbers = new List<ContactNumber>
                    {
                        new ContactNumber { Number = "0987654321" },
                        new ContactNumber { Number = "9876543210" }
                    },
                    EmailAddresses = new List<EmailAddress>
                    {
                        new EmailAddress {Address = "email3@address3.com"}
                    }
                },
            };

            contacts.ForEach(c => dbContext.Contacts.AddOrUpdate(c));

            dbContext.SaveChanges();
        }
    }
}
