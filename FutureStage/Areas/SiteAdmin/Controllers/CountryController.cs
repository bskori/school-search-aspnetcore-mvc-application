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
    public class CountryController : Controller
    {
        private readonly ICountryService _service;
        public CountryController(ICountryService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allCountries = await _service.GetAllAsync();
            return View(allCountries);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Country country)
        {
            if (!ModelState.IsValid)
            {
                return View(country);
            }
            await _service.AddAsync(country);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var country = await _service.GetByIdAsync(id);
            if (country == null) return View("NotFound");
            return View(country);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Country country)
        {
            if (!ModelState.IsValid)
            {
                return View(country);
            }
            await _service.UpdateAsync(country);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var country = await _service.GetByIdAsync(id);
            if (country == null) return View("NotFound");
            return View(country);
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
