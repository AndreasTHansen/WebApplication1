using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Modules;

namespace WebApplication1.Models
{
    public class Billett
    {
        public int id { get; set; }
       
        public int kundeId { get; set; }
        [RegularExpression(@"^[a-zA-ZæøåÆØÅ. \-]{2,20}$")]
        public string fornavn { get; set; }
        [RegularExpression(@"^[a-zA-ZæøåÆØÅ. \-]{2,50}$")]
        public string etternavn { get; set; }
        [RegularExpression(@"^[0-9a-zA-ZæøåÆØÅ. \-@]{2,20}$")]
        public string epost { get; set; }
        [RegularExpression(@"^[0-9+]{2,20}$")]
        public string mobilnummer { get; set; }
        //[RegularExpression(@"^[0-9+]{2,30}$")]
        public string kortnummer { get; set; }
        //[RegularExpression(@"^[0-9/]{2,30}$")]
        public string utlopsdato { get; set; }
        //[RegularExpression(@"^[0-9]{3}$")]
        public int cvc { get; set; }
        public int antallVoksne { get; set; }
        public int antallBarn { get; set; }
        public double totalPris { get; set; }
        public int reiseId { get; set; }
        [RegularExpression(@"^[a-zA-Z. \-]{2,20}$")]
        public string reiseTil { get; set; }
        [RegularExpression(@"^[a-zA-ZæøåÆØÅ. \-]{2,20}$")]
        public string reiseFra { get; set; }
        [RegularExpression(@"^[0-9./\:]{2,20}$")]
        public string datoAvreise { get; set; }
        [RegularExpression(@"^[0-9./\:]{2,20}$")]
        public string datoAnkomst { get; set; }
        [RegularExpression(@"^[0-9./\:]{2,20}$")]
        public string tidspunktFra { get; set; }
        [RegularExpression(@"^[0-9./\:]{2,20}$")]
        public string tidspunktTil { get; set; }
        public double reisePris { get; set; }
    }
}
