using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ReiseDB : DbContext
    {
        public class ReiseDB : DbContext
        {
            public ReiseDB(DbContextOptions<ReiseDB> options) : base(options)
            {
                Database.EnsureCreated();
            }

            public DbSet<Reise> Reiser { get; set; }
        }
    }
}
