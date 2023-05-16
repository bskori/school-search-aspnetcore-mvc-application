using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Data.CustomFilter
{
    public class SiteAdminAuthorization : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if(context.HttpContext.Session.GetString("ID") == null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    Action = "doLogin",
                    Controller = "ManageSiteAdmin",
                    Area = ""
                }));
            }
        }
    }
}
