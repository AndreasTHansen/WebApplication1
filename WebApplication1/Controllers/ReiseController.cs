using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public List<Reise> HentAlle()
        {
            try
            {
                List<Reise> alleReiser = _reiseDB.Reiser.ToList();
                return alleReiser;
            }
            catch
            {
                return null;
            }

        }
    }
}
