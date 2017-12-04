using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebowaPomocStrona.Models;

namespace WebowaPomocStrona.Controllers.Api
{
    public class ZajeciaController : ApiController
    {
        private ApplicationDbContext _context;

        public ZajeciaController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Zajecia> GetZajecia(string idUser)
        {
            string id = idUser;
            var zajecia = _context.Zajecia.Where(c => c.IdUzytkownika == idUser).ToList();
            return zajecia;
        }
    }

}


