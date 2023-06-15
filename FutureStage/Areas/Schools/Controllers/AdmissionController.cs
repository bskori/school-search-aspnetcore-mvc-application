using FutureStage.Data;
using FutureStage.Data.Services.SchoolsServices;
using FutureStage.Data.ViewModels;
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
    public class AdmissionController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IAdmissionPrerequisiteService _admissionPrerequisiteService;
        private readonly IAdmissionProcessService _admissionProcessService;
        private readonly ISchoolStandardService _schoolStandardService;

        public AdmissionController(IAdmissionPrerequisiteService admissionPrerequisiteService, IAdmissionProcessService admissionProcessService, ISchoolStandardService schoolStandardService, AppDbContext context)
        {
            _context = context;
            _admissionPrerequisiteService = admissionPrerequisiteService;
            _admissionProcessService = admissionProcessService;
            _schoolStandardService = schoolStandardService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _admissionPrerequisiteService.GetAllAsync());
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.SchoolStandards = new SelectList(await _schoolStandardService.GetAllAsync(),"ID","Standard.StandardTitle");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AdmissionVM admissionVM)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.SchoolStandards = new SelectList(await _schoolStandardService.GetAllAsync(), "ID", "Standard.StandardTitle");
                return View(admissionVM);
            }

            AdmissionPrerequisite admissionPrerequisite = new AdmissionPrerequisite()
            {
                SchoolStandardID = admissionVM.SchoolStandardID,
                PrerequisiteTitle = admissionVM.PrequisiteTitle,
                PrerequisiteDescription = admissionVM.PrerequisiteDescription
            };

            AdmissionProcess admissionProcess = new AdmissionProcess()
            {
                SchoolStandardID = admissionVM.SchoolStandardID,
                ProcessTitle = admissionVM.ProcessTitle,
                ProcessDescription = admissionVM.ProcessDescription
            };
            
            await _admissionPrerequisiteService.AddAsync(admissionPrerequisite);
            await _admissionProcessService.AddAsync(admissionProcess);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            AdmissionPrerequisite admissionPrerequisite = _context.AdmissionPrerequisites.Where(p => p.SchoolStandardID == id).FirstOrDefault();
            AdmissionProcess admissionProcess = _context.AdmissionProcesses.Where(p => p.SchoolStandardID == id).FirstOrDefault();

            ViewBag.SchoolStandards = new SelectList(await _schoolStandardService.GetAllAsync(), "ID", "Standard.StandardTitle");

            AdmissionVM admissionVM = new AdmissionVM()
            {
                SchoolStandardID = admissionPrerequisite.SchoolStandardID,
                PrequisiteTitle = admissionPrerequisite.PrerequisiteTitle,
                PrerequisiteDescription = admissionPrerequisite.PrerequisiteDescription,
                ProcessTitle = admissionProcess.ProcessTitle,
                ProcessDescription = admissionProcess.ProcessDescription
            };

            return View(admissionVM); 
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AdmissionVM admissionVM)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.SchoolStandards = new SelectList(await _schoolStandardService.GetAllAsync(), "ID", "Standard.StandardTitle");
                return View(admissionVM);
            }

            int admissionProcessID =  _context.AdmissionProcesses.Where(p => p.SchoolStandardID == admissionVM.SchoolStandardID).Select(p => p.ID).FirstOrDefault();
            int admissionPrerequisiteID = _context.AdmissionPrerequisites.Where(p => p.SchoolStandardID == admissionVM.SchoolStandardID).Select(p => p.ID).FirstOrDefault();

            AdmissionProcess admissionProcess = new AdmissionProcess()
            {
                ID = admissionProcessID,
                SchoolStandardID = admissionVM.SchoolStandardID,
                ProcessTitle = admissionVM.PrequisiteTitle,
                ProcessDescription = admissionVM.ProcessDescription
            };

            AdmissionPrerequisite admissionPrerequisite = new AdmissionPrerequisite() 
            { 
                ID = admissionPrerequisiteID,
                SchoolStandardID =admissionVM.SchoolStandardID,
                PrerequisiteTitle = admissionVM.PrequisiteTitle,
                PrerequisiteDescription = admissionVM.PrerequisiteDescription
            };

            await _admissionProcessService.UpdateAsync(admissionProcess);
            await _admissionPrerequisiteService.UpdateAsync(admissionPrerequisite);

            return RedirectToAction(nameof(Index));
        }
        
        public IActionResult Delete(int id)
        {
            AdmissionVM admissionVM = new AdmissionVM();
            admissionVM.SchoolStandardID = id;

            return View(admissionVM);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed( int id)
        {
            int admissionPrerequisiteID = _context.AdmissionPrerequisites.Where(p => p.SchoolStandardID == id).Select(p => p.ID).FirstOrDefault();
            int admissionProcessID = _context.AdmissionProcesses.Where(p => p.SchoolStandardID == id).Select(p => p.ID).FirstOrDefault();

            await _admissionPrerequisiteService.DeleteAsync(admissionPrerequisiteID);
            await _admissionProcessService.DeleteAsync(admissionProcessID);
            return RedirectToAction(nameof(Index));
        }
    }
}
