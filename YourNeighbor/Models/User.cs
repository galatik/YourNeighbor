using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace YourNeighbor.Models
{
    public class User : IdentityUser
    {
        [MaxLength(36)]
        public override string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public SocialStatus SocialStatus { get; set; }

        public DateTime Birthday { get; set; }

        [MaxLength(425)]
        public string AboutMe { get; set; }

        public int MinCountOfRooms { get; set; }

        public int MaxCountOfRooms { get; set; }

        public bool Smoking { get; set; }

        public bool HasPets { get; set; }

        public ICollection<UserArea> UserAreas { get; set; }

        public int StartCost { get; set; }

        public int MaxCost { get; set; }

        public ICollection<Message> MyMessages { get; set; }

        public ICollection<Message> MessagesToMe { get; set; }

        public ICollection<UserInterest> Interests { get; set; }
    }
}
