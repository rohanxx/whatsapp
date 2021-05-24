using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace socialTrack.Model.AccountsModel
{
    public class AddUserModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string EmailId { get; set; }
        [Required]
        public string Contact { get; set; }

        public string UserRole { get; set; }

        public string UserPassword { get; set; }
    }
}
