using FutureStage.Data.CustomFilter;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Areas.SiteAdmin.Controllers
{
    [Area("SiteAdmin")]
    [SiteAdminAuthorization]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
