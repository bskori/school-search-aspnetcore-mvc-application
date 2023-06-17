using FutureStage.Data;
using FutureStage.Data.ViewModels;
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
        public IActionResult doLogin(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                SiteAdmin record = _context.SiteAdmins.SingleOrDefault(n => n.EmailAddress == loginVM.EmailAddress && n.Password == loginVM.Password);
                if (record != null)
                {
                    HttpContext.Session.SetString("ID", record.ID.ToString());

                    TempData["SuccessMessage"] = "Succesfully logged In!"; 

                    return RedirectToAction("Index", "Home", new { area = "SiteAdmin" });
                }
                ViewData["ErrorMessage"]= "Invalid credentials! Please try again.";
            }

            return View(loginVM);
        }


    }
}
