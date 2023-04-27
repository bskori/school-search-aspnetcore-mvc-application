using FutureStage.Models;
using FutureStage.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Data.Services.SiteAdminServices
{
    public interface ICountryService: IEntityBaseRepository<Country>
    {
    }
}
