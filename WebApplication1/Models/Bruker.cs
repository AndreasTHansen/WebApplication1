﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Bruker
    {
        public int Id { get; set; }
        public string Brukernavn { get; set; }
        public string Passord { get; set; }
        public byte[] Salt { get; set; }
    }
}
