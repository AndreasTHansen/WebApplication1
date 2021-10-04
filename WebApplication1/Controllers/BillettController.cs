using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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

        private ILogger<BillettController> _log;
        public BillettController(IBillettRepository billettDb, ILogger<BillettController> log)
        {
            _billettDb = billettDb;
            _log = log;
        }

        public async Task<ActionResult> HentAlle()
        {
            List<Billett> billettListe = await _billettDb.HentAlle();
            return Ok(billettListe);
        }
        public async Task<ActionResult> Lagre(Billett innBillett)
        {
            if (ModelState.IsValid)
            {
                bool returOK = await _billettDb.Lagre(innBillett);
                if (!returOK)
                {
                    _log.LogInformation("Billetten ble ikke lagret");
                    return BadRequest("Billetten ble ikke lagret");
                }
                return Ok("Billett lagret");
            }
            _log.LogInformation("Feil i inputvalidering");
            return BadRequest("Feil i inputvalidering");
        }
        public async Task<ActionResult> Slett(int id)
        {
            bool slettOk = await _billettDb.Slett(id);
            if (!slettOk)
            {
                _log.LogInformation("Billetten ble ikke slettet");
                return NotFound("Billetten ble ikke slettet");
            }
            return Ok("Billett slettet");
        }

        public async Task<ActionResult> HentAlleReiser()
        {
            List<Reise> reiseListe = await _billettDb.HentAlleReiser();
            _log.LogInformation("Test");
            return Ok(reiseListe);
        }
    }
}
