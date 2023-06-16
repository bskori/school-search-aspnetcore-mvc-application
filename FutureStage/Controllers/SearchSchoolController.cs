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

namespace FutureStage.Controllers
{
    public class SearchSchoolController : Controller
    {
        AppDbContext _context;
        ISchoolStandardService _schoolStandardService;
        IStandardService _standardService;
        ISchoolService _schoolService;
        IAdmissionEnquiryService _admissionEnquiryService;
        public SearchSchoolController(ISchoolService schoolService, IStandardService standardService, IAdmissionEnquiryService admissionEnquiryService, ISchoolStandardService schoolStandardService, AppDbContext context)
        {
            _context = context;
            _schoolService = schoolService;
            _standardService = standardService;
            _admissionEnquiryService = admissionEnquiryService;
            _schoolStandardService = schoolStandardService;
        }

        public IActionResult GetEnquiry(int id)
        {
            int parentId = Convert.ToInt32(HttpContext.Session.GetString("ID"));
            List<SchoolStandard> schoolStandards =  _context.SchoolStandards.Where(p => p.SchoolID == id).ToList();
            if(parentId != 0)
            {
                ViewBag.ParentID = parentId;
                ViewBag.SchoolID = id;
                ViewBag.Standards = new SelectList(schoolStandards, "ID", "Standard.StandardTitle");
                return View();
            }

            return RedirectToAction("doLogin", "ManageParent");
        }

        [HttpPost]
        public async Task<IActionResult> GetEnquiry(AdmissionEnquiry admissionEnquiry)
        {
            List<SchoolStandard> schoolStandards = _context.SchoolStandards.Where(p => p.SchoolID == admissionEnquiry.SchoolID).ToList();
            if (!ModelState.IsValid)
            {
                ViewBag.ParentID = admissionEnquiry.ParentID;
                ViewBag.SchoolID = admissionEnquiry.SchoolID;
                ViewBag.Standards = new SelectList(schoolStandards, "ID", "Standard.StandardTitle");
                return View(admissionEnquiry);
            }
            
            await _context.AdmissionEnquiries.AddAsync(admissionEnquiry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(EnquirySubmitted));
        }

        public async Task<IActionResult> ExploreSchools()
        {
            return View(await _schoolService.GetAllAsync());
        }

        public IActionResult EnquirySubmitted()
        {
            return View();
        }

        public async Task<IActionResult> SchoolDetails(int id)
        {
            School school = await _schoolService.GetByIdAsync(id);
            return View(school);
        }
    }
}
