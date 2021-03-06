﻿using BolaoNet.Domain.Interfaces.Services.Logging;
using BolaoNet.MVC.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Controllers
{
    public abstract class BaseController : Controller
    {
        #region Properties

        protected Helpers.PersistenceProviders.PersistenceProvider Persist { get; set; }

        #endregion

        #region Properties

        public string Environment
        {
            get
            {
                string env = "";
                if (Session["EnvironmentDescription"] == null)
                {
                    env = System.Configuration.ConfigurationManager.AppSettings["EnvironmentDescription"];
                    Session["EnvironmentDescription"] = env;
                }
                else
                    env = Session["EnvironmentDescription"].ToString();

                return env;
            }
        }

        #endregion

        #region Constructors/Destructors

        public BaseController ()
        {

            this.Persist = new Helpers.PersistenceProviders.PersistenceProvider(this);

        }
        #endregion

        #region Methods
        
        /// <summary>
        /// Método que aplica novo idioma ao sistema.
        /// </summary>
        /// <param name="culture">Cultura que deve ser aplicada.</param>
        public void SetCulture(string culture)
        {
            //Verificando se a cultura é válida
            culture = CultureHelper.GetImplementedCulture(culture);

            //Armazena na requisição a cultura válida
            HttpCookie cookie = Request.Cookies["_culture"];
            if (cookie != null)
                cookie.Value = culture;   //Atualiza o cookie
            else
            {
                cookie = new HttpCookie("_culture");
                cookie.Value = culture;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);
        }
            
        #endregion

        #region Events

        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {

            string cultureName = null;

            // Tenta fazer a leitura do cabeçalho da requisição 
            HttpCookie cultureCookie = Request.Cookies["_culture"];
            if (cultureCookie != null)
                cultureName = cultureCookie.Value;
            else
                cultureName = Request.UserLanguages != null && Request.UserLanguages.Length > 0 ?
                        Request.UserLanguages[0] : null;
            // Busca o nome válido da cultura
            cultureName = CultureHelper.GetImplementedCulture(cultureName);

            // Modifica a thread corrente com o nome da cultura
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultureName);
            //Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(cultureName);

            return base.BeginExecuteCore(callback, state);
        }
        public ActionResult Ajuda(string controllerName, string controllerAction, string lang)
        {
            string idiomaPadrao = "pt-BR";

            string language = lang;

            //Se não possui nenhum idioma selecionado, utiliza-se padrão brasileiro
            if (string.IsNullOrEmpty(language))
                language = idiomaPadrao;

            if (!System.IO.Directory.Exists(Server.MapPath("~/Ajuda/" + language)))
                language = idiomaPadrao;


            string caminhoCompleto = Server.MapPath("~/Ajuda/" + language + "/");

            if (!string.IsNullOrEmpty(controllerName) && !string.IsNullOrEmpty(controllerAction))
                caminhoCompleto += controllerName + "/" + controllerAction + ".html";

            if (!System.IO.File.Exists(caminhoCompleto))
                caminhoCompleto = Server.MapPath("~/Ajuda/" + language + "/Default.html");

            Response.Charset = "iso-8859-1";
            return new FilePathResult(caminhoCompleto, "text/html");

        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

        }
        //protected override void OnException(ExceptionContext filterContext)
        //{
        //    Exception ex = filterContext.Exception;
        //    filterContext.ExceptionHandled = true;

        //    ILogging logging = DependencyResolver.Current.GetService<ILogging>();

        //    logging.Fatal(this, filterContext.Exception);

        //    var model = new HandleErrorInfo(filterContext.Exception, "Controller", "Action");

        //    //filterContext.Result = RedirectToAction("Index", "ErrorHandler", new { area = ""});
        //    //filterContext.Result = new ViewResult
        //    //{
        //    //    ViewName = "~/Views/Shared/Error.cshtml"
        //    //};

        //    filterContext.Result = new ViewResult()
        //    {
        //        ViewName = "~/Views/Shared/Error.cshtml",
        //        ViewData = new ViewDataDictionary(model)
        //    };



        //  //  base.OnException(filterContext);
        //}

        #endregion
    }
}