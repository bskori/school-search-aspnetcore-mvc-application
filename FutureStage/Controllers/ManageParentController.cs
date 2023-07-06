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
                    HttpContext.Session.SetString("Name", parent.Name);
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

        public async Task<IActionResult> EditProfile(int id)
        {
            Parent parent = await _context.Parents.FindAsync(id);
            return View(parent);
        }

     

        [HttpPost]
        public IActionResult EditProfile(Parent parent)
        {
            if (!ModelState.IsValid)
            {
                return View(parent);
            }

            _context.Parents.Update(parent);
            _context.SaveChanges();
            TempData["EditProfileMessage"] = "Profile Updated Successfully!";
            return RedirectToAction("Index", "Home");
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            TempData["LogoutMessage"] = "Logout Successful! You have been securely logged out.";
            return RedirectToAction("Index", "Home");
        }
    }
}
