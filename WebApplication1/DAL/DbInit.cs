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

                var reise1 = new Reiser { reiseFra = "Oslo", reiseTil = "Kiel", tidspunktFra = "19:00", tidspunktTil = "14:00", datoAnkomst = "10/01/2021", datoAvreise = "09/01/2021" };
                var reise2 = new Reiser { reiseFra = "Oslo", reiseTil = "Kiel", tidspunktFra = "20:00", tidspunktTil = "13:00", datoAvreise = "21/01/2021", datoAnkomst = "22/01/2021" };
                var reise3 = new Reiser { reiseFra = "Oslo", reiseTil = "København", tidspunktFra = "12:00", tidspunktTil = "09:00", datoAvreise = "12/12/2022", datoAnkomst = "13/12/2022" };
                var reise4 = new Reiser { reiseFra = "Oslo", reiseTil = "København", tidspunktFra = "12:00", tidspunktTil = "09:00", datoAvreise = "14/12/2022", datoAnkomst = "15/12/2022" };
                var reise5 = new Reiser { reiseFra = "Oslo", reiseTil = "København", tidspunktFra = "12:00", tidspunktTil = "09:00", datoAvreise = "16/12/2022", datoAnkomst = "17/12/2022" };

                var billett1 = new Billetter { fornavn = "Anders", etternavn = "Hagen", mobilnummer = "12345678", billettType = "voksen", epost = "anders@gmail.com", pris = 1499.99, reise = reise1 };
                var billett2 = new Billetter { fornavn = "Andreas", etternavn = "Hansen", mobilnummer = "987654321", billettType = "voksen", epost = "andreas@gmail.com", pris = 1499.99, reise = reise5 };
                var billett3 = new Billetter { fornavn = "Andreas", etternavn = "Hansen", billettType = "voksen", mobilnummer = "12345678", epost = "andreas@gmail.com", pris = 1499.99, reise = reise3 };


                context.Reiser.Add(reise2);
                context.Reiser.Add(reise3);
                context.Reiser.Add(reise4);
                context.Billetter.Add(billett1);
                context.Billetter.Add(billett2);
                context.Billetter.Add(billett3);
                

                context.SaveChanges();
            }
        }

    }
}
