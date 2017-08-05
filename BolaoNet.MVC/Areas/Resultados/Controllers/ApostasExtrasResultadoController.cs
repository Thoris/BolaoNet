using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Resultados.Controllers
{
    public class ApostasExtrasResultadoController : BaseResultadosAreaController
    {
        #region Variables

        private Application.Interfaces.Boloes.IApostaExtraApp _apostaExtraApp;

        #endregion

        #region Constructors/Destructors

        public ApostasExtrasResultadoController(
            Application.Interfaces.Boloes.IApostaExtraApp apostaExtraApp,
            Application.Interfaces.Boloes.IBolaoMembroApp bolaoMembroApp,
            Application.Interfaces.Boloes.IBolaoApp bolaoApp,
            Application.Interfaces.Campeonatos.ICampeonatoApp campeonatoApp,
            Application.Interfaces.Campeonatos.ICampeonatoFaseApp campeonatoFaseApp,
            Application.Interfaces.Campeonatos.ICampeonatoGrupoApp campeonatoGrupoApp,
            Application.Interfaces.Campeonatos.ICampeonatoTimeApp campeonatoTimeApp
            )
            : base (bolaoMembroApp, bolaoApp, campeonatoApp, campeonatoFaseApp, 
            campeonatoGrupoApp, campeonatoTimeApp)
        {
            _apostaExtraApp = apostaExtraApp;
        }

        #endregion
        
        #region Actions

        public ActionResult Index()
        {
            IList<Domain.Entities.Boloes.ApostaExtra> list =
                _apostaExtraApp.GetApostasBolao(base.SelectedBolao);

            ViewBag.Times = base.CampeonatoData.NomeTimes;


            IList<ViewModels.Resultados.ApostaExtraViewModel> data =
                Mapper.Map<IList<Domain.Entities.Boloes.ApostaExtra>,
                IList<ViewModels.Resultados.ApostaExtraViewModel>>
                (list);


            return View(data);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Salvar(IList<ViewModels.Resultados.ApostaExtraViewModel> model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            IList<ViewModels.Resultados.ApostaExtraViewModel> list = (
                from p in model
                where p.IsChanged == true
                select p).ToList();

            IList<Domain.Entities.Boloes.ApostaExtra> data =
                Mapper.Map<IList<ViewModels.Resultados.ApostaExtraViewModel>,
                IList<Domain.Entities.Boloes.ApostaExtra>>
                (list);


            for (int c = 0; c < data.Count; c++)
            {
                _apostaExtraApp.InsertResult(base.SelectedBolao,
                    new Domain.Entities.DadosBasicos.Time(data[c].NomeTimeValidado),
                    data[c].Posicao,
                    base.UserLogged);
            }

            if (data.Count > 0)
            {
                base.ShowMessage("Resultados de apostas extras inseridos com sucesso.");
            }

            return RedirectToAction("Index");
        }

        #endregion
    }
}