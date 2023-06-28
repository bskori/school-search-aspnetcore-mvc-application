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

        public async Task<IActionResult> Index(int id)
        {
            ViewBag.StandardFees = _context.StandardFees.Where(sf => sf.SchoolStandard.SchoolID == id).ToList();
            List<Standard> standards = _context.SchoolStandards.Where(ss => ss.SchoolID == id).Select(s => s.Standard).ToList();
            ViewBag.Standards = new SelectList(standards, "ID", "StandardName");
            ViewBag.FeeHeads = new SelectList(await _feeHeadService.GetAllAsync(), "ID", "FeeHeadName");
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

            return Json(new {
                schoolStandardId = standardFees.SchoolStandardID,
                feeHeadId = standardFees.FeeHeadID,
                amount = standardFees.Amount,
                standardId = standardFees.SchoolStandard.Standard.ID
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(StandardFees standardFees)
        {
            if (!ModelState.IsValid)
            {
                return View(standardFees);
            }
            await _standardFeesService.UpdateAsync(standardFees);
            TempData["AlertMessage"] = "Record updated successfully.";
            int schoolId = Convert.ToInt32(HttpContext.Session.GetInt32("ID"));
            return View("Index",new { id= schoolId });
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _standardFeesService.DeleteAsync(id);
                TempData["AlertMessage"] = "Record deleted successfully.";
                int schoolId = Convert.ToInt32(HttpContext.Session.GetInt32("ID"));
                return RedirectToAction("Index", new { id = schoolId });
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurd while deleting the entity");
            }
        }
    }
}
