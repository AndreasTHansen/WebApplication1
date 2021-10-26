﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DAL;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class KundeController : ControllerBase
    {
        private readonly IKundeRepository _billettDb;

        private ILogger<KundeController> _log;

        private const string _loggetInn = "loggetInn";

        public KundeController(IKundeRepository billettDb, ILogger<KundeController> log)
        {
            _billettDb = billettDb;
            _log = log;
        }

        public async Task<ActionResult> EndreKunde(Kunde endreKunde)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(_loggetInn)))
            {
                return Unauthorized("Ikke logget inn");
            }
            if (ModelState.IsValid)
            {
                bool endreOK = await _billettDb.EndreKunde(endreKunde);
                if (!endreOK)
                {
                    _log.LogInformation("Det skjedde noe feil under endringen");
                    return NotFound("Kunden kunne ikke endres");
                }
                return Ok("Kunden ble endret");
            }
            _log.LogInformation("Feil i inputvalidering");
            return BadRequest("Feil i inputvalidering på server");
        }

        public async Task<ActionResult> LagreKunde(Kunde innKunde)
        {
            bool lagreOK = await _billettDb.LagreKunde(innKunde);
            if (!lagreOK)
            {
                _log.LogInformation("Det skjedde noe feil under lagringen");
                return BadRequest("Billetten kunne ikke lagres");
            }
            return Ok("Billetten ble lagret");
        }
        public async Task<ActionResult> SlettKunde(int id)
        {
            bool slettOk = await _billettDb.SlettKunde(id);
            if (!slettOk)
            {
                _log.LogInformation("Kunden ble ikke slettet");
                return NotFound("Kundenen ble ikke slettet");
            }
            return Ok("Kunde slettet");
        }
    }
}
