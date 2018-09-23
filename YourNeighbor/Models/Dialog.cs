using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourNeighbor.Models
{
    public class Dialog
    {
        public string LastMessageText { get; set; }

        public DateTime LastMessageTime { get; set; }

        public string LastMessageUserToId { get; set; }

        public string LastMessageUserFromId { get; set; }
    }
}
