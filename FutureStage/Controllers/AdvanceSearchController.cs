using FutureStage.Data;
using FutureStage.Data.ViewModels;
using FutureStage.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Controllers
{
    public class AdvanceSearchController : Controller
    {
        private readonly AppDbContext _context;
        public AdvanceSearchController(AppDbContext context)
        {
            _context = context;
        }

       

        public IActionResult LoadCities(int stateId)
        {
            var cities = _context.Cities.Where(c => c.StateID == stateId).Select(city => new
            {
                cityId = city.ID,
                cityName = city.CityName
            }).ToList();
            return Json(cities);
        }

        public IActionResult LoadAreas(int cityId)
        {
            var areas = _context.Areas.Where(c => c.CityID == cityId).Select(area => new
            {
                areaId = area.ID,
                areaName = area.AreaName
            }).ToList();
            return Json(areas);
        }

        
    }
}
