using FutureStage.Data.Base;
using FutureStage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Data.Services.SchoolsServices
{
    public class SchoolFacilityService : EntityBaseRepository<SchoolFacility>, ISchoolFacilityService
    {
        public SchoolFacilityService(AppDbContext context):base(context)
        {

        }
    }
}
