using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Modules
{
    [ExcludeFromCodeCoverage]
    public class Reise
    {
        public int id { get; set; }
        public string reiseTil { get; set; }
        public string reiseFra{ get; set; }
        public string tidspunktFra { get; set; }
        public string tidspunktTil { get; set; }
        public string datoAvreise { get; set; }
        public string datoAnkomst { get; set; }
        public double reisePris { get; set; }
    }
}
