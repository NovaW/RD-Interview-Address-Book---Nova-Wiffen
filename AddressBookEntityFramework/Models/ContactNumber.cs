using System.ComponentModel.DataAnnotations.Schema;

namespace AddressBookEntityFramework.Models
{
    public class ContactNumber
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContactNumberId { get; set; }

        public virtual Contact Contact { get; set; }

        public string Number { get; set; }
    }
}
