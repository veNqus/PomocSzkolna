using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using WebowaPomocStrona.Models;

namespace WebowaPomocStrona.Controllers
{
    public class ZadaniaController : Controller
    {
        private ApplicationDbContext _context;

        public ZadaniaController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ActionResult Index()
        {
            var zadania = _context.Zadania.Include(c => c.Zajecia).ToList();
            return View(zadania);
        }
    }
}