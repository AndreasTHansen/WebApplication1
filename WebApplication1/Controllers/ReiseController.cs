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
    [Route("[controller]/[action]")]
    public class ReiseController : ControllerBase
    {
        private readonly ReiseDB _reiseDB;

        public ReiseController(ReiseDB reiseDb)
        {
            _reiseDB = reiseDb;
        }
        public async Task<List<Reise>> HentAlle()
        {
            try
            {
                List<Reise> alleReiser = await _reiseDB.Reiser.ToListAsync();
                return alleReiser;
            }
            catch
            {
                return null;
            }

        }
    }
}
