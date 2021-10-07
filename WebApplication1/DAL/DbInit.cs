﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class DbInit
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<BillettContekst>();

                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var reise1 = new Reiser { reiseFra = "Oslo", reiseTil = "Kiel", tidspunktFra = "19:00", tidspunktTil = "14:00", datoAnkomst = "10/01/2021", datoAvreise = "09/01/2021", reisePris = 3000.0};
                var reise2 = new Reiser { reiseFra = "Oslo", reiseTil = "Kiel", tidspunktFra = "20:00", tidspunktTil = "13:00", datoAvreise = "21/01/2021", datoAnkomst = "22/01/2021", reisePris = 3000.0};
                var reise3 = new Reiser { reiseFra = "Oslo", reiseTil = "København", tidspunktFra = "12:00", tidspunktTil = "09:00", datoAvreise = "12/12/2022", datoAnkomst = "13/12/2022" , reisePris = 1000.0};
                var reise4 = new Reiser { reiseFra = "Oslo", reiseTil = "København", tidspunktFra = "12:00", tidspunktTil = "09:00", datoAvreise = "14/12/2022", datoAnkomst = "15/12/2022", reisePris = 1000.0};
                var reise5 = new Reiser { reiseFra = "Oslo", reiseTil = "København", tidspunktFra = "12:00", tidspunktTil = "09:00", datoAvreise = "16/12/2022", datoAnkomst = "17/12/2022", reisePris = 1000.0};
                var reise6 = new Reiser { reiseFra = "Kiel", reiseTil = "Oslo", tidspunktFra = "19:00", tidspunktTil = "14:00", datoAnkomst = "10/01/2021", datoAvreise = "09/01/2021", reisePris = 1000.0};
                var reise7 = new Reiser { reiseFra = "Kiel", reiseTil = "Oslo", tidspunktFra = "20:00", tidspunktTil = "13:00", datoAvreise = "21/01/2021", datoAnkomst = "22/01/2021", reisePris = 1000.0};

                var kort1 = new Kort { kortnummer = "4567890", cvc = 123, utlopsdato = "03/04/2022" };
                var kunde1 = new Kunder { fornavn = "Anders", etternavn = "Ottersland", mobilnummer = "41251290", epost = "anderh@gmail.com", kort=kort1};
                var billett1 = new Billetter { antallBarn = 0, antallVoksne = 1, reise = reise5, totalPris = 1000, kunde = kunde1 };


                context.Reiser.Add(reise1);
                context.Reiser.Add(reise2);
                context.Reiser.Add(reise3);
                context.Reiser.Add(reise4);
                context.Reiser.Add(reise5);
                context.Reiser.Add(reise6);
                context.Reiser.Add(reise7);
                

                context.SaveChanges();
            }
        }

    }
}
