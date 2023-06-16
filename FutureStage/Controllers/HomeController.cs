using FutureStage.Data.Services.SchoolsServices;
using FutureStage.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Controllers
{
    public class HomeController : Controller
    {
        ISchoolService _schoolService;
        public HomeController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
