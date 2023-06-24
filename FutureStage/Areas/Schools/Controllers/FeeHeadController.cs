using FutureStage.Data;
using FutureStage.Data.Services.SchoolsServices;
using FutureStage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Areas.Schools.Controllers
{
    [Area("Schools")]
    public class FeeHeadController : Controller
    {
        
        private readonly IFeeHeadService _service;
        
        public FeeHeadController(IFeeHeadService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
           ViewBag.FeeHeads =await _service.GetAllAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(FeeHead feeHead)
        {
            if (!ModelState.IsValid)
            {
                return View(feeHead);
            }

            await _service.AddAsync(feeHead);
            TempData["AlertMessage"] = "New record created successfully!";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            FeeHead feeHead = await _service.GetByIdAsync(id);

            if (feeHead == null) return View("NotFound");

            return View(feeHead);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(FeeHead feeHead)
        {
            if (!ModelState.IsValid)
            {
                return View(feeHead);
            }

            await _service.UpdateAsync(feeHead);
            return RedirectToAction(nameof(Index));
        }

        public  async Task<IActionResult> Delete(int id)
        {
            FeeHead feeHead = await _service.GetByIdAsync(id);

            if (feeHead == null) return View("NotFound");

            return View(feeHead);
        }

        [ActionName("Delete")]
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
