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
            return View(zadania.OrderByDescending(c => c.Termin));
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
            if (zadanie.Id == 0)
            {
                zadanie.DataDodania = DateTime.Now;
                zadanie.CzyZrobione = false;
                zadanie.IdUzytkownika = userID;
                _context.Zadania.Add(zadanie);
            }
            else
            {
                var ZadanieInDb = _context.Zadania.Single(c => c.Id == zadanie.Id);

                ZadanieInDb.Temat = zadanie.Temat;
                ZadanieInDb.Termin = zadanie.Termin;
                ZadanieInDb.ZajeciaId = zadanie.ZajeciaId;
                ZadanieInDb.Informacje = zadanie.Informacje;

            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Zadania");
        }

        public ActionResult Details(int Id)
        {
            var zadanie = _context.Zadania.Include(c => c.Zajecia).SingleOrDefault(c => c.Id == Id);
            if (zadanie == null)
                return HttpNotFound();
            return View(zadanie);
        }

        public ActionResult MarkAsDone(int Id)
        {
            var zadanie = _context.Zadania.SingleOrDefault(z => z.Id == Id);
            if (zadanie == null)
                return HttpNotFound();
            else
            {
                var ZadnieInDb = _context.Zadania.Single(z => z.Id == Id);
                ZadnieInDb.CzyZrobione = true;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Zadania");
        }

        public ActionResult Delete(int Id)
        {
            var zadanie = _context.Zadania.SingleOrDefault(z => z.Id == Id);
            if (zadanie == null)
                return HttpNotFound();

            _context.Zadania.Remove(zadanie);

            _context.SaveChanges();

            return RedirectToAction("Index", "Zadania");
        }

        public ActionResult Edit(int Id)
        {
            var userID = User.Identity.GetUserId();
            var zadanie = _context.Zadania.SingleOrDefault(z => z.Id == Id);
            var zajecia = _context.Zajecia.Where(c => c.IdUzytkownika == userID).ToList();
            if (zadanie == null)
                return HttpNotFound();

            var zadaniaViewModel = new NewMovieViewModel
            {
                zadanie = zadanie,
                zajecia = zajecia
            };
            return View("ZadaniaForm", zadaniaViewModel);
        }
    }
}