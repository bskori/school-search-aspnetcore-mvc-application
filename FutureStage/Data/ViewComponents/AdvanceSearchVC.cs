using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Data.ViewComponents
{
    public class AdvanceSearchVC : ViewComponent
    {
        private readonly AppDbContext _context;
        public AdvanceSearchVC(AppDbContext context)
        {
            _context = context;
        }
       public IViewComponentResult Invoke()
        {
            ViewBag.States = _context.States.ToList(); 
            ViewBag.Cities = _context.Cities.ToList(); 
            ViewBag.Areas = _context.Areas.ToList();
            return View();
        }
    }
}
