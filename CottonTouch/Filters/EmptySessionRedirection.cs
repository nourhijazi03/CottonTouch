using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CottonTouch.Filters
{
    public class EmptySessionRedirection : System.Web.Mvc.ActionFilterAttribute, System.Web.Mvc.IActionFilter
    {
        public override void OnActionExecuting(System.Web.Mvc.ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;
            if (HttpContext.Current.Session["RoleID"] == null)
            {
                filterContext.Result = new System.Web.Mvc.RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary {
                    {"Controller","Access"},
                    {"Action","Login"}

                });
            }
            base.OnActionExecuting(filterContext);
        }
    }
}