using FutureStage.Data;
using FutureStage.Data.Services.SchoolsServices;
using FutureStage.Data.Services.SiteAdminServices;
using FutureStage.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Controllers
{
    public class SearchSchoolController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ISchoolStandardService _schoolStandardService;
        private readonly ISchoolService _schoolService;
        private readonly IAdmissionEnquiryService _admissionEnquiryService;
        public SearchSchoolController(ISchoolService schoolService, IAdmissionEnquiryService admissionEnquiryService, AppDbContext context, ISchoolStandardService schoolStandardService)
        {
            _context = context;
            _schoolService = schoolService;
            _admissionEnquiryService = admissionEnquiryService;
            _schoolStandardService = schoolStandardService;
        }

        public IActionResult GetEnquiry(int id)
        {
            int parentId = Convert.ToInt32(HttpContext.Session.GetInt32("ID"));
            List<SchoolStandard> schoolStandards =  _context.SchoolStandards.Where(p => p.SchoolID == id).ToList();
            if(parentId != 0)
            {
                ViewBag.ParentID = parentId;
                ViewBag.SchoolID = id;
                ViewBag.Standards = new SelectList(schoolStandards, "ID", "Standard.StandardName");
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

        public IActionResult ExploreSchools(int StateId, int CityId, int AreaId)
        {
            
            List<School> schools = new List<School>();

            if (StateId != 0 && CityId == 0 && AreaId == 0)
            {
                schools = _context.Schools.Where(s => s.Area.City.StateID == StateId).ToList();
            }else if (CityId != 0 && AreaId == 0)
            {
                schools = _context.Schools.Where(s => s.Area.CityID == CityId).ToList();
            }else if(AreaId != 0)
            {
                schools = _context.Schools.Where(s => s.AreaID == AreaId).ToList();
            }else
            {
                schools = _context.Schools.ToList();
            }

            return View(schools);
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


        public async Task<IActionResult> SchoolSearch(string searchString)
        {
            var allSchools = await _schoolService.GetAllAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allSchools.Where(s => s.Name.Contains(searchString)).ToList();
                if(filteredResult.Count > 0)
                {
                    return View("ExploreSchools", filteredResult);
                }
            }

            return View("ExploreSchools", allSchools);
        }

        public async Task<IActionResult> ApplyMultipleFilters(int boardId, int cityId, int areaId, int monthlyFees, int standardId)
        {
            IEnumerable<School> schools = await _schoolService.GetAllAsync();
            if(boardId > 0)
            {
                schools = schools.Where(s => s.School_EducationBoards.Any(seb => seb.EducationBoard.ID == boardId)).ToList();
            }
            if(cityId > 0)
            {
                schools = schools.Where(s => s.Area.CityID == cityId).ToList();
            }
            if(areaId > 0)
            {
                schools = schools.Where(s => s.AreaID == areaId).ToList();
            }
            if(standardId > 0)
            {
                schools = schools.Where(s => s.SchoolStandards.Any(s => s.Standard.ID == standardId)).ToList();
            }
            if(monthlyFees > 0)
            {
                if(monthlyFees == 1)
                {
                    schools = schools.Where(s => s.SchoolStandards.Any(ss => ss.StandardFees.Any(fee => fee.Amount >= 0 && fee.Amount <= 3000))).ToList();
                }else if (monthlyFees == 2)
                {
                    schools = schools.Where(s => s.SchoolStandards.Any(ss => ss.StandardFees.Any(fee => fee.Amount >= 3000 && fee.Amount <= 6000))).ToList();
                }else if (monthlyFees == 3)
                {
                    schools = schools.Where(s => s.SchoolStandards.Any(ss => ss.StandardFees.Any(fee => fee.Amount >= 6000 && fee.Amount <= 10000))).ToList();
                }else if (monthlyFees == 4)
                {
                    schools = schools.Where(s => s.SchoolStandards.Any(ss => ss.StandardFees.Any(fee => fee.Amount >= 10000 && fee.Amount <= 15000))).ToList();
                }else
                {
                    schools = schools.Where(s => s.SchoolStandards.Any(ss => ss.StandardFees.Any(fee => fee.Amount >= 15000))).ToList();
                }
            }
            
            return View("ExploreSchools", schools);
        }

    }
}
