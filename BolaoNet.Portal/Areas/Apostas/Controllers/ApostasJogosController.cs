using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.Portal.Areas.Apostas.Controllers
{
    public class ApostasJogosController : Controller
    {
        #region Actions

        public ActionResult Grupo()
        {
            return View();
        }
        public ActionResult Fase()
        {
            return View();
        }

        #endregion
    }
}