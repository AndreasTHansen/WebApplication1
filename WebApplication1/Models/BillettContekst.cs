﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Modules;

namespace WebApplication1.Models

{

    public class Billetter
    {

        public int id { get; set; }
        public string fornavn { get; set; }
        public string etternavn { get; set; }
        public string epost { get; set; }
        public virtual Reise reiseId { get; set; }
    }
    public class Reiser
    {
        public int id { get; set; }
        public string reiseTil { get; set; }
        public string reiseFra { get; set; }
        public string tidspunktFra { get; set; }
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