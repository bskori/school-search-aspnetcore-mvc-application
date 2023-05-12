using FutureStage.Data.Base;
using FutureStage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Data.Services.SiteAdminServices
{
    public class FacilityService : EntityBaseRepository<Facility>, IFacilityService
    {
        public FacilityService(AppDbContext context) : base(context) { }
    }
}
