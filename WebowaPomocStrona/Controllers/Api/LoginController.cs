using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using WebowaPomocStrona.Models;

namespace WebowaPomocStrona.Controllers.Api
{
    public class LoginController : ApiController
    {
        private ApplicationDbContext _context;

        public LoginController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public string Login(Login login)
        {
            string id = null;
            try
            {
                id = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindByEmail(login.Email).Id;
            }
            catch
            {

            }
            if (id == null)
            {
                
                return "error";
            }
            else
            {
                PasswordHasher passwordHasher = new PasswordHasher();
                string passwdhashed = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindByEmail(login.Email).PasswordHash;
                var result = passwordHasher.VerifyHashedPassword(passwdhashed, login.Haslo);

                if (result == PasswordVerificationResult.Success)
                {
                    return id;
                }
                else
                {
                    return "error";
                }
            }
        }
    }
}
