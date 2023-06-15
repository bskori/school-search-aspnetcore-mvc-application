using FutureStage.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Data.ViewComponents
{
    public class EditQuotoVC : ViewComponent
    {
        private readonly AppDbContext _context;
        public EditQuotoVC(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke(int id)
        {
            var rec = from t in _context.Quotos
                      select new QuotoVM
                      {
                          Value = t.ID,
                          Text = t.QuotoTitle,
                          Selected = _context.StandardSeatQuotos.Where(p => p.SchoolStandardID == id).Any(p => p.QuotoID == t.ID),
                          NoOfSeats = _context.StandardSeatQuotos.Where(p => p.QuotoID == t.ID).Select(p => p.NumberOfSeats).SingleOrDefault()
                      };
            return View(rec.ToList());
        }
    }
}
