using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Modules;

namespace WebApplication1.DAL
{



    public class BillettRepository : IBillettRepository
    {

        private readonly BillettContekst _billettDb;

        public BillettRepository(BillettContekst billettDb)
        { 
        _billettDb = billettDb;
        }
        public async Task<List<Billett>> HentAlle()
        {
            try
            {
                List<Billett> alleBilletter = await _billettDb.Billetter.Select(k => new Billett
                {
                    id = k.id,
                    fornavn = k.fornavn,
                    etternavn = k.etternavn,
                    epost = k.epost,
                    mobilnummer = k.mobilnummer,
                    billettType = k.billettType,
                    antallReisende = k.antallReisende,
                    pris = k.pris,
                    reiseId = k.reise.id,
                    reiseFra = k.reise.reiseFra,
                    reiseTil = k.reise.reiseTil,
                    datoAnkomst = k.reise.datoAnkomst,
                    datoAvreise = k.reise.datoAvreise,
                    tidspunktFra = k.reise.tidspunktFra,
                    tidspunktTil = k.reise.tidspunktTil
                }).ToListAsync();

                return alleBilletter;
            }
            catch
            {
                return null;
            }

        }

        public async Task<bool> Lagre(Billett innBillett)
        {                    
            try
            {
                var nyBillett = new Billetter();
                nyBillett.fornavn = innBillett.fornavn;
                nyBillett.etternavn = innBillett.etternavn;
                nyBillett.epost = innBillett.epost;
                nyBillett.mobilnummer = innBillett.mobilnummer;
                nyBillett.billettType = innBillett.billettType;
                nyBillett.antallReisende = innBillett.antallReisende;
                nyBillett.pris = innBillett.pris;

                var sjekkReise = _billettDb.Reiser.Find(innBillett.reiseId);
                if (sjekkReise == null)
                {

                    var nyReise = new Reiser();
                    nyReise.id = innBillett.reiseId;
                    nyReise.reiseFra = innBillett.reiseFra;
                    nyReise.reiseTil = innBillett.reiseTil;
                    nyReise.datoAvreise = innBillett.datoAvreise;
                    nyReise.datoAnkomst = innBillett.datoAnkomst;
                    nyReise.tidspunktFra = innBillett.reiseTil;
                    nyReise.tidspunktTil = innBillett.reiseTil;
                }
                else
                {
                    nyBillett.reise = sjekkReise;
                }

                _billettDb.Add(nyBillett);
                await _billettDb.SaveChangesAsync();
                return true;
            }

            catch
            {
                return false;
            }
        }
        public async Task<bool> Slett(int id)
        {
            try
            {
                Billetter enBillet = await _billettDb.Billetter.FindAsync(id);
                _billettDb.Remove(enBillet);
                await _billettDb.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        } 

        public async Task<Billett> HentEnBillett(int id)
        {
            try
            {
                Billetter enBillett = await _billettDb.Billetter.FindAsync(id);
                var hentetBillett = new Billett()
                {
                    id = enBillett.id,
                    fornavn = enBillett.fornavn,
                    etternavn = enBillett.etternavn,
                    epost = enBillett.epost,
                    mobilnummer = enBillett.mobilnummer,
                    pris = enBillett.pris,
                    antallReisende = enBillett.antallReisende,
                    billettType = enBillett.billettType,
                    reiseId = enBillett.reise.id,
                    reiseTil = enBillett.reise.reiseTil,
                    reiseFra = enBillett.reise.reiseFra,
                    datoAnkomst = enBillett.reise.datoAnkomst,
                    datoAvreise = enBillett.reise.datoAvreise,
                    tidspunktFra = enBillett.reise.tidspunktFra,
                    tidspunktTil = enBillett.reise.tidspunktTil
                };
                return hentetBillett;
            }
            catch
            {
                return null;
            }

        }
        public async Task<List<Reise>> HentAlleReiser() 
        {
            try
            {
                List<Reise> alleReiser = await _billettDb.Reiser.Select(k => new Reise
                {
                    id = k.id,
                    reiseFra = k.reiseFra,
                    reiseTil = k.reiseTil,
                    tidspunktFra = k.tidspunktFra,
                    tidspunktTil = k.tidspunktTil,
                    datoAnkomst = k.datoAnkomst,
                    datoAvreise = k.datoAvreise
                }).ToListAsync();

                return alleReiser;
            }
            catch
            {
                return null;
            }
        }

        public async Task<Reise> HentEnReise(int id)
        {
            try
            {
                Reiser enReise = await _billettDb.Reiser.FindAsync(id);
                var hentetReise = new Reise()
                {
                    id = enReise.id,
                    reiseFra = enReise.reiseFra,
                    reiseTil = enReise.reiseTil,
                    tidspunktFra = enReise.tidspunktFra,
                    tidspunktTil = enReise.tidspunktTil,
                    datoAnkomst = enReise.datoAnkomst,
                    datoAvreise = enReise.datoAvreise
                };

                return hentetReise;
            }
            catch
            {
                return null;
            }

        }

        public Task<Billett> HentEn()
        {
            throw new NotImplementedException();
        }
        //Vet ikke om vi trenger en endre eller hent en, men kan legge det til hvis det er nødvendig
    }
}
