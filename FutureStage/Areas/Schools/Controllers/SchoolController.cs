﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Areas.Schools.Controllers
{
    public class SchoolController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
