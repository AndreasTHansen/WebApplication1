using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class BilettDB: DbContext
    {
        public BilettDB (DbContextOptions<BilettDB> options) : base(options)
        {

        }
    }
}
