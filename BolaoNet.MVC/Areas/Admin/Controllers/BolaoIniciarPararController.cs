using AutoMapper;
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


        public ActionResult Iniciar()
        {
            bool res = _bolaoApp.Iniciar(base.UserLogged, base.SelectedBolao);


            return RedirectToAction("Index");
        }
        public ActionResult Aguardar()
        {

            bool res = _bolaoApp.Aguardar(base.SelectedBolao);

            return RedirectToAction("Index");
        }
        public ActionResult Index()
        {
            //ViewModels.Admin.BolaoIniciarPararViewModel model = new ViewModels.Admin.BolaoIniciarPararViewModel();


            Domain.Entities.Boloes.Bolao bolaoLoaded =  _bolaoApp.Load(base.SelectedBolao);


            ViewModels.Admin.BolaoIniciarPararViewModel model =
                 Mapper.Map<Domain.Entities.Boloes.Bolao, ViewModels.Admin.BolaoIniciarPararViewModel>(bolaoLoaded);



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