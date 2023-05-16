using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Controllers
{
    public class ManageSchoolsController : Controller
    {

        public IActionResult doLogin()
        {
            return View();
        }
    }
}
