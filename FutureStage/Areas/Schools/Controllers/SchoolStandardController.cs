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

        public async Task<IActionResult> Index()
        {           
            return View(await _schoolStandardService.GetAllAsync());
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Standards = new SelectList(await _standardService.GetAllAsync(), "ID", "StandardTitle");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SchoolStandard schoolStandard, int[] Quotos, int[] NoOfSeats)
        {
            schoolStandard.SchoolID = Convert.ToInt32(HttpContext.Session.GetString("ID"));
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

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            SchoolStandard schoolStandard = await _schoolStandardService.GetByIdAsync(id);

            if (schoolStandard == null) return View("NotFound");

            ViewBag.Standards = new SelectList(await _standardService.GetAllAsync(), "ID", "StandardTitle");

            return View(schoolStandard);
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

        public  async Task<IActionResult> Delete(int id)
        {
            SchoolStandard schoolStandard = await _schoolStandardService.GetByIdAsync(id);

            if (schoolStandard == null) return View("NotFound");

            return View(schoolStandard);
        }

        [ActionName("Delete")]
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            IQueryable<StandardSeatQuoto> standardSeatQuotos =  _context.StandardSeatQuotos.Where(p => p.SchoolStandardID == id);

            foreach(var item in standardSeatQuotos)
            {
                _context.StandardSeatQuotos.Remove(item);
            }

            await _context.SaveChangesAsync();

            await _schoolStandardService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
