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
            ViewBag.Areas = await _areaService.GetAllAsync();
            ViewBag.Cities = new SelectList(await _cityService.GetAllAsync(), "ID", "CityName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Area data)
        {
            if (!ModelState.IsValid)
            {
                return View(data);
            }

            await _areaService.AddAsync(data);
            TempData["AlertMessage"] = "Record Created Succesfully.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var area = await _areaService.GetByIdAsync(id);
            if (area == null) return View("NotFound");
            return Json(new { 
                areaName = area.AreaName,
                cityID = area.CityID
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Area data)
        {
            if (!ModelState.IsValid)
            {
                return View(data);
            }
            await _areaService.UpdateAsync(data);
            TempData["AlertMessage"] = "Record updated succesfully.";
            return RedirectToAction(nameof(Index));
        }

       

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _areaService.DeleteAsync(id);
                TempData["AlertMessage"] = "Record deleted succesfully.";
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while deleting the entity.");
            }
        }
    }
}
