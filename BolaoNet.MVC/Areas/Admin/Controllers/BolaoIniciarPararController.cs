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

            base.IsBolaoIniciado = true;

            return RedirectToAction("Index");
        }
        public ActionResult Aguardar()
        {

            bool res = _bolaoApp.Aguardar(base.SelectedBolao);

            base.IsBolaoIniciado = false;

            return RedirectToAction("Index");
        }
        public ActionResult Index()
        {
            
            Domain.Entities.Boloes.Bolao bolaoLoaded =  _bolaoApp.Load(base.SelectedBolao);


            ViewModels.Admin.BolaoIniciarPararViewModel model =
                 Mapper.Map<Domain.Entities.Boloes.Bolao, ViewModels.Admin.BolaoIniciarPararViewModel>(bolaoLoaded);



            model.StatusMembros = new List<ViewModels.Admin.BolaoIniciarStatusMembroViewModel>();


            IList<Domain.Entities.ValueObjects.UserMembroStatusVO> listMembros =
                _bolaoMembroApp.GetUserStatus(base.SelectedBolao);


            IList<ViewModels.Admin.BolaoIniciarStatusMembroViewModel> membrosModel =
                 Mapper.Map<
                 IList<Domain.Entities.ValueObjects.UserMembroStatusVO>, 
                 IList<ViewModels.Admin.BolaoIniciarStatusMembroViewModel>>
                 (listMembros);


            for (int c = 0; c < membrosModel.Count; c++ )
            {
                if (membrosModel[c].Pago != 0)
                {
                    membrosModel[c].FaltaPagamento = true;
                }

                if (membrosModel[c].Restantes > 0)
                {
                    membrosModel[c].ApostasRestantes = true;
                }
            }

            model.StatusMembros = membrosModel;



            return View(model);
        }
        public ActionResult RemoverMembro(ViewModels.Admin.BolaoIniciarStatusMembroViewModel model)
        {
            if (string.IsNullOrEmpty(model.UserName))
            {
                _bolaoMembroApp.RemoverMembroBolao(base.SelectedBolao, new Domain.Entities.Boloes.BolaoMembro(base.SelectedNomeBolao, model.UserName));
            }
            return RedirectToAction("Index");
        }
        #endregion
    }
}