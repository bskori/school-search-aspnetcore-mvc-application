using FutureStage.Data;
using FutureStage.Data.Services.SchoolsServices;
using FutureStage.Models;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class FeeHeadController : Controller
    {
        
        private readonly IFeeHeadService _service;
        private readonly AppDbContext _context;
        
        public FeeHeadController(IFeeHeadService service, AppDbContext context)
        {
            _service = service;
            _context = context;
        }

        public IActionResult Index(int id)
        {
            ViewBag.FeeHeads = _context.FeeHeads.Where(fh => fh.SchoolStandard.SchoolID == id).ToList();
            List<SchoolStandard> schoolStandards = _context.SchoolStandards.Where(ss => ss.SchoolID == id).ToList();
            List<Standard> standards = schoolStandards.Select(ss => ss.Standard).ToList();
            ViewBag.Standards = new SelectList(standards, "ID", "StandardName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(FeeHead feeHead)
        {
            if (!ModelState.IsValid)
            {
                return View(feeHead);
            }

            int schoolId = Convert.ToInt32(HttpContext.Session.GetInt32("ID"));

            int schoolStandardId = _context.SchoolStandards.Where(ss => ss.SchoolID == schoolId && ss.StandardID == feeHead.SchoolStandardID).Select(ss => ss.ID).FirstOrDefault();

            feeHead.SchoolStandardID = schoolStandardId;

            await _service.AddAsync(feeHead);

            TempData["AlertMessage"] = "Record added successfully!";
            return RedirectToAction("Index",new { id = schoolId});
        }

        public async Task<IActionResult> Edit(int id)
        {
            FeeHead feeHead = await _service.GetByIdAsync(id);

            if (feeHead == null) return View("NotFound");

            return Json(new { 
                feeHeadName = feeHead.FeeHeadName,
                schoolStandardId = feeHead.SchoolStandard.Standard.ID
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(FeeHead feeHead)
        {
            if (!ModelState.IsValid)
            {
                return View(feeHead);
            }

            int schoolId = Convert.ToInt32(HttpContext.Session.GetInt32("ID"));

            int schoolStandardId = _context.SchoolStandards.Where(ss => ss.SchoolID == schoolId && ss.Standard.ID == feeHead.SchoolStandardID).Select(ss => ss.ID).FirstOrDefault();

            feeHead.SchoolStandardID = schoolStandardId;

            await _service.UpdateAsync(feeHead);
            TempData["AlertMessage"] = "Record updated successfully.";
            return RedirectToAction("Index", new { id = schoolId});
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                int schoolId = Convert.ToInt32(HttpContext.Session.GetInt32("ID"));
                TempData["AlertMessage"] = "Record deleted successfully.";
                return RedirectToAction("Index",new { id = schoolId});
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"An error occured while deleting the entity.");
            }
        }
    }
}
