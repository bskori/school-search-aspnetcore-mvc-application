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
    public class StateController : Controller
    {
        private readonly IStateService _service;
        private readonly ICountryService _countryService;

        public StateController(IStateService service, ICountryService countryService)
        {
            _service = service;
            _countryService = countryService;
        }

        public async Task<IActionResult> Index()
        {
            var allStates = await _service.GetAllAsync();
            return View(allStates);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.States = new SelectList(await _countryService.GetAllAsync(), "ID", "CountryName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(State state)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.States = new SelectList(await _countryService.GetAllAsync(), "ID", "CountryName");
                return View(state);
            }
            await _service.AddAsync(state);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var state = await _service.GetByIdAsync(id);
            if (state == null) return View("NotFound");
            ViewBag.States = new SelectList(await _countryService.GetAllAsync(), "ID", "CountryName");
            return View(state);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(State state)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.States = new SelectList(await _countryService.GetAllAsync(), "ID", "CountryName");
                return View(state);
            }
            await _service.UpdateAsync(state);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var state = await _service.GetByIdAsync(id);
            if (state == null) return View("NotFound");
            return View(state);
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
