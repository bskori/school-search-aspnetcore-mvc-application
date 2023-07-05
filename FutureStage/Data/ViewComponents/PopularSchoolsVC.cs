using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Data.ViewComponents
{
    public class PopularSchoolsVC : ViewComponent
    {
        private readonly AppDbContext _context;
        public PopularSchoolsVC(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var popularSchools = _context.Schools.Take(20).ToList();
            return View(popularSchools);
        }
    }
}
