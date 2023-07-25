using FutureStage.Data;
using FutureStage.Data.Services.SchoolsServices;
using FutureStage.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Areas.Schools.Controllers
{
    [Area("Schools")]
    [Authorize]
    public class EnquiryController : Controller
    {
        private readonly IAdmissionEnquiryService _admissionEnquiryService;
        private readonly IAdmissionConfirmationService _admissionConfirmationService;
        private readonly AppDbContext _context;

        public EnquiryController(IAdmissionEnquiryService admissionEnquiryService, AppDbContext context, IAdmissionConfirmationService admissionConfirmationService)
        {
            _admissionEnquiryService = admissionEnquiryService;
            _admissionConfirmationService = admissionConfirmationService;
            _context = context;
        }

        public IActionResult NewEnquiry(int id)
        {
            ViewBag.AdmissionEnquiries = _context.AdmissionEnquiries.Where(ae => ae.SchoolID.Equals(id)).ToList();
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmEnquiry(AdmissionEnquiry admissionEnquiry)
        {
            AdmissionConfirmation admissionConfirmation = new AdmissionConfirmation
            {
                AdmissionEnquiryID = admissionEnquiry.ID,
                ConfirmationDate = DateTime.Now.Date,
                Remark = true
            };

            await _admissionConfirmationService.AddAsync(admissionConfirmation);
            int schoolId = Convert.ToInt32(HttpContext.Session.GetInt32("ID"));
            TempData["AlertMessage"] = "Enquiry confirmed successfully.";
            return RedirectToAction("NewEnquiry", new { id = schoolId });
        }


        public IActionResult ConfirmedEnquires(int id)
        {
            List<AdmissionConfirmation> admissionConfirmations = _context.AdmissionConfirmations.Where(ac => ac.AdmissionEnquiry.SchoolID == id && ac.Remark == true).ToList();
            return View(admissionConfirmations);
        }

        public IActionResult ConfirmedEnquiryDetails(int id)
        {
            var enquiryDetails = _context.AdmissionConfirmations.Where(ac => ac.AdmissionEnquiryID == id).SingleOrDefault();

            if (enquiryDetails == null) return View("NotFound");

            return Json(new
            {
                enquirerName = enquiryDetails.AdmissionEnquiry.Parent.Name,
                enquiryDate = enquiryDetails.AdmissionEnquiry.EnquiryDate.ToString("dd-MM-yyyy"),
                forClass = enquiryDetails.AdmissionEnquiry.SchoolStandard.Standard.StandardName,
                enquirerEmail = enquiryDetails.AdmissionEnquiry.Parent.EmailID,
                enquirerContact = enquiryDetails.AdmissionEnquiry.Parent.MobileNo,
                confirmedDate = enquiryDetails.ConfirmationDate.ToString("dd-MM-yyyy")
            });
        }
    }
}
