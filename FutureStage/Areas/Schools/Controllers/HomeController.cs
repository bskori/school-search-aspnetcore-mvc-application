using FutureStage.Data;
using FutureStage.Data.Services.SchoolsServices;
using FutureStage.Data.Services.SiteAdminServices;
using FutureStage.Data.ViewModels;
using FutureStage.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Areas.Schools.Controllers
{
    [Area("Schools")]
    public class HomeController : Controller
    {
        private readonly ISchoolService _schoolService;
        private readonly IAreaService _areaService;
        private readonly IEducationBoardService _educationBoardService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly AppDbContext _context;

        public HomeController(ISchoolService schoolService, IAreaService areaService, IEducationBoardService educationBoardService, IWebHostEnvironment webHostEnvironment, AppDbContext context)
        {
            _context = context;
            _educationBoardService = educationBoardService;
            _schoolService = schoolService;
            _areaService = areaService;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SchoolProfile(int id)
        {
            School school = await _schoolService.GetByIdAsync(id);
            if (school == null) return View("NotFound");

            return View(school);
        }

        public async Task<IActionResult> UpdateSchoolProfile(int id)
        {
            School school = await _schoolService.GetByIdAsync(id);
            if (school == null) return View("NotFound");

            ViewBag.Areas = new SelectList(await _areaService.GetAllAsync(), "ID", "AreaName");
          
            ViewBag.EducationBoards = await _educationBoardService.GetAllAsync();

            ViewBag.SelectedEducationBoardIds  = school.School_EducationBoards.Select(p => p.EducationBoard.ID).ToList();
            

            return View(school);
        }

        [HttpPost]
        public  async Task<IActionResult> UpdateSchoolProfile(School school)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Areas = new SelectList(await _areaService.GetAllAsync(), "ID", "AreaName");

                ViewBag.EducationBoards = await _educationBoardService.GetAllAsync();

                ViewBag.SelectedEducationBoardIds = school.School_EducationBoards.Select(p => p.EducationBoard.ID).ToList();
                return View(school);
            }

            if(school.Image != null)
            {
                if(school.Image.Length > 0)
                {
                    //new filename for image
                    string folderpath = "Images/SchoolsImage/";
                    string newFileName = Guid.NewGuid().ToString() + "_" + school.Image.FileName;
                    string newImagePath = "/" + folderpath+newFileName;

                    //deleting old image
                    if (!string.IsNullOrEmpty(school.ImagePath))
                    {
                        string oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, school.ImagePath.TrimStart('/'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    //save new image
                    string serverFolderPath = Path.Combine(_webHostEnvironment.WebRootPath, folderpath);
                    string serverFilePath = Path.Combine(serverFolderPath, newFileName);
                    await school.Image.CopyToAsync(new FileStream(serverFilePath, FileMode.Create));

                    //upadate path
                    school.ImagePath = newImagePath;
                }
            }
            school.EstablishmentDate = school.EstablishmentDate.Date;
            await _schoolService.UpdateAsync(school);

            var existingEducationBoards = _context.School_EducationBoards.Where(p => p.SchoolID == school.ID);
            _context.School_EducationBoards.RemoveRange(existingEducationBoards);

            foreach (var educationBoardID in school.EducationBoardID)
            {
                School_EducationBoard school_EducationBoard = new School_EducationBoard()
                {
                    SchoolID = school.ID,
                    EducationBoardID = educationBoardID,
                };
                await _context.School_EducationBoards.AddAsync(school_EducationBoard);
            }
            await _context.SaveChangesAsync();

            TempData["UpdateProfileMessage"] = "Profile updated successfully.";

            return RedirectToAction(nameof(Index));
        }

        public IActionResult ChangePassword(int id)
        {
            ChangePasswordVM changePasswordVM = new ChangePasswordVM();
            changePasswordVM.ID = id;

            return View(changePasswordVM);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordVM changePasswordVM)
        {
            if (!ModelState.IsValid)
            {
                return View(changePasswordVM);
            }

            School school = await _schoolService.GetByIdAsync(changePasswordVM.ID);
            school.Password = changePasswordVM.Password;
            school.ConfirmPassword = changePasswordVM.ConfirmPassword;
            await _schoolService.UpdateAsync(school);
            TempData["ChangePasswordMessage"] = "Password changed successfully!";
            return RedirectToAction(nameof(Index));
        }
    }
}
