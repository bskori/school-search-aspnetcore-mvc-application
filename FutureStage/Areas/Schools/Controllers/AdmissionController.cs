using FutureStage.Data;
using FutureStage.Data.CustomFilter;
using FutureStage.Data.Services.SchoolsServices;
using FutureStage.Data.ViewModels;
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
    [SchoolAuthorization]
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

        public IActionResult Index(int id)
        {
            ViewBag.AdmissionPrerequisites = _context.AdmissionPrerequisites.Where(ap => ap.SchoolStandard.SchoolID == id).ToList();
            List<SchoolStandard> schoolStandards = _context.SchoolStandards.Where(ss => ss.SchoolID == id).ToList();
            ViewBag.SchoolStandards = new SelectList(schoolStandards, "ID", "Standard.StandardName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AdmissionVM admissionVM)
        {
            if (!ModelState.IsValid)
            {
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

            int schoolId = Convert.ToInt32(HttpContext.Session.GetInt32("ID"));
            TempData["AlertMessage"] = "Record added successfully.";
            return RedirectToAction("Index", new { id = schoolId});
        }

        public IActionResult Edit(int id)
        {
            AdmissionPrerequisite admissionPrerequisite = _context.AdmissionPrerequisites.Where(p => p.ID == id).FirstOrDefault();
            AdmissionProcess admissionProcess = _context.AdmissionProcesses.Where(p => p.ID == id).FirstOrDefault();

            return Json(new
            {
                prerequisiteAndProcessId = id,
                schoolStandardId = admissionPrerequisite.SchoolStandardID,
                prequisiteTitle = admissionPrerequisite.PrerequisiteTitle,
                prerequisiteDescription = admissionPrerequisite.PrerequisiteDescription,
                processTitle = admissionProcess.ProcessTitle,
                processDescription = admissionProcess.ProcessDescription
            }) ; 
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AdmissionVM admissionVM)
        {
            if (!ModelState.IsValid)
            { 
                return View(admissionVM);
            }

            AdmissionProcess admissionProcess = new AdmissionProcess()
            {
                ID = admissionVM.PrerequisiteAndProcessID,
                SchoolStandardID = admissionVM.SchoolStandardID,
                ProcessTitle = admissionVM.PrequisiteTitle,
                ProcessDescription = admissionVM.ProcessDescription
            };

            AdmissionPrerequisite admissionPrerequisite = new AdmissionPrerequisite() 
            { 
                ID = admissionVM.PrerequisiteAndProcessID,
                SchoolStandardID =admissionVM.SchoolStandardID,
                PrerequisiteTitle = admissionVM.PrequisiteTitle,
                PrerequisiteDescription = admissionVM.PrerequisiteDescription
            };

            await _admissionProcessService.UpdateAsync(admissionProcess);
            await _admissionPrerequisiteService.UpdateAsync(admissionPrerequisite);
            int schoolId = Convert.ToInt32(HttpContext.Session.GetInt32("ID"));
            TempData["AlertMessage"] = "Record updated successfully";
            return RedirectToAction("Index", new { id = schoolId});
        }
        
      

        [HttpPost]
        public async Task<IActionResult> Delete( int PrerequisiteAndProcessID)
        {
            try
            { 
                await _admissionPrerequisiteService.DeleteAsync(PrerequisiteAndProcessID);
                await _admissionProcessService.DeleteAsync(PrerequisiteAndProcessID);
                int schoolId = Convert.ToInt32(HttpContext.Session.GetInt32("ID"));
                TempData["AlertMessage"] = "Record deleted successfully.";
                return RedirectToAction("Index", new { id = schoolId });
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured while deleting the entity.");
            }
        }
    }
}
