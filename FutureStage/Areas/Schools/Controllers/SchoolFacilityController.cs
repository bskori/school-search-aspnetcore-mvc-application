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
        ISchoolFacilityService _schoolFacilityService;
        IFacilityService _facilityService;
        public SchoolFacilityController(ISchoolFacilityService schoolFacilityService, IFacilityService facilityService)
        {
            _schoolFacilityService = schoolFacilityService;
            _facilityService = facilityService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _schoolFacilityService.GetAllAsync());
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Facilities = new SelectList(await _facilityService.GetAllAsync(), "ID", "FacilityTitle");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SchoolFacility schoolFacility)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Facilities = new SelectList(await _facilityService.GetAllAsync(), "ID", "FacilityTitle");
            }

            schoolFacility.SchoolID = Convert.ToInt32(HttpContext.Session.GetString("ID"));

            await _schoolFacilityService.AddAsync(schoolFacility);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            SchoolFacility schoolFacility = await _schoolFacilityService.GetByIdAsync(id);

            if (schoolFacility == null) return View("NotFound");

            ViewBag.Facilities = new SelectList(await _facilityService.GetAllAsync(), "ID", "FacilityTitle");

            return View(schoolFacility);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SchoolFacility schoolFacility)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Facilities = new SelectList(await _facilityService.GetAllAsync(), "ID", "FacilityTitle");
            }

            await _schoolFacilityService.UpdateAsync(schoolFacility);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            SchoolFacility schoolFacility = await _schoolFacilityService.GetByIdAsync(id);

            if (schoolFacility == null) return View("NotFound");

            return View();
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _schoolFacilityService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
