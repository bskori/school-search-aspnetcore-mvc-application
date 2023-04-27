using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Areas.SiteAdmin.Controllers
{
    public class StateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
