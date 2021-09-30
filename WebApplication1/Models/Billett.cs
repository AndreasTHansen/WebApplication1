using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Modules;

namespace WebApplication1.Models
{
    public class Billett
    {
        public int id { get; set; }
        public string fornavn { get; set; }
        public string etternavn { get; set; }
        public string epost { get; set; }

        public int reiseId { get; set; }
        public string reiseTil { get; set; }
        public string reiseFra { get; set; }
        public string tidspunktFra { get; set; }
        public string tidspunktTil { get; set; }

    }
}
