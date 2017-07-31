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

            //LogManager.LogTool.Fatal(filterContext.Controller, filterContext.Exception);


            base.OnException(filterContext);
        }

        #endregion
    }
}