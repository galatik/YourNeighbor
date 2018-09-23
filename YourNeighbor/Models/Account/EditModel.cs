  using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace YourNeighbor.Models.Account
{
    public class EditModel
    {

        [MinLength(7)]
        public string Login { get; set; }

        [MaxLength(20)]
        public string FirstName { get; set; }

        [MaxLength(30)]
        public string LastName { get; set; }

       
        public SocialStatus? SocialStatus { get; set; }

        public DateTime Bithday { get; set; }

        [MaxLength(425)]
        public string AboutMe { get; set; }

        public int? MinCountOfRooms { get; set; }

        public int? MaxCountOfRooms { get; set; }

        public bool? Smoking { get; set; }

        public bool? HasPets { get; set; }

        public int? StartCost { get; set; }

        public int? MaxCost { get; set; }

        public Interest[] Interests { get; set; }

        public Area[] Areas { get; set; }
    }
}
