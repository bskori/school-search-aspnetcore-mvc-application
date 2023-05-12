using FutureStage.Data.Services.SiteAdminServices;
using FutureStage.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Areas.SiteAdmin.Controllers
{
    [Area("SiteAdmin")]
    public class FacilityController : Controller
    {
        IFacilityService _service;
        public FacilityController(IFacilityService service)
        {
            _service = service;
        }
        public async Task<IActionResult>  Index()
        {
            var allFacilities = await _service.GetAllAsync();
            return View(allFacilities);
        }

        public IActionResult Create()
        {
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
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            Facility facility = await _service.GetByIdAsync(id);

            if (facility == null) return View("NotFound");

            return View(facility);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Facility facility)
        {
            if (!ModelState.IsValid)
            {
                return View(facility);
            }

            await _service.UpdateAsync(facility);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            Facility facility = await _service.GetByIdAsync(id);

            if (facility == null) return View("NotFound");

            return View(facility);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
