using FutureStage.Data;
using FutureStage.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Controllers
{
    public class ManageSiteAdminController : Controller
    {
        private readonly AppDbContext _context;
        public ManageSiteAdminController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult doLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult doLogin(SiteAdmin siteAdmin)
        {
            if (ModelState.IsValid)
            {
                SiteAdmin data =  _context.SiteAdmins.SingleOrDefault(n => n.EmailAddress == siteAdmin.EmailAddress && n.Password == siteAdmin.Password);
                if (data != null)
                {
                    HttpContext.Session.SetString("ID", data.ID.ToString());
                    return RedirectToAction("Index","Home", new { area= "SiteAdmin"});
                }
                TempData["Error"] = "Wrong credentials. Please, try again!";
            }

            return View(siteAdmin);   
        }


    }
}
