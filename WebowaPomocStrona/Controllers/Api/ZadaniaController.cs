using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebowaPomocStrona.Models;

namespace WebowaPomocStrona.Controllers.Api
{
    public class ZadaniaController : ApiController
    {

        private ApplicationDbContext _context;

        public ZadaniaController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/zadania/iduż
        public IEnumerable<ZadaniaDoApi> GetZadania(string idUser)
        {
            string id = idUser;
            List<ZadaniaDoApi> zadaniaDoApi = new List<ZadaniaDoApi>();
            var zadania = _context.Zadania.Where(c => c.IdUzytkownika == idUser).ToList();
           
            foreach (var zad in zadania)
            {

                ZadaniaDoApi zadDoApi = new ZadaniaDoApi();
                var zajecia = _context.Zajecia.Where(c => c.Id == zad.ZajeciaId).Single();
                zadDoApi.CzyZrobione = zad.CzyZrobione;
                zadDoApi.DataDodania = zad.DataDodania;
                zadDoApi.IdUzytkownika = zad.IdUzytkownika;
                zadDoApi.Informacje = zad.Informacje;
                zadDoApi.NazwaZajec = zajecia.Nazwa;
                zadDoApi.Temat = zad.Temat;
                zadDoApi.Termin = zad.Termin;
                zadaniaDoApi.Add(zadDoApi);
            }
            return zadaniaDoApi;
        }
    }
}
