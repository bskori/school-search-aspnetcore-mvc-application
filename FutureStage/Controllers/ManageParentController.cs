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
    public class ManageParentController : Controller
    {
        private readonly AppDbContext _context;
        public ManageParentController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult doLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult doLogin(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                Parent parent = _context.Parents.SingleOrDefault(p => p.EmailID == loginVM.EmailAddress && p.Password == loginVM.Password);
                if(parent != null)
                {
                    HttpContext.Session.SetInt32("ID", parent.ID);
                    TempData["SuccessMessage"] = "Login successful! Enjoy your experience.";
                    return RedirectToAction("Index", "Home");
                }
                TempData["ErrorMessage"] = "Invalid credentials. Please check your username and password and try again.";
            }
            
            return View(loginVM);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Parent parent)
        {
            if (!ModelState.IsValid)
            {
                return View(parent);
            }

            await _context.Parents.AddAsync(parent);
            await _context.SaveChangesAsync();

            TempData["RegisterMessage"] = "Registration Successful! You can now log in with your credentials.";
            return RedirectToAction(nameof(doLogin));
        }
    }
}
