﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace YourNeighbor.Models
{
    public class Interest
    {
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
