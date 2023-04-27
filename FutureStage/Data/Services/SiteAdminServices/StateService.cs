using FutureStage.Data.Base;
using FutureStage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Data.Services.SiteAdminServices
{
    public class StateService:EntityBaseRepository<State>, IStateService
    {
        public StateService(AppDbContext context) : base(context) { }
    }
}
