using FutureStage.Data.CustomFilter;
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
            
            return View(await _service.GetAllAsync());
        }

        public IActionResult Create()
        {
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
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            Quoto quoto = await _service.GetByIdAsync(id);

            if (quoto == null) return View("NotFound");

            return View(quoto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Quoto quoto)
        {
            if (!ModelState.IsValid)
            {
                return View(quoto);
            }

            await _service.UpdateAsync(quoto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            Quoto quoto = await _service.GetByIdAsync(id);

            if (quoto == null) return View("NotFound");

            return View(quoto);
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
