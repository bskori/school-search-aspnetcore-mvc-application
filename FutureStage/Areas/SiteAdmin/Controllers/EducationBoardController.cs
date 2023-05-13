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
    [SiteAdminAuthorization]
    public class EducationBoardController : Controller
    {
        IEducationBoardService _service;
        public EducationBoardController(IEducationBoardService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allEducationBoards = await _service.GetAllAsync();
            return View(allEducationBoards);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EducationBoard educationBoard)
        {
            if (!ModelState.IsValid)
            {
                return View(educationBoard);
            }

            await _service.AddAsync(educationBoard);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            EducationBoard educationBoard = await _service.GetByIdAsync(id);

            if (educationBoard == null) return View("NotFound");
            return View(educationBoard);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EducationBoard educationBoard)
        {
            if (!ModelState.IsValid)
            {
                return View(educationBoard);
            }

            await _service.UpdateAsync(educationBoard);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            EducationBoard educationBoard = await _service.GetByIdAsync(id);

            if (educationBoard == null) return View("NotFound");

            return View(educationBoard);
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
