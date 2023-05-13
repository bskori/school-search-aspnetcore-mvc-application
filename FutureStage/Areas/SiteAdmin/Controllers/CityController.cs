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
    public class CityController : Controller
    {
        private readonly ICityService _cityService;
        private readonly IStateService _stateService;
        public CityController(ICityService cityService, IStateService stateService)
        {
            _cityService = cityService;
            _stateService = stateService;
        }

        public async Task<IActionResult> Index()
        {
            var allCities = await _cityService.GetAllAsync();
            return View(allCities);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.States = new SelectList(await _stateService.GetAllAsync(), "ID", "StateName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(City city)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.States = new SelectList(await _stateService.GetAllAsync(), "ID", "StateName");
                return View(city);
            }
            await _cityService.AddAsync(city);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var city = await _cityService.GetByIdAsync(id);
            if (city == null) return View("NotFound");
            ViewBag.States = new SelectList(await _stateService.GetAllAsync(), "ID", "StateName");
            return View(city);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(City city)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.States = new SelectList(await _stateService.GetAllAsync(), "ID", "StateName");
                return View(city);
            }
            await _cityService.UpdateAsync(city);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var city = await _cityService.GetByIdAsync(id);
            if (city == null) return View("NotFound");
            return View(city);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _cityService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
