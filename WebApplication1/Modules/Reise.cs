using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Modules
{
    public class Reise
    {
        public int id { get; set; }
        public string reiseTil { get; set; }
        public string reiseFra{ get; set; }
        public DateTime tidspunktFra { get; set; }
        public DateTime tidspunktTil { get; set; }
    }
}
