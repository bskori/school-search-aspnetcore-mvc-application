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
    public class HomeController : Controller
    {
        ISchoolService _schoolService;
        IAreaService _areaService;
        public HomeController(ISchoolService schoolService, IAreaService areaService)
        {
            _schoolService = schoolService;
            _areaService = areaService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SchoolProfile(int id)
        {
            School school = await _schoolService.GetByIdAsync(id);
            if (school == null) return View("NotFound");

            return View(school);
        }

        public async Task<IActionResult> UpdateSchoolProfile(int id)
        {
            School school = await _schoolService.GetByIdAsync(id);
            if (school == null) return View("NotFound");

            ViewBag.Areas = new SelectList(await _areaService.GetAllAsync(), "ID", "AreaName");

            return View(school);
        }

        [HttpPost]
        public  async Task<IActionResult> UpdateSchoolProfile(School school)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Areas = new SelectList(await _areaService.GetAllAsync(), "ID", "AreaName");
                return View(school);
            }

            await _schoolService.UpdateAsync(school);
            return RedirectToAction(nameof(Index));
        }
    }
}
