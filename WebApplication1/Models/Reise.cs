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
        public string tidspunktFra { get; set; }
        public string tidspunktTil { get; set; }
    }
}
