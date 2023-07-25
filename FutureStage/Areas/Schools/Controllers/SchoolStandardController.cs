using FutureStage.Data;
using FutureStage.Data.Services.SchoolsServices;
using FutureStage.Data.Services.SiteAdminServices;
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
    public class SchoolStandardController : Controller
    {
        AppDbContext _context; 
        ISchoolStandardService _schoolStandardService;
        IStandardService _standardService;
        public SchoolStandardController(ISchoolStandardService schoolStandardService, IStandardService standardService, AppDbContext context)
        {
            _schoolStandardService = schoolStandardService;
            _standardService = standardService;
            _context = context;
        }

        public IActionResult Index(int id)
        {
            ViewBag.SchoolStandards = _context.SchoolStandards.Where(ss => ss.SchoolID == id).ToList();
            List<Standard> standards = _context.SchoolStandards.Where(ss => ss.SchoolID == id).Select(s => s.Standard).ToList();
            ViewBag.Standards = new SelectList( standards, "ID", "StandardName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SchoolStandard schoolStandard, int[] Quotos, int[] NoOfSeats)
        {
            int schoolId = Convert.ToInt32(HttpContext.Session.GetInt32("ID"));
            schoolStandard.SchoolID = schoolId;
            await _schoolStandardService.AddAsync(schoolStandard);

            int tempId = _context.SchoolStandards.OrderByDescending(m => m.ID).Select(m => m.ID).FirstOrDefault();

            for(int i=0; i<Quotos.Length && i<NoOfSeats.Length; i++)
            {
                StandardSeatQuoto standardSeatQuoto = new StandardSeatQuoto();
                standardSeatQuoto.QuotoID = Quotos[i];
                standardSeatQuoto.NumberOfSeats = NoOfSeats[i];
                standardSeatQuoto.SchoolStandardID = tempId;
                schoolStandard.StandardSeatQuotos.Add(standardSeatQuoto);
            }

            await _schoolStandardService.UpdateAsync(schoolStandard);
            TempData["AlertMessage"] = "Record added successfully.";
            return RedirectToAction("Index", new { id = schoolId});
        }

        public async Task<IActionResult> Edit(int id)
        {
            SchoolStandard schoolStandard = await _schoolStandardService.GetByIdAsync(id);

            if (schoolStandard == null) return View("NotFound");
          
            TempData["SchoolStandardId"] = id;

            return Json(new { 
                intakeCapacity = schoolStandard.IntakeCapacity,
                standardId = schoolStandard.Standard.ID,
        });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SchoolStandard schoolStandard, int[] Quotos, int[] NoOfSeats)
        {
            IQueryable<StandardSeatQuoto> standardSeatQuotos = _context.StandardSeatQuotos.Where(p => p.SchoolStandardID == schoolStandard.ID);

            foreach(var item in standardSeatQuotos)
            {
                _context.StandardSeatQuotos.Remove(item);
            }

            await _context.SaveChangesAsync();

            for(int i=0; i<Quotos.Length && i<NoOfSeats.Length; i++)
            {
                StandardSeatQuoto standardSeatQuoto = new StandardSeatQuoto();
                standardSeatQuoto.SchoolStandardID = schoolStandard.ID;
                standardSeatQuoto.QuotoID = Quotos[i];
                standardSeatQuoto.NumberOfSeats = NoOfSeats[i];
                schoolStandard.StandardSeatQuotos.Add(standardSeatQuoto);
            }

            await _schoolStandardService.UpdateAsync(schoolStandard);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                IQueryable<StandardSeatQuoto> standardSeatQuotos = _context.StandardSeatQuotos.Where(p => p.SchoolStandardID == id);

                foreach (var item in standardSeatQuotos)
                {
                    _context.StandardSeatQuotos.Remove(item);
                }

                await _context.SaveChangesAsync();

                await _schoolStandardService.DeleteAsync(id);

                int schoolId = Convert.ToInt32(HttpContext.Session.GetInt32("ID"));

                TempData["AlertMessage"] = "Record deleted successfully.";
                
                return RedirectToAction("Index",schoolId);
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured while deleting the entity.");
            }
        }
    }
}
