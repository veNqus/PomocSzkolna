using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using WebowaPomocStrona.ViewModels;
using WebowaPomocStrona.Models;
using Microsoft.AspNet.Identity;

namespace WebowaPomocStrona.Controllers
{
    public class ZajeciaController : Controller
    {

        private ApplicationDbContext _context;

        public ZajeciaController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Zajecia
        public ActionResult Index()
        {
            var UserId = User.Identity.GetUserId();
            var zajecia = _context.Zajecia.Where(c => c.IdUzytkownika == UserId).ToList();
            return View(zajecia);
        }

        public ActionResult New()
        {
            return View("ZajeciaForm");
        }

        public ActionResult Save(Zajecia zajecia)
        {
            var UserId = User.Identity.GetUserId();
            if(zajecia.Id== 0)
            {
                zajecia.IdUzytkownika = UserId;
                _context.Zajecia.Add(zajecia);
            }
            else
            {
                var ZajeciaInDb = _context.Zajecia.Single(c => c.Id == zajecia.Id);

                ZajeciaInDb.Nazwa = zajecia.Nazwa;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Zajecia");
        }

        public ActionResult Edit(int Id)
        {
            var userID = User.Identity.GetUserId();
            var zajecia = _context.Zajecia.SingleOrDefault(c => c.Id == Id);
            if (zajecia == null)
                return HttpNotFound();

            var ZajeciaViewModel = new EditZajeciaViewModel
            {
                zajecia = zajecia

            };
            return View("ZajeciaForm", ZajeciaViewModel);
        }

        public ActionResult Delete(int Id)
        {
            var zadania = _context.Zadania.Any(c => c.ZajeciaId == Id);
            if (zadania == true)
            {
                TempData["msg"] = "<script>alert('Nie mozna usunąc gdyż z zajęciami powiązane są zadania');</script>";
            }

            else
            {
                var zajecia = _context.Zajecia.SingleOrDefault(z => z.Id == Id);
                if (zajecia == null)
                    return HttpNotFound();

                _context.Zajecia.Remove(zajecia);

                _context.SaveChanges();
            }
        
            return RedirectToAction("Index", "Zajecia");
        }
    }
}