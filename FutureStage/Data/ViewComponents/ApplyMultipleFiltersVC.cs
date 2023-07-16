
﻿using FutureStage.Data.Services.SiteAdminServices;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Data.ViewComponents
{
    public class ApplyMultipleFiltersVC : ViewComponent
    {
        private readonly IEducationBoardService _educationBoardService;
        private readonly ICityService _cityService;
        private readonly IAreaService _areaService;
        private readonly IStandardService _standardService;
        private readonly AppDbContext _context;

        public ApplyMultipleFiltersVC(IStandardService standardService, IEducationBoardService educationBoardService, ICityService cityService, IAreaService areaService, AppDbContext context)
        {
            _educationBoardService = educationBoardService;
            _cityService = cityService;
            _areaService = areaService;
            _standardService = standardService;
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
