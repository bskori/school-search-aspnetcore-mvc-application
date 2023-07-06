using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Data.ViewComponents
{
    public class ApplyMultipleFiltersVC : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
