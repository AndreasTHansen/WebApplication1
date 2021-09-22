using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Modules
{
    public class Reise
    {
        public int id { get; set; }
        public string destinasjon { get; set; }
        public string start { get; set; }
        public DateTime tidspunkt { get; set; }
    }
}
