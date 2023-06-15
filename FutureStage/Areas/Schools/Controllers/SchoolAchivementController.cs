using FutureStage.Data.Services.SchoolsServices;
using FutureStage.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Areas.Schools.Controllers
{
    [Area("Schools")]
    public class SchoolAchivementController : Controller
    {
        ISchoolAchivementService _schoolAchivementService;
        public SchoolAchivementController(ISchoolAchivementService schoolAchivementService)
        {
            _schoolAchivementService = schoolAchivementService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _schoolAchivementService.GetAllAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SchoolAchivement schoolAchivement)
        {
            if (!ModelState.IsValid)
            {
                return View(schoolAchivement);
            }
            schoolAchivement.SchoolID = Convert.ToInt32(HttpContext.Session.GetString("ID"));
            await _schoolAchivementService.AddAsync(schoolAchivement);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            SchoolAchivement schoolAchivement = await _schoolAchivementService.GetByIdAsync(id);

            if (schoolAchivement == null) return View("NotFound");
            return View(schoolAchivement);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SchoolAchivement schoolAchivement)
        {
            if (!ModelState.IsValid)
            {
                return View(schoolAchivement);
            }

            await _schoolAchivementService.UpdateAsync(schoolAchivement);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            SchoolAchivement schoolAchivement = await _schoolAchivementService.GetByIdAsync(id);

            if (schoolAchivement == null) return View("NotFound");

            return View(schoolAchivement);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _schoolAchivementService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
