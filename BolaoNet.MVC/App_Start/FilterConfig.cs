using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new Helpers.CustomHandleErrorAttribute());
            //filters.Add(new Security.AuthenticationFilterAttribute());
        }
    }
}
