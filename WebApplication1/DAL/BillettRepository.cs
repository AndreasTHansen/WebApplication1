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
                    id = k.kunde.id,
                    antallBarn = k.antallBarn,
                    antallVoksne = k.antallVoksne,
                    totalPris = k.totalPris,
                    kundeId = k.kunde.id,
                    fornavn = k.kunde.fornavn,
                    etternavn = k.kunde.etternavn,
                    epost = k.kunde.epost,
                    mobilnummer = k.kunde.mobilnummer,
                    kortnummer = k.kunde.kort.kortnummer,
                    utlopsdato = k.kunde.kort.utlopsdato,
                    cvc = k.kunde.kort.cvc,
                    reiseId = k.reise.id,
                    reiseFra = k.reise.reiseFra,
                    reiseTil = k.reise.reiseTil,
                    datoAnkomst = k.reise.datoAnkomst,
                    datoAvreise = k.reise.datoAvreise,
                    tidspunktFra = k.reise.tidspunktFra,
                    tidspunktTil = k.reise.tidspunktTil,
                    reisePris = k.reise.reisePris
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
                nyBillett.antallBarn = innBillett.antallBarn;
                nyBillett.antallVoksne = innBillett.antallVoksne;
                nyBillett.totalPris = innBillett.totalPris;

                var nyKunde = new Kunder(); //Vi har ikke lagring av kunde derfor lages det en ny for hver billett i denne versjonen
                {
                    nyKunde.fornavn = innBillett.fornavn;
                    nyKunde.epost = innBillett.epost;
                    nyKunde.etternavn = innBillett.etternavn;
                    nyKunde.id = innBillett.kundeId;
                    nyKunde.mobilnummer = innBillett.mobilnummer;
                }

                var sjekkKort = _billettDb.Kort.Find(innBillett.kortnummer); //Sammme kortnummer kan skje og vi har ikke auto increment så her må det sjekkes
                if (sjekkKort==null)
                {
                    var nyttKort = new Kort();
                    nyttKort.kortnummer = innBillett.kortnummer;
                    nyttKort.utlopsdato = innBillett.utlopsdato;
                    nyttKort.cvc = innBillett.cvc;

                    nyKunde.kort = nyttKort; 
                }
                else
                {
                    nyKunde.kort = sjekkKort;
                }

                nyBillett.kunde = nyKunde;

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
                    nyReise.reisePris = innBillett.reisePris;

                    nyBillett.reise = nyReise;
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
                    id = enBillett.kunde.id,
                    fornavn = enBillett.kunde.fornavn,
                    etternavn = enBillett.kunde.etternavn,
                    epost = enBillett.kunde.epost,
                    mobilnummer = enBillett.kunde.mobilnummer,
                    totalPris = enBillett.totalPris,
                    antallBarn = enBillett.antallBarn,
                    antallVoksne = enBillett.antallVoksne,
                    reiseId = enBillett.reise.id,
                    reiseTil = enBillett.reise.reiseTil,
                    reiseFra = enBillett.reise.reiseFra,
                    datoAnkomst = enBillett.reise.datoAnkomst,
                    datoAvreise = enBillett.reise.datoAvreise,
                    tidspunktFra = enBillett.reise.tidspunktFra,
                    tidspunktTil = enBillett.reise.tidspunktTil,
                    reisePris = enBillett.reise.reisePris
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
                    datoAvreise = k.datoAvreise,
                    reisePris = k.reisePris
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
                    datoAvreise = enReise.datoAvreise,
                    reisePris = enReise.reisePris
                };

                return hentetReise;
            }
            catch
            {
                return null;
            }

        }
    }
}
