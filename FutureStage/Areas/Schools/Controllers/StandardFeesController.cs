using FutureStage.Data;
using FutureStage.Data.Services.SchoolsServices;
using FutureStage.Data.Services.SiteAdminServices;
using FutureStage.Models;
using Microsoft.AspNetCore.Http;
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
        private readonly IStandardFeesService _standardFeesService;
        private readonly ISchoolStandardService _schoolStandardService;
        private readonly IFeeHeadService _feeHeadService;
        private readonly AppDbContext _context;
        public StandardFeesController(IStandardFeesService standardFeesService, ISchoolStandardService schoolStandardService, IFeeHeadService feeHeadService, AppDbContext context)
        {
            _standardFeesService = standardFeesService;
            _schoolStandardService = schoolStandardService;
            _feeHeadService = feeHeadService;
            _context = context;
        }

        public IActionResult Index(int id)
        {
            ViewBag.StandardFees = _context.StandardFees.Where(sf => sf.SchoolStandard.SchoolID == id).ToList();
            return View();
        }

        public async Task<IActionResult> StandardList()
        {
            int schoolId = Convert.ToInt32(HttpContext.Session.GetInt32("ID"));
            ViewBag.SchoolStandards = _context.SchoolStandards.Where(ss => ss.SchoolID == schoolId).ToList();
            ViewBag.FeeHeads = new SelectList(await _feeHeadService.GetAllAsync(), "ID", "FeeHeadName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(StandardFees standardFees)
        {
            if (!ModelState.IsValid)
            { 
                return View(standardFees);
            }
             await _standardFeesService.AddAsync(standardFees);
            TempData["AlertMessage"] = "Record added successfully.";
            int schoolId = Convert.ToInt32(HttpContext.Session.GetInt32("ID"));
            return RedirectToAction("Index",new { id =schoolId });
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
