using FutureStage.Data.CustomFilter;
using FutureStage.Data.Services.SiteAdminServices;
using FutureStage.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Areas.SiteAdmin.Controllers
{
    [Area("SiteAdmin")]
    //[SiteAdminAuthorization]
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
            ViewBag.Cities = await _cityService.GetAllAsync();
            ViewBag.States = new SelectList(await _stateService.GetAllAsync(), "ID", "StateName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(City city)
        {
            if (!ModelState.IsValid)
            {
                return View(city);
            }
            await _cityService.AddAsync(city);
            TempData["AlertMessage"] = "Record created succesfully.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var city = await _cityService.GetByIdAsync(id);
            if (city == null) return View("NotFound");
            
            return Json(new { 
                cityName = city.CityName,
                stateID = city.StateID
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(City city)
        {
            if (!ModelState.IsValid)
            {
                return View(city);
            }
            await _cityService.UpdateAsync(city);
            TempData["AlertMessage"] = "Record updated successfully";
            return RedirectToAction(nameof(Index));
        }

        

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _cityService.DeleteAsync(id);
                TempData["AlertMessage"] = "Record deleted successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error ocurred while deleting the entity.");
            }
        }
    }
}
