﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meditatori.Models
{
    public class Location
    {
        public int Id { get; set; }

        public string name { get; set; }

        public ICollection<Ad> Ads { get; set; }
    }
}
