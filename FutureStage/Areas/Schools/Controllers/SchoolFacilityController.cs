using FutureStage.Data;
using FutureStage.Data.Services.SchoolsServices;
using FutureStage.Data.Services.SiteAdminServices;
using FutureStage.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Areas.Schools.Controllers
{
    [Area("Schools")]
    public class SchoolFacilityController : Controller
    {
        private readonly ISchoolFacilityService _schoolFacilityService;
        private readonly IFacilityService _facilityService;
        private readonly AppDbContext _context;
        public SchoolFacilityController(ISchoolFacilityService schoolFacilityService, IFacilityService facilityService, AppDbContext context)
        {
            _schoolFacilityService = schoolFacilityService;
            _facilityService = facilityService;
            _context = context;
        }

        public async Task<IActionResult> Index(int id)
        {
            ViewBag.SchoolFacilities = _context.SchoolFacilities.Where(sf => sf.SchoolID == id).ToList();
            ViewBag.Facilities = new SelectList(await _facilityService.GetAllAsync(), "ID", "FacilityName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SchoolFacility schoolFacility)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            int schoolId = Convert.ToInt32(HttpContext.Session.GetInt32("ID"));
            schoolFacility.SchoolID = schoolId;
            await _schoolFacilityService.AddAsync(schoolFacility);
            TempData["AlertMessage"] = "Record added successfully.";
            return RedirectToAction("Index", new { id = schoolId });
        }

        public async Task<IActionResult> Edit(int id)
        {
            SchoolFacility schoolFacility = await _schoolFacilityService.GetByIdAsync(id);

            if (schoolFacility == null) return View("NotFound");

            return Json(new { 
                facilityId = schoolFacility.FacilityID,
                schoolId = schoolFacility.SchoolID
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SchoolFacility schoolFacility)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
           
            await _schoolFacilityService.UpdateAsync(schoolFacility);
            TempData["AlertMessage"] = "Record updated successfully.";
            return RedirectToAction("Index", new { id = schoolFacility.SchoolID });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _schoolFacilityService.DeleteAsync(id);
                TempData["AlertMessage"] = "Record deleted successfully.";
                int schoolId = Convert.ToInt32(HttpContext.Session.GetInt32("ID"));
                return RedirectToAction("Index", new { id = schoolId });
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while deleting the entity.");
            }
        }
    }
}
