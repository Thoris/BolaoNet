using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Admin.Controllers
{
    public class BolaoIniciarPararController: BaseAdminAreaController
    {
        #region Constructors/Destructors

        public BolaoIniciarPararController(
            Application.Interfaces.Boloes.IBolaoMembroApp bolaoMembroApp,
            Application.Interfaces.Boloes.IBolaoApp bolaoApp,
            Application.Interfaces.Campeonatos.ICampeonatoApp campeonatoApp,
            Application.Interfaces.Campeonatos.ICampeonatoFaseApp campeonatoFaseApp,
            Application.Interfaces.Campeonatos.ICampeonatoGrupoApp campeonatoGrupoApp,
            Application.Interfaces.Campeonatos.ICampeonatoTimeApp campeonatoTimeApp
            )
            : base (bolaoMembroApp, bolaoApp, campeonatoApp, campeonatoFaseApp, campeonatoGrupoApp, campeonatoTimeApp)
        {
            
        }

        #endregion

        #region Actions

        public ActionResult Index()
        {
            ViewModels.Admin.BolaoIniciarPararViewModel model = new ViewModels.Admin.BolaoIniciarPararViewModel();

            model.StatusMembros = new List<ViewModels.Admin.BolaoIniciarStatusMembroViewModel>();
            model.StatusMembros.Add(new ViewModels.Admin.BolaoIniciarStatusMembroViewModel()
                {
                    UserName = "teste",
                    FullName = "thoris angelo",
                    TotalApostasRestantes = 2,
                    Email = "thorisa@hotmail.com"
                });


            return View(model);
        }

        #endregion
    }
}