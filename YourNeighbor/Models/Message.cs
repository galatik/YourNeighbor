using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourNeighbor.Models
{
    public class Message
    {
        public int Id { get; set; }

        public string FromUserId { get; set; }
        public User FromUser { get; set; }

        public string ToUserId { get; set; }
        public User ToUser { get; set; }

        public string Text { get; set; }

        public DateTime Time { get; set; }
    }
}
