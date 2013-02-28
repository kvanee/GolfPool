using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GolfPool.Helpers
{
    public static class HtmlExtensions
    {
        public static IEnumerable<SelectListItem> CreateSelectList<T>(this IEnumerable<T> entities, Func<T, object> valueAccessor, Func<T, string> displayAccessor)
        {
            var items = entities.ToList().Select(x => new SelectListItem
            {
                Value = valueAccessor(x).ToString(),
                Text = displayAccessor(x)
            });

            return items.ToList();
        }

        public static MvcHtmlString ActionMenuItem(this HtmlHelper htmlHelper, string text, ActionResult result)
        {
            var routeData = htmlHelper.ViewContext.RouteData;

            var t4MVCResult = result as IT4MVCActionResult;
            if (t4MVCResult == null)
            {
                throw new InvalidOperationException("T4MVC was called incorrectly. You may need to force it to regenerate by right clicking on T4MVC.tt and choosing Run Custom Tool");
            }

            if (RoutesMatch(routeData, t4MVCResult))
            {
                return htmlHelper.ActionLink(text, result, new { @class = "selected" });
            }

            return htmlHelper.ActionLink(text, result);
        }

        public static string IsCurrentAction(this HtmlHelper htmlHelper, ActionResult result)
        {
            var routeData = htmlHelper.ViewContext.RouteData;

            var t4MVCResult = result as IT4MVCActionResult;
            if (t4MVCResult == null)
            {
                throw new InvalidOperationException("T4MVC was called incorrectly. You may need to force it to regenerate by right clicking on T4MVC.tt and choosing Run Custom Tool");
            }

            if (RoutesMatch(routeData, t4MVCResult))
            {
                return "selected";
            }

            return string.Empty;
        }

        private static bool RoutesMatch(RouteData routeData, IT4MVCActionResult t4MVCResult)
        {
            var controller = routeData.Values["controller"].ToString();
            var action = routeData.Values["action"].ToString();
            var id = routeData.Values["id"];

            var controllerMatch = controller.Equals(t4MVCResult.Controller, StringComparison.CurrentCultureIgnoreCase);
            var actionMatch = action.Equals(t4MVCResult.Action, StringComparison.CurrentCultureIgnoreCase);
            var idMatch = true;
            if (id != null && t4MVCResult.RouteValueDictionary["id"] != null)
                idMatch = id.ToString().Equals(t4MVCResult.RouteValueDictionary["id"].ToString());

            return controllerMatch && actionMatch && idMatch;
        }

        public static IEnumerable<SelectListItem> CreateSelectList<T>(this IEnumerable<T> entities, Func<T, object> valueAccessor, Func<T, string> displayAccessor, bool Order = true)
        {
            var items = entities.ToList()
                                .Select(x => new SelectListItem
                                {
                                    Value = valueAccessor(x).ToString(),
                                    Text = displayAccessor(x)
                                });
            if (Order)
                items = items
                    .OrderBy(x => x.Text)
                    .AsEnumerable();

            

            return items.Prepend(new SelectListItem()).ToList();
        }

    }
}