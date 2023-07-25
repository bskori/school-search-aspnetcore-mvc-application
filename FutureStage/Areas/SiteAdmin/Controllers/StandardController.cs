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
    public class StandardController : Controller
    {
        IStandardService _service;
        public StandardController(IStandardService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Standards = await _service.GetAllAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Standard standard)
        {
            if (!ModelState.IsValid)
            {
                return View(standard);
            }

            await _service.AddAsync(standard);
            TempData["AlertMessage"] = "Record created successfully.";
            return RedirectToAction(nameof(Index));
        }

        public  async Task<IActionResult> Edit(int id)
        {
            Standard standard = await _service.GetByIdAsync(id);

            if (standard == null) return View("NotFound");
            return Json(new { 
                standardName = standard.StandardName
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Standard standard)
        {
            if (!ModelState.IsValid)
            {
                return View(standard);
            }

            await _service.UpdateAsync(standard);
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
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured while deleting the entity.");
            }
        }
    }
}
