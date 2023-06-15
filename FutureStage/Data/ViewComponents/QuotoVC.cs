using FutureStage.Data.ViewModels;
using FutureStage.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Data.ViewComponents
{
    public class QuotoVC : ViewComponent
    {
        AppDbContext _context;
        public QuotoVC(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var data = from t in _context.Quotos
                       select new QuotoVM
                       {
                           Selected = false,
                           Value = t.ID,
                           Text = t.QuotoTitle
                       };
            return View(data.ToList());
        }
    }
}
