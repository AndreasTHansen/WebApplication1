using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models

{

    public class Billetter
    {

        public int id { get; set; }
        public string fornavn { get; set; }
        public string etternavn { get; set; }
        public string epost { get; set; }  
        public string mobilnummer { get; set; }
        public int antallVoksne { get; set; }
        public int antallBarn { get; set; }
        public double pris { get; set; }
        public virtual Reiser reise { get; set; }
    }
    public class Reiser
    {
        public int id { get; set; }
        public string reiseTil { get; set; }
        public string reiseFra { get; set; }
        public string tidspunktFra { get; set; }

        public string datoAvreise { get; set; }
        public string datoAnkomst { get; set; }
        public string tidspunktTil { get; set; }
    }

    public class BillettContekst : DbContext
    {
        public BillettContekst(DbContextOptions<BillettContekst> options)
            : base(options)
        {
            Database.EnsureCreated();        
        }

        public DbSet<Billetter> Billetter { get; set; }
        public DbSet<Reiser> Reiser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

    }
}
