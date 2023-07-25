using FutureStage.Data;
using FutureStage.Data.Services.SchoolsServices;
using FutureStage.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Areas.Schools.Controllers
{
    [Area("Schools")]
    [Authorize]
    public class SchoolAchivementController : Controller
    {
        private readonly ISchoolAchivementService _schoolAchivementService;
        private readonly AppDbContext _context;
        public SchoolAchivementController(ISchoolAchivementService schoolAchivementService, AppDbContext context)
        {
            _schoolAchivementService = schoolAchivementService;
            _context = context;
        }

        public IActionResult Index(int id)
        {
            ViewBag.Achivements = _context.SchoolAchivements.Where(sa => sa.SchoolID == id).ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SchoolAchivement schoolAchivement)
        {
            if (!ModelState.IsValid)
            {
                return View(schoolAchivement);
            }
            int schoolId = Convert.ToInt32(HttpContext.Session.GetInt32("ID"));
            schoolAchivement.SchoolID = schoolId;
            await _schoolAchivementService.AddAsync(schoolAchivement);
            TempData["AlertMessage"] = "Record added successfully";
            return RedirectToAction("Index", new { id = schoolId});
        }

        public async Task<IActionResult> Edit(int id)
        {
            SchoolAchivement schoolAchivement = await _schoolAchivementService.GetByIdAsync(id);

            if (schoolAchivement == null) return View("NotFound");

            return Json(new {
                achivementTitle = schoolAchivement.AchivementTitle,
                achivementDescription = schoolAchivement.AchivementDescription,
                achivementDate = schoolAchivement.AchivementDate,
                displayDate = schoolAchivement.AchivementDate.ToString("dd-MM-yyyy"),
                schoolId = schoolAchivement.SchoolID
            });;
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SchoolAchivement schoolAchivement)
        {
            if (!ModelState.IsValid)
            {
                return View(schoolAchivement);
            }

            await _schoolAchivementService.UpdateAsync(schoolAchivement);
            TempData["AlertMessage"] = "Record updated successfully.";
            return RedirectToAction("Index", new { id = schoolAchivement.SchoolID});
        }

       

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _schoolAchivementService.DeleteAsync(id);
                TempData["AlertMessage"] = "Record deleted successfully.";
                int schoolId = Convert.ToInt32(HttpContext.Session.GetInt32("ID"));
                return RedirectToAction("Index", new { id = schoolId });
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured while deleting the entity.");
            }
        }
    }
}
