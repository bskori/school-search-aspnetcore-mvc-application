using FutureStage.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Controllers
{
    public class ManageSiteAdminController : Controller
    {
        private readonly AppDbContext _context;
        public ManageSiteAdminController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult doLogin()
        {
            return View();
        }


    }
}
