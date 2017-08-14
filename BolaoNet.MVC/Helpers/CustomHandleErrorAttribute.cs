using BolaoNet.Domain.Interfaces.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Helpers
{
    public class CustomHandleErrorAttribute : HandleErrorAttribute
    {
        #region Eventos

        /// <summary>
        /// Evento iniciado quando uma exceção ocorrer.
        /// </summary>
        /// <param name="filterContext">Filtro do contexto que gerou a exceção..</param>
        public override void OnException(ExceptionContext filterContext)
        {

               Exception ex = filterContext.Exception;
               filterContext.ExceptionHandled = true;

               ILogging logging = DependencyResolver.Current.GetService<ILogging>();

               logging.Fatal(this, filterContext.Exception);


               string controllerName = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
               string controllerAction = HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString();
               string controllerArea = null;
               if (HttpContext.Current.Request.RequestContext.RouteData.DataTokens["area"] != null)
               {
                   controllerArea = HttpContext.Current.Request.RequestContext.RouteData.DataTokens["area"].ToString();
               }


               var model = new HandleErrorInfo(filterContext.Exception, controllerName, controllerAction);

               //filterContext.Result = RedirectToAction("Index", "ErrorHandler", new { area = ""});
               //filterContext.Result = new ViewResult
               //{
               //    ViewName = "~/Views/Shared/Error.cshtml"
               //};

               filterContext.Result = new ViewResult()
               {
                   ViewName = "~/Views/Shared/Error.cshtml",
                   ViewData = new ViewDataDictionary(model)
               };

            //base.OnException(filterContext);
        }

        #endregion
    }
}