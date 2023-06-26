using FutureStage.Data;
using FutureStage.Data.Services.SchoolsServices;
using FutureStage.Data.Services.SiteAdminServices;
using FutureStage.Data.ViewModels;
using FutureStage.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Controllers
{
    public class ManageSchoolsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IAreaService _areaService;
        private readonly ISchoolService _schoolService;
        private readonly IEducationBoardService _educationBoardService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ManageSchoolsController(AppDbContext context, IAreaService areaService, ISchoolService schoolService, IWebHostEnvironment webHostEnvironment, IEducationBoardService educationBoardService)
        {
            _context = context;
            _areaService = areaService;
            _schoolService = schoolService;
            _educationBoardService = educationBoardService;
            _webHostEnvironment = webHostEnvironment;
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
                School record = _context.Schools.SingleOrDefault(n => n.EmailID.Equals(loginVM.EmailAddress) && n.Password.Equals(loginVM.Password));
                
                if(record != null)
                {
                    HttpContext.Session.SetInt32("ID", record.ID);
                    TempData["SuccessMessage"] = "Login successful! Enjoy your experience.";
                    return RedirectToAction("Index", "Home", new { area = "Schools" });
                }

                ViewData["ErrorMessage"] = "Invalid credentials. Please check your username and password and try again.";
            }
           
            return View(loginVM);
        }

        public async Task<IActionResult> Register()
        {
            ViewBag.Areas = new SelectList(await _areaService.GetAllAsync(), "ID", "AreaName");
            ViewBag.EducationBoards = new SelectList(await _educationBoardService.GetAllAsync(), "ID", "EducationBoardName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(School school)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Areas = new SelectList(await _areaService.GetAllAsync(), "ID", "AreaName");
                ViewBag.EducationBoards = new SelectList(await _educationBoardService.GetAllAsync(), "ID", "EducationBoardName");

                return View(school);
            }

            if(school.Image != null)
            {
                if(school.Image.Length > 0)
                {
                    string folderpath = "Images/SchoolsImage/";
                    folderpath += Guid.NewGuid().ToString() + "_" + school.Image.FileName;

                    school.ImagePath = "/"+folderpath;

                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderpath);

                    await school.Image.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                }
            }
            school.EstablishmentDate = school.EstablishmentDate.Date;
            await _schoolService.AddAsync(school);

            foreach(int educationBoardID in school.EducationBoardID)
            {
                School_EducationBoard school_EducationBoard = new School_EducationBoard()
                {
                    SchoolID = school.ID,
                    EducationBoardID = educationBoardID
                };
                await _context.School_EducationBoards.AddAsync(school_EducationBoard);
            }
            await _context.SaveChangesAsync();
            TempData["RegisterMessage"] = "Registration Successful! You can now log in with your credentials.";
            return RedirectToAction(nameof(doLogin));
        }

        public  IActionResult Logout()
        {
            HttpContext.Session.Clear();
            TempData["LogoutMessage"] = "Logout Successful! You have been securely logged out.";
            return RedirectToAction(nameof(doLogin));
        }

    }
}
