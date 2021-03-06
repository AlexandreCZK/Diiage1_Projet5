using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Groupe1.Webzine.WebApplication.Filters
{
    public class TracerActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            logger.Debug(" " + filterContext.HttpContext.Request.Host.Value + " SORTIE " + filterContext.Controller);
            

        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            logger.Debug(" " + filterContext.HttpContext.Request.Host.Value + " ENTREE " + filterContext.ActionDescriptor.DisplayName);
        }
    }
}
