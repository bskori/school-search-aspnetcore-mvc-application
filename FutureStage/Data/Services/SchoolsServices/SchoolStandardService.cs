using FutureStage.Data.Base;
using FutureStage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Data.Services.SchoolsServices
{
    public class SchoolStandardService : EntityBaseRepository<SchoolStandard>, ISchoolStandardService
    {
        public SchoolStandardService(AppDbContext context):base(context)
        {

        }
    }
}
