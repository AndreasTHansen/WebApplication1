using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models

{

    public class Billetter
    {
        public int id { get; set; }
        public int antallVoksne { get; set; }
        public int antallBarn { get; set; }
        public double totalPris { get; set; }
        public virtual Kunder kunde { get; set; }
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
        public double reisePris { get; set; }
    }

    public class Kunder
    {
        public int id { get; set; }
        public string fornavn { get; set; }
        public string etternavn { get; set; }
        public string epost { get; set; }
        public string mobilnummer { get; set; }
        public string kortnummer { get; set; }
        public string utlopsdato { get; set; }
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
        public DbSet<Kunder> Kunder { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

    }
}
