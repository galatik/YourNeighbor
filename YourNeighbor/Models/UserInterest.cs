﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourNeighbor.Models
{
    public class UserInterest
    {
        public string UserId { get; set; }
        public User User { get; set; }


        public string Interest { get; set; }
    }
}
