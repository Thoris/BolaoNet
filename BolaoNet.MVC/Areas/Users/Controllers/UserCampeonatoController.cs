using BolaoNet.MVC.Controllers;
using BolaoNet.MVC.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Users.Controllers
{
    [AuthorizeRoles(PermissionLevel.Administrador | PermissionLevel.GerenciadorResultados | PermissionLevel.VisitanteCampeonato)]
    public class UserCampeonatoController : BaseCampeonatoController
    {
        #region Constructors/Destructors

        public UserCampeonatoController(
            Application.Interfaces.Campeonatos.ICampeonatoApp campeonatoApp,
            Application.Interfaces.Campeonatos.ICampeonatoFaseApp campeonatoFaseApp,
            Application.Interfaces.Campeonatos.ICampeonatoGrupoApp campeonatoGrupoApp,
            Application.Interfaces.Campeonatos.ICampeonatoTimeApp campeonatoTimeApp
            )
            : base (campeonatoApp, campeonatoFaseApp, campeonatoGrupoApp, campeonatoTimeApp)
        {

        }

        #endregion

        #region Actions

        public ActionResult Index()
        {
            IList<Domain.Entities.Campeonatos.Campeonato> campeonatoList = CampeonatoApp.GetAll().ToList();

            ViewModels.Users.UserCampeonatosViewModel model = new ViewModels.Users.UserCampeonatosViewModel();
            model.CampeonatoSelecionado = base.SelectedNomeCampeonato;

            model.CampeonatosList = new List<string>();
            for (int c = 0; c < campeonatoList.Count; c++)
            {
                if (string.Compare(model.CampeonatoSelecionado, campeonatoList[c].Nome, true) != 0)
                    model.CampeonatosList.Add(campeonatoList[c].Nome);
            }

            return View(model);
        }
        public ActionResult Selecionar(string nomeCampeonato)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            if (!string.IsNullOrEmpty(nomeCampeonato))
            {

                Domain.Entities.Campeonatos.Campeonato campeonato = 
                    CampeonatoApp.Load(new Domain.Entities.Campeonatos.Campeonato(nomeCampeonato));

                base.SelectedNomeCampeonato = nomeCampeonato;

            }

            return RedirectToAction("Index");
        }

        #endregion
    }
}