using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DAL;
using WebApplication1.Models;
using WebApplication1.Modules;

namespace WebApplication1.Controllers
{
    [Route("[controller]/[action]")]
    public class BillettController : ControllerBase
    {
        private readonly IBillettRepository _billettDb;
        public BillettController(IBillettRepository billettDb)
        {
            _billettDb = billettDb;
        }

        public async Task<List<Billett>> HentAlle() 
        {
            return await _billettDb.HentAlle();
        }
        public async Task<bool> Lagre(Billett innBillett)
        {
            return await _billettDb.Lagre(innBillett);
        }
        public async Task<bool> Slett(int id) 
        {
            return await _billettDb.Slett(id);
        }

        public async Task<List<Reise>> HentAlleReiser()
        {
            return await _billettDb.HentAlleReiser();
        }
     }
}
