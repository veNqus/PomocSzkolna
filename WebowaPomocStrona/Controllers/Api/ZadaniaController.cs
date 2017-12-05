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
                zadDoApi.Id = zad.Id;
                zadDoApi.CzyZrobione = zad.CzyZrobione;
                zadDoApi.DataDodania = zad.DataDodania;
                zadDoApi.IdUzytkownika = zad.IdUzytkownika;
                zadDoApi.Informacje = zad.Informacje;
                zadDoApi.NazwaZajec = zajecia.Nazwa;
                zadDoApi.Temat = zad.Temat;
                zadDoApi.Termin = zad.Termin;
                zadaniaDoApi.Add(zadDoApi);
            }
            List<ZadaniaDoApi> PosortowanieZadaniaDoApi = zadaniaDoApi.OrderBy(o => o.Termin).ToList();
            return PosortowanieZadaniaDoApi;
        }

        //POST
        [HttpPost]
        public string DodajZadanie(ZadaniaZApi zadanie)
        {
            try
            {
                var ZadanieDoDb = new Zadanie();
                ZadanieDoDb.Temat = zadanie.Temat;
                ZadanieDoDb.Informacje = zadanie.Szczególy;
                DateTime TerminFromString = DateTime.Parse(zadanie.Termin);
                ZadanieDoDb.Termin = TerminFromString;
                ZadanieDoDb.ZajeciaId = zadanie.IdPrzedmiotu;
                ZadanieDoDb.IdUzytkownika = zadanie.IdUzytkownika;
                ZadanieDoDb.DataDodania = DateTime.Now;
                ZadanieDoDb.CzyZrobione = zadanie.CzyZrobione;
                _context.Zadania.Add(ZadanieDoDb);
                _context.SaveChanges();
                return "OK";
            }
            catch(Exception e)
            {
                return "Error: " + e.ToString();
            }
            
        }

        [HttpPut]
        public string EdytujZajecia(int id, ZadaniaZApi zadanie)
        {
            var ZadanieInDb = _context.Zadania.Where(z => z.Id == id).SingleOrDefault();
            if (ZadanieInDb == null)
                return "ERROR01";
            else
            {
                if (zadanie.CzyZrobione == true)
                {
                    ZadanieInDb.CzyZrobione = true;
                    _context.SaveChanges();
                }
                else
                {
                    ZadanieInDb.Temat = zadanie.Temat;
                    ZadanieInDb.Informacje = zadanie.Szczególy;
                    ZadanieInDb.ZajeciaId = zadanie.IdPrzedmiotu;
                    DateTime TerminFromString = DateTime.Parse(zadanie.Termin);
                    ZadanieInDb.Termin = TerminFromString;
                    _context.SaveChanges();
                }
                return "OK";
            }
        }
    }
}
