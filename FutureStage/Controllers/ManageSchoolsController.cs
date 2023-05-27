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
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ManageSchoolsController(AppDbContext context, IAreaService areaService, ISchoolService schoolService, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _areaService = areaService;
            _schoolService = schoolService;
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
                    HttpContext.Session.SetString("ID", record.ID.ToString());
                    return RedirectToAction("Index", "Home", new { area = "Schools" });
                }

                TempData["Error"] = "Wrong credentials. Please, try again!";
            }

            return View(loginVM);
        }

        public async Task<IActionResult> Register()
        {
            ViewBag.Areas = new SelectList(await _areaService.GetAllAsync(), "ID", "AreaName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(School school)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Areas = new SelectList(await _areaService.GetAllAsync(), "ID", "AreaName");
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
            return RedirectToAction(nameof(doLogin));
        }

        public  IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(doLogin));
        }

    }
}
