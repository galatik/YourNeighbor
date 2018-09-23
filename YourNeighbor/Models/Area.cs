using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourNeighbor.Models
{
    public class Area
    {
        public int Id { get; set; }

        public string AreaName { get; set; }

        public City City { get; set; }

        public int CityId { get; set; }
    }
}
