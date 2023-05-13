using FutureStage.Data.CustomFilter;
using FutureStage.Data.Services.SiteAdminServices;
using FutureStage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Areas.SiteAdmin.Controllers
{
    [Area("SiteAdmin")]
    [SiteAdminAuthorization]
    public class AreaController : Controller
    {
        private readonly IAreaService _areaService;
        private readonly ICityService _cityService;
        public AreaController(IAreaService areaService, ICityService cityService)
        {
            _areaService = areaService;
            _cityService = cityService;
        }

        public async Task<IActionResult> Index()
        {
            var allAreas = await _areaService.GetAllAsync();
            return View(allAreas);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Cities = new SelectList(await _cityService.GetAllAsync(), "ID", "CityName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Area data)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Cities = new SelectList(await _cityService.GetAllAsync(), "ID", "CityName");
                return View(data);
            }

            await _areaService.AddAsync(data);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var area = await _areaService.GetByIdAsync(id);
            if (area == null) return View("NotFound");
            ViewBag.Cities = new SelectList(await _cityService.GetAllAsync(), "ID", "CityName");
            return View(area);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Area data)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Cities = new SelectList(await _cityService.GetAllAsync(), "ID", "CityName");
                return View(data);
            }
            await _areaService.UpdateAsync(data);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var area = await _areaService.GetByIdAsync(id);
            if (area == null) return View("NotFound");
            return View(area);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _areaService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
