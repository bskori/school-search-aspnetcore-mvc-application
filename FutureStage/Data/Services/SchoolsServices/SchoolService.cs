using FutureStage.Data.Base;
using FutureStage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Data.Services.SchoolsServices
{
    public class SchoolService : EntityBaseRepository<School>, ISchoolService
    {
        public SchoolService(AppDbContext context) : base(context)
        {

        }
    }
}
