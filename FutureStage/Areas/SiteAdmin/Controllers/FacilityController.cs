using FutureStage.Data.CustomFilter;
using FutureStage.Data.Services.SiteAdminServices;
using FutureStage.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Areas.SiteAdmin.Controllers
{
    [Area("SiteAdmin")]
    [SiteAdminAuthorization]
    public class FacilityController : Controller
    {
        IFacilityService _service;
        public FacilityController(IFacilityService service)
        {
            _service = service;
        }
        public async Task<IActionResult>  Index()
        {
            ViewBag.Facilities = await _service.GetAllAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Facility facility)
        {
            if (!ModelState.IsValid)
            {
                return View(facility);
            }
            await _service.AddAsync(facility);
            TempData["AlertMessage"] = "Record created successfully.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            Facility facility = await _service.GetByIdAsync(id);

            if (facility == null) return View("NotFound");

            return Json(new
            {
                facilityName = facility.FacilityName,
                facilityIcon = facility.FacilityIcon
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Facility facility)
        {
            if (!ModelState.IsValid)
            {
                return View(facility);
            }

            await _service.UpdateAsync(facility);
            TempData["AlertMessage"] = "Record updated successfully.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                TempData["AlertMessage"] = "Record deleted successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error ocurred while deleting the entity.");
            }
        }
    }
}
