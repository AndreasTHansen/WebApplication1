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
    public class BilettController : ControllerBase
    {
        private readonly BilettDB _bilettDb;

        public BilettController(BilettDB bilettDb)
        {
            _bilettDb = bilettDb;
        }
        public async Task<List<Bilett>> HentAlle()
        {
            try
            {
                List<Bilett> alleBiletter = await _bilettDb.Biletter.ToListAsync();
                return alleBiletter;
            }
            catch
            {
                return null;
            }

        }

    }
}
