<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Mvc;
=======
﻿using FutureStage.Data.Services.SchoolsServices;
using Microsoft.AspNetCore.Mvc;
>>>>>>> Fixing_Merged_Issue
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Data.ViewComponents
{
    public class PopularSchoolsVC : ViewComponent
    {
<<<<<<< HEAD
        private readonly AppDbContext _context;
        public PopularSchoolsVC(AppDbContext context)
        {
=======
        private readonly ISchoolService _schoolService;
        private readonly AppDbContext _context;
        public PopularSchoolsVC(AppDbContext context ,ISchoolService schoolService)
        {
            _schoolService = schoolService;
>>>>>>> Fixing_Merged_Issue
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
<<<<<<< HEAD
            var popularSchools = _context.Schools.Take(20).ToList();
            return View(popularSchools);
=======
            return View(_context.Schools.ToList());
>>>>>>> Fixing_Merged_Issue
        }
    }
}
