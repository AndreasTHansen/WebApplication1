using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Modules;

namespace WebApplication1.DAL
{
    public interface IBillettRepository
    {
        Task<List<Billett>> HentAlle();
        Task<bool> Lagre(Billett innBillett);
        Task<bool> Slett(int id);
        Task<List<Reise>> HentAlleReiser();
        Task<Reise> HentEnReise(int id);
    }
}
