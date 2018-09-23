using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace YourNeighbor.Models.Account
{
    public class RegisterModel
    {
        [Required]
        [MinLength(7)]
        [MaxLength(20)]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }


        public DateTime Birthday { get; set; }

        public Gender Gender { get; set; }

        [Required]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

    }
}
