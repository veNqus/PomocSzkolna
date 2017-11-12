using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using WebowaPomocStrona.Models;
using WebowaPomocStrona.ViewModels;
using Microsoft.AspNet.Identity;

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
            var userID = User.Identity.GetUserId();
            //var zadania = _context.Zadania.Include(c => c.Zajecia).ToList();
            var zadania = _context.Zadania.Include(c => c.Zajecia).Where(c => c.IdUzytkownika == userID).ToList();
            return View(zadania);
        }

        public ActionResult New()
        {
            var userID = User.Identity.GetUserId();
            var zajecia = _context.Zajecia.Where(c=>c.IdUzytkownika == userID).ToList();
            var zadaniaViewModel = new NewMovieViewModel
            {
                zajecia = zajecia
            };
            return View("ZadaniaForm", zadaniaViewModel);
        }

        public ActionResult Save(Zadanie zadanie)
        {
            var userID = User.Identity.GetUserId();
            zadanie.DataDodania = DateTime.Now;
            zadanie.CzyZrobione = false;
            zadanie.IdUzytkownika = userID;
            if (zadanie.Id == 0)
                _context.Zadania.Add(zadanie);

            _context.SaveChanges();

            return RedirectToAction("Index", "Zadania");
        }
    }
}