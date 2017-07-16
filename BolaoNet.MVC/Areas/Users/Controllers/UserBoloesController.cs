using BolaoNet.MVC.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Users.Controllers
{
    public class UserBoloesController : BaseBolaoController
    {
        #region Variables


        #endregion

        #region Constructors/Destructors

        public UserBoloesController(
            Application.Interfaces.Boloes.IBolaoMembroApp bolaoMembroApp,
            Application.Interfaces.Boloes.IBolaoApp bolaoApp,
            Application.Interfaces.Campeonatos.ICampeonatoApp campeonatoApp,
            Application.Interfaces.Campeonatos.ICampeonatoFaseApp campeonatoFaseApp,
            Application.Interfaces.Campeonatos.ICampeonatoGrupoApp campeonatoGrupoApp,
            Application.Interfaces.Campeonatos.ICampeonatoTimeApp campeonatoTimeApp
            )
            : base 
            (
                bolaoMembroApp, bolaoApp, campeonatoApp, campeonatoFaseApp, campeonatoGrupoApp, campeonatoTimeApp
            )
        {
            
        }

        #endregion

        #region Actions

        public ActionResult Index()
        {
            IList<Domain.Entities.Boloes.Bolao> bolaoList = _bolaoApp.GetBoloesDisponiveis();

            ViewModels.Users.UserBoloesViewModel model = new ViewModels.Users.UserBoloesViewModel();
            model.BolaoSelecionado = base.SelectedNomeBolao;

            model.BoloesList = new List<string>();
            for (int c = 0; c < bolaoList.Count; c++)
            {
                if (string.Compare (model.BolaoSelecionado, bolaoList[c].Nome, true) != 0)
                    model.BoloesList.Add(bolaoList[c].Nome);
            }

            return View(model);
        }
        [HttpGet]
        public ActionResult Selecionar(string nomeBolao)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            if (!string.IsNullOrEmpty (nomeBolao))
            {

                Domain.Entities.Boloes.Bolao bolao = _bolaoApp.Load(new Domain.Entities.Boloes.Bolao (nomeBolao));

                base.SelectedNomeBolao = nomeBolao;
                base.SelectedNomeCampeonato = bolao.NomeCampeonato;

            }

            return RedirectToAction("Index");
        }

        #endregion
    }
}