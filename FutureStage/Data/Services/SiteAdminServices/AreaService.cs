using FutureStage.Data.Base;
using FutureStage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Data.Services.SiteAdminServices
{
    public class AreaService : EntityBaseRepository<Area>, IAreaService
    {
        public AreaService(AppDbContext context) : base(context) { }
    }
}
