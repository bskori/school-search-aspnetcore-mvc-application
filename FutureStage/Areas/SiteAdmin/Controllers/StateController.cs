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
    public class StateController : Controller
    {
        private readonly IStateService _service;


        public StateController(IStateService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.States = await _service.GetAllAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(State state)
        {
            if (!ModelState.IsValid)
            {
                return View(state);
            }
            await _service.AddAsync(state);
            TempData["AlertMessage"] = "Record created succesfully.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var state = await _service.GetByIdAsync(id);
            if (state == null) return View("NotFound");

            return Json(new { 
                stateName = state.StateName
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(State state)
        {
            if (!ModelState.IsValid)
            {
                return View(state);
            }
            await _service.UpdateAsync(state);
            TempData["AlertMessage"] = "Record updated succesfully.";
            return RedirectToAction(nameof(Index));
        }

      

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                TempData["AlertMessage"] = "Record created succesfully.";
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured while deleting the entity.");
            }
        }
    }
}
