using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class BillettDB : DbContext
    {

        public BillettDB(DbContextOptions<BillettDB> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Billett> Biletter { get; set; }
    }
}
