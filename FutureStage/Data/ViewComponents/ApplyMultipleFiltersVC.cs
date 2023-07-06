using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Data.ViewComponents
{
    public class ApplyMultipleFiltersVC : ViewComponent
    {
        private readonly AppDbContext _context;
        public ApplyMultipleFiltersVC(AppDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.Boards = _context.EducationBoards.ToList();
            ViewBag.Cities = _context.Cities.ToList();
            ViewBag.Areas = _context.Areas.ToList();
            ViewBag.States = _context.States.ToList();
            ViewBag.Standards = _context.Standards.ToList();
            return View();
        }

    }
}
