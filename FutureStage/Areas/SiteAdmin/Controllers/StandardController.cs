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
    //[SiteAdminAuthorization]
    public class StandardController : Controller
    {
        IStandardService _service;
        public StandardController(IStandardService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allStandards = await _service.GetAllAsync();
            return View(allStandards);
        }

        public IActionResult Create()
        {
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
            return RedirectToAction(nameof(Index));
        }

        public  async Task<IActionResult> Edit(int id)
        {
            Standard standard = await _service.GetByIdAsync(id);

            if (standard == null) return View("NotFound");
            return View(standard);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Standard standard)
        {
            if (!ModelState.IsValid)
            {
                return View(standard);
            }

            await _service.UpdateAsync(standard);
            return RedirectToAction(nameof(Index));
        }

        public  async Task<IActionResult> Delete(int id)
        {
            Standard standard = await _service.GetByIdAsync(id);

            if (standard == null) return View("NotFound");

            return View(standard);
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
