using FutureStage.Data.Base;
using FutureStage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Data.Services.SchoolsServices
{
    public class StandardFeesService : EntityBaseRepository<StandardFees>, IStandardFeesService
    {
        public StandardFeesService(AppDbContext context):base(context)
        {

        }
    }
}
