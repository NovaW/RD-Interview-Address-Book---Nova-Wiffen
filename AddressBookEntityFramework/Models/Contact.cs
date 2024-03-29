﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddressBookEntityFramework.Models
{
    public class Contact {
        public Contact(){
            ExternalId = Guid.NewGuid();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContactId { get; set; }

        public Guid ExternalId { get; set; } 
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<ContactNumber> ContactNumbers { get; set; }

        public virtual ICollection<EmailAddress> EmailAddresses { get; set; }
    }
}
