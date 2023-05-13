using FutureStage.Data.Base;
using FutureStage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Data.Services.SiteAdminServices
{
    public class StandardService : EntityBaseRepository<Standard>, IStandardService
    {
        public StandardService(AppDbContext context) : base(context) { }
    }
}
