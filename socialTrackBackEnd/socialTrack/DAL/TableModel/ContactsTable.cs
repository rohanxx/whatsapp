using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace socialTrack.DAL.TableModel
{
    public class ContactsTable:BasicEntity
    {
        [Key]
        public int ContactId { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

    }
}
