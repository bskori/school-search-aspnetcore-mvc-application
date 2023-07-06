using FutureStage.Data.Services.SchoolsServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Data.ViewComponents
{
    public class PopularSchoolsVC : ViewComponent
    {
        private readonly ISchoolService _schoolService;
        private readonly AppDbContext _context;
        public PopularSchoolsVC(AppDbContext context ,ISchoolService schoolService)
        {
            _schoolService = schoolService;
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            return View(_context.Schools.ToList());
        }
    }
}
