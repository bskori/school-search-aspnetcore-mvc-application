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
    public class QuotaController : Controller
    {
        IQuotaService _service;
        public QuotaController(IQuotaService service)
        {
            _service = service;
        }
        public async Task<IActionResult>  Index()
        {
            ViewBag.Quotos = await _service.GetAllAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Quoto quoto)
        {
            if (!ModelState.IsValid)
            {
                return View(quoto);
            }
            await _service.AddAsync(quoto);
            TempData["AlertMessage"] = "Record created successfully.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            Quoto quoto = await _service.GetByIdAsync(id);

            if (quoto == null) return View("NotFound");

            return Json(new { 
                quotoName = quoto.QuotoName
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Quoto quoto)
        {
            if (!ModelState.IsValid)
            {
                return View(quoto);
            }

            await _service.UpdateAsync(quoto);
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
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured while deleting the entity.");
            }
        }
    }
}
