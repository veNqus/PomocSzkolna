using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
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
            zajecia.IdUzytkownika = UserId;
            if(zajecia.Id== 0)
            {
                _context.Zajecia.Add(zajecia);
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Zajecia");
        }
    }
}