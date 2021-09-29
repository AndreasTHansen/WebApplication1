using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Modules;

namespace WebApplication1.Controllers
{
    public class BillettController : ControllerBase
    {
        private readonly BillettDB _bilettDb;

        public BillettController(BillettDB bilettDb)
        {
            _bilettDb = bilettDb;
        }
        public async Task<List<Billett>> HentAlle()
        {
            try
            {
                List<Billett> alleBiletter = await _bilettDb.Biletter.ToListAsync();
                return alleBiletter;
            }
            catch
            {
                return null;
            }

        }

    }
}
