using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    [ExcludeFromCodeCoverage]
    public class Kunde
    {
        public int id { get; set; }
        public string fornavn { get; set; }
        public string etternavn { get; set; }
        public string epost { get; set; }
        public string mobilnummer { get; set; }
        public string kortnummer { get; set; }
        public string utlopsdato { get; set; }
        public int cvc { get; set; }
    }
}
