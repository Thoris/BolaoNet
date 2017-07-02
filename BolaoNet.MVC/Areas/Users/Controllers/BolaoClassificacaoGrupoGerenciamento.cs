using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Users.Controllers
{
    public class BolaoClassificacaoGrupoGerenciamento : BaseUserAreaController
    {
        #region Constructors/Destructors

        public BolaoClassificacaoGrupoGerenciamento()
        {

        }

        #endregion

        #region Actions

        public ActionResult Index()
        {
            return View();
        }

        #endregion
    }
}