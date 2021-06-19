using BolaoNet.Domain.Interfaces.Services.Facade.Boloes;
using BolaoNet.Domain.Interfaces.Services.Facade.Campeonatos;
using BolaoNet.MVC.Controllers;
using BolaoNet.MVC.Security;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Admin.Controllers
{

    [AuthorizeRoles(PermissionLevel.Administrador)]
    public class ConfigurationController : AuthorizationController
    {
        #region Variables

        private Application.Interfaces.Boloes.IBolaoApp _bolaoApp;
        private Application.Interfaces.Campeonatos.ICampeonatoApp _campeonatoApp;
        private Application.Interfaces.Facade.Campeonatos.ICopaListFacadeApp _copaListFacadeApp;
        private Application.Interfaces.Facade.Boloes.IBolaoListFacadeApp _bolaoListFacadeApp;


        #endregion

        #region Constructors/Destructors

        public ConfigurationController(
            Application.Interfaces.Boloes.IBolaoApp bolaoApp,
            Application.Interfaces.Campeonatos.ICampeonatoApp campeonatoApp,
            Application.Interfaces.Facade.Campeonatos.ICopaListFacadeApp copaListFacadeApp,
            Application.Interfaces.Facade.Boloes.IBolaoListFacadeApp bolaoListFacadeApp
            )
            : base()
        {
            _bolaoApp = bolaoApp;
            _campeonatoApp = campeonatoApp;
            _copaListFacadeApp = copaListFacadeApp;
            _bolaoListFacadeApp = bolaoListFacadeApp;
        }

        #endregion

        #region Actions

        public ActionResult Index(ViewModels.Admin.ConfigurationViewModel model)
        {
            IList<Domain.Entities.Boloes.Bolao> boloes = _bolaoApp.GetAll().ToList();
            model.BoloesExistentes = new List<string>();
            for (int c=0; c < boloes.Count; c++)
            {
                model.BoloesExistentes.Add(boloes[c].Nome);
            }


            model.BoloesDisponiveis = _bolaoListFacadeApp.GetNames();

            for (int c = model.BoloesDisponiveis.Count - 1; c >= 0; c--)
            {
                for (int l = 0; l < model.BoloesExistentes.Count; l++)
                {
                    if (string.Compare(model.BoloesExistentes[l], model.BoloesDisponiveis[c], true) == 0)
                    {
                        model.BoloesDisponiveis.RemoveAt(c);
                        break;
                    }
                }
            }
             

            IList<Domain.Entities.Campeonatos.Campeonato> campeonatos = _campeonatoApp.GetAll().ToList();
            model.CampeonatosExistentes = new List<string>();
            for (int c = 0; c < campeonatos.Count; c++)
            {
                model.CampeonatosExistentes.Add(campeonatos[c].Nome);
            }
             

            model.CampeonatosDisponiveis = _copaListFacadeApp.GetNames();

            for (int c=model.CampeonatosDisponiveis.Count-1; c>=0; c--)
            {
                for (int l =0; l < model.CampeonatosExistentes.Count; l++)
                {
                    if (string.Compare(model.CampeonatosExistentes[l], model.CampeonatosDisponiveis[c], true) == 0)
                    {
                        model.CampeonatosDisponiveis.RemoveAt(c);
                        break;
                    }
                }
            }

            return View(model);
        }

        public ActionResult AdicionarCampeonato(string nomeCampeonato)
        {
            //string s = System.Uri.UnescapeDataString(nomeCampeonato); 

            //string myEncodedString = HttpUtility.HtmlDecode(nomeCampeonato);

            //string x = Server.HtmlDecode(nomeCampeonato);
             
            ICopaFacadeService facade = _copaListFacadeApp.GetInstance(nomeCampeonato);

            if (facade == null)
            {
                base.ShowErrorMessage("Não há instância para o campeonato: " + nomeCampeonato);
            }
            else
            {
                facade.CreateCampeonato(nomeCampeonato, false);
            }


            return RedirectToAction("Index");
        }

        public ActionResult AdicionarBolao(string nomeBolao)
        {
            IBolaoFacadeService facade = _bolaoListFacadeApp.GetInstance(nomeBolao);

            if (facade == null)
            {
                base.ShowErrorMessage("Não há instância para o campeonato: " + nomeBolao);
            }
            else
            {
                facade.CreateBolao(new Domain.Entities.Campeonatos.Campeonato(nomeBolao));
            }

            return RedirectToAction("Index");
        }

        #endregion
    }
}