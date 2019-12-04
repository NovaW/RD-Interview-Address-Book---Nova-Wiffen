using AddressBookEntityFramework.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AddressBookEntityFramework
{
    public class ContactsContext : DbContext
    {
        public ContactsContext() : base("ContactsContext") { }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactNumber> ContactNumbers { get; set; }
        public DbSet<EmailAddress> EmailAddresses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
