using FutureStage.Data.Services.SchoolsServices;
using FutureStage.Data.Services.SiteAdminServices;
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
    public class StandardFeesController : Controller
    {
        IStandardFeesService _standardFeesService;
        ISchoolStandardService _schoolStandardService;
        IFeeHeadService _feeHeadService;
        public StandardFeesController(IStandardFeesService standardFeesService, ISchoolStandardService schoolStandardService, IFeeHeadService feeHeadService)
        {
            _standardFeesService = standardFeesService;
            _schoolStandardService = schoolStandardService;
            _feeHeadService = feeHeadService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _standardFeesService.GetAllAsync());
        }

        public async Task<IActionResult> StandardList()
        {
            return View(await _schoolStandardService.GetAllAsync());
        }

        public async Task<IActionResult> Create(int id)
        {
            ViewBag.SchoolStandardID = id;
            ViewBag.FeeHeads = new SelectList(await _feeHeadService.GetAllAsync(), "ID", "FeeHeadTitle");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(StandardFees standardFees)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.SchoolStandardID = standardFees.SchoolStandardID;
                ViewBag.FeeHeads = new SelectList(await _feeHeadService.GetAllAsync(), "ID", "FeeHeadTitle");
                return View(standardFees);
            }

             await _standardFeesService.AddAsync(standardFees);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            StandardFees standardFees = await _standardFeesService.GetByIdAsync(id);

            if (standardFees == null) return View("NotFound");

            ViewBag.FeeHeads = new SelectList(await _feeHeadService.GetAllAsync(), "ID", "FeeHeadTitle");
            ViewBag.SchoolStandards = new SelectList(await _schoolStandardService.GetAllAsync(), "ID", "Standard.StandardTitle");
            return View(standardFees);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(StandardFees standardFees)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.FeeHeads = new SelectList(await _feeHeadService.GetAllAsync(), "ID", "FeeHeadTitle");
                ViewBag.SchoolStandards = new SelectList(await _schoolStandardService.GetAllAsync(), "ID", "Standard.StandardTitle");
                return View(standardFees);
            }
            await _standardFeesService.UpdateAsync(standardFees);
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            StandardFees standardFees = await _standardFeesService.GetByIdAsync(id);

            if (standardFees == null) return View("NotFound");

            return View(standardFees);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _standardFeesService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
