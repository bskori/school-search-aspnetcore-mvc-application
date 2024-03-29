﻿using FutureStage.Data;
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
                    HttpContext.Session.SetString("SiteAdminID", record.ID.ToString());
                    HttpContext.Session.SetString("Name", record.Name.ToString());

                    TempData["SuccessMessage"] = "Succesfully logged In!"; 

                    return RedirectToAction("Index", "Home", new { area = "SiteAdmin" });
                }
                ViewData["ErrorMessage"]= "Invalid credentials. Please check your username and password and try again.";
            }

            return View(loginVM);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            TempData["LogoutMessage"] = "Logout Successful! You have been securely logged out.";
            return RedirectToAction(nameof(doLogin)); 
        }
    }
}
