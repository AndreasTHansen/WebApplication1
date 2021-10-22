using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public class KundeRepository : IKundeRepository
    {
        private readonly BillettContekst _billettDb;

        private ILogger<KundeRepository> _log;

        public KundeRepository(BillettContekst billettDb, ILogger<KundeRepository> log)
        {
            _billettDb = billettDb;
            _log = log;

        }

        public async Task<bool> EndreKunde(Kunde endreKunde)
        {
            try
            {
                var endreObjekt = await _billettDb.Kunder.FindAsync(endreKunde.id);
                //Sjekke om kortet finnes fra før
                if (endreObjekt.kort.kortnummer != endreKunde.kortnummer)
                {
                    var kortRad = new Kort();
                    kortRad.kortnummer = endreKunde.kortnummer;
                    kortRad.cvc = endreKunde.cvc;
                    kortRad.utlopsdato = endreKunde.utlopsdato;
                    endreObjekt.kort = kortRad;
                }
                else
                {
                    endreObjekt.kort.kortnummer = endreKunde.kortnummer;
                }
                endreObjekt.fornavn = endreKunde.fornavn;
                endreObjekt.etternavn = endreKunde.etternavn;
                endreObjekt.epost = endreKunde.epost;
                endreObjekt.mobilnummer = endreKunde.mobilnummer;
            }
            catch (Exception e)
            {
                _log.LogInformation(e.Message);
                return false;
            }
            return true;
        }
    }
}
