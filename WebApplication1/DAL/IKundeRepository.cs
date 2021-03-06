using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public interface IKundeRepository
    {
        Task<List<Kunde>> HentAlleKunder();
        Task<bool> EndreKunde(Kunde endreKunde);
        Task<bool> SlettKunde(int id);
        Task<bool> LagreKunde(Kunde innKunde);
    }
}
