using System.ComponentModel.DataAnnotations.Schema;

namespace AddressBookEntityFramework.Models
{
    public class EmailAddress
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmailAddressId { get; set; }

        public virtual Contact Contact { get; set; }

        public string Address { get; set; }
    }
}
