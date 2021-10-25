using Microsoft.AspNetCore.Http;
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

        private const string _loggetInn = "loggetInn";
        private const string _ikkeLoggetInn = "";

        public BillettController(IBillettRepository billettDb, ILogger<BillettController> log)
        {
            _billettDb = billettDb;
            _log = log;
        }

        public async Task<ActionResult> HentAlle()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(_loggetInn)))
            {
                return Unauthorized("Ikke logget inn");
            }
            List<Billett> alleBilletter = await _billettDb.HentAlle();
            return Ok(alleBilletter);
        }

        public async Task<ActionResult> Lagre(Billett innBillett)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(_loggetInn)))
            {
                return Unauthorized("Ikke logget inn");
            }
            if (ModelState.IsValid)
            {
                bool returOK = await _billettDb.Lagre(innBillett);
                if (!returOK)
                {
                    _log.LogInformation("Billetten kunne ikke lagres!");
                    return BadRequest("Billetten kunne ikke lagres");
                }
                return Ok("Billett lagret");
            }
            _log.LogInformation("Feil i inputvalidering");
            return BadRequest("Feil i inputvalidering på server");
        }

        public async Task<ActionResult> Slett(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(_loggetInn)))
            {
                return Unauthorized("Ikke logget inn");
            }
            bool returOK = await _billettDb.Slett(id);
            if (!returOK)
            {
                _log.LogInformation("Billetten ble ikke slettet");
                return NotFound("Billetten ble ikke slettet");
            }
            return Ok("Billett slettet");
        }

        public async Task<ActionResult> EndreBillett(Billett endreBillett)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(_loggetInn)))
            {
                return Unauthorized("Ikke logget inn");
            }
            if (ModelState.IsValid)
            {
                bool endreOk = await _billettDb.EndreBillett(endreBillett);
                if (!endreOk)
                {
                    _log.LogInformation("Billetten kunne ikke bli endret");
                    return NotFound("Billetten ble ikke endret");
                }
                return Ok("Billetten ble endret");
            }
            _log.LogInformation("Feil i inputvalidering");
            return BadRequest("Feil i inputvalidering på server");
        }

        public async Task<ActionResult> HentAlleReiser()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(_loggetInn)))
            {
                return Unauthorized("Ikke logget inn");
            }
            List<Reise> reiseListe = await _billettDb.HentAlleReiser();
            _log.LogInformation("Test");
            return Ok(reiseListe);
        }

        public async Task<ActionResult> HentEnReise(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(_loggetInn)))
            {
                return Unauthorized("Ikke logget inn");
            }
            Reise hentetReise = await _billettDb.HentEnReise(id);
            
            if(hentetReise == null)
            {
                _log.LogInformation("Fant ikke reisen i databasen");
                return NotFound("Fant ikke reisen i databasen");
            }
            return Ok(hentetReise);
        }

        public async Task<ActionResult> LagreReise(Reise innReise)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(_loggetInn)))
            {
                return Unauthorized("Ikke logget inn");
            }
            bool lagreOk = await _billettDb.LagreReise(innReise);
            if (!lagreOk)
            {
                _log.LogInformation("Reisen kunne ikke lagres!");
                return BadRequest("Reisen kunne ikke lagres");
            }
            return Ok("Reise lagret");
        }

        //EndreReise
        public async Task<ActionResult> EndreReise(Reise endreReise)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(_loggetInn)))
            {
                return Unauthorized("Ikke logget inn");
            }
            if (ModelState.IsValid)
            {
                bool endreOk = await _billettDb.EndreReise(endreReise);
                if (!endreOk)
                {
                    _log.LogInformation("Reisen kunne ikke bli endret");
                    return NotFound("Reisen ble ikke endret");
                }
                return Ok("Reisen ble endret");
            }
            _log.LogInformation("Feil i inputvalidering");
            return BadRequest("Feil i inputvalidering på server");
        }

        //SlettReise
        public async Task<ActionResult> SlettReise(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(_loggetInn)))
            {
                return Unauthorized("Ikke logget inn");
            }
            bool returOK = await _billettDb.SlettReise(id);
            if (!returOK)
            {
                _log.LogInformation("Reisen ble ikke slettet");
                return NotFound("Reisen ble ikke slettet");
            }
            return Ok("Reisen slettet");
        }

        //Hentet fra fagstoff
        public async Task<ActionResult> LoggInn(Bruker bruker)
        {
            if (ModelState.IsValid)
            {
                bool returnOK = await _billettDb.LoggInn(bruker);
                if (!returnOK)
                {
                    _log.LogInformation("Innloggingen feilet for bruker");
                    HttpContext.Session.SetString(_loggetInn, _ikkeLoggetInn);
                    return Ok(false);
                }
                HttpContext.Session.SetString(_loggetInn, _loggetInn);
                return Ok(true);
            }
            _log.LogInformation("Feil i inputvalidering");
            return BadRequest("Feil i inputvalidering på server");
        }
    }
}
