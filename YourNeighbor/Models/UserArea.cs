using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourNeighbor.Models
{
    public class UserArea
    {
        public string UserId { get; set; }
        public User User { get; set; }

        public int AreaId { get; set; }
        public Area Area { get; set; }
    }
}
