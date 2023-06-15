using FutureStage.Data.Base;
using FutureStage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Data.Services.SiteAdminServices
{
    public class QuotaService : EntityBaseRepository<Quoto>, IQuotaService
    {
        public QuotaService(AppDbContext context):base(context)
        {

        }
    }
}
