using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Apostas.Controllers
{
    public class ApostasExtrasController : BaseApostasAreaController
    {
        #region Variables

        private Application.Interfaces.Boloes.IApostaExtraUsuarioApp _apostaExtraUsuarioApp;
        
        #endregion

        #region Constructors/Destructors

        public ApostasExtrasController(
                Application.Interfaces.Boloes.IBolaoMembroApp bolaoMembroApp,
                Application.Interfaces.Boloes.IBolaoApp bolaoApp,
                Application.Interfaces.Campeonatos.ICampeonatoApp campeonatoApp,
                Application.Interfaces.Campeonatos.ICampeonatoFaseApp campeonatoFaseApp,
                Application.Interfaces.Campeonatos.ICampeonatoGrupoApp campeonatoGrupoApp,
                Application.Interfaces.Campeonatos.ICampeonatoTimeApp campeonatoTimeApp,
                Application.Interfaces.Boloes.IApostaExtraUsuarioApp apostaExtraUsuarioApp
            )
            : base(bolaoMembroApp, bolaoApp, campeonatoApp, campeonatoFaseApp, campeonatoGrupoApp, campeonatoTimeApp)
        {
            _apostaExtraUsuarioApp = apostaExtraUsuarioApp;
        }

        #endregion

        #region Actions

        public ActionResult Index()
        {
            IList<Domain.Entities.ValueObjects.ApostaExtraUsuarioVO> list =
                _apostaExtraUsuarioApp.GetApostasUser(base.SelectedBolao, base.UserLogged);

            ViewBag.Times = base.CampeonatoData.NomeTimes;


            //IList<Domain.Entities.ValueObjects.ApostaExtraUsuarioVO> list =
            //    _apostaExtraUsuarioApp.GetApostasUser(
            //        new Domain.Entities.Boloes.Bolao("Copa do Mundo 2014"), 
            //        new Domain.Entities.Users.User("thoris"));


            IList<ViewModels.Apostas.ApostaExtraViewModel> data =
                Mapper.Map<IList<Domain.Entities.ValueObjects.ApostaExtraUsuarioVO>,
                IList<ViewModels.Apostas.ApostaExtraViewModel>>
                (list);


            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Salvar(IList<ViewModels.Apostas.ApostaExtraViewModel> model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            IList<ViewModels.Apostas.ApostaExtraViewModel> list = (
                from p in model
                where p.IsChanged == true
                select p).ToList ();

            IList<Domain.Entities.Boloes.ApostaExtraUsuario> data =
                Mapper.Map<IList<ViewModels.Apostas.ApostaExtraViewModel>,
                IList<Domain.Entities.Boloes.ApostaExtraUsuario>>
                (list);


            for (int c = 0; c < data.Count; c++ )
            {
                Domain.Entities.Boloes.ApostaExtraUsuario loaded = _apostaExtraUsuarioApp.Load(data[c]);


                if (loaded == null)
                {
                    data[c].DataAposta = DateTime.Now;
                    _apostaExtraUsuarioApp.Insert(data[c]);
                }
                else
                {
                    loaded.DataAposta = DateTime.Now;
                    loaded.NomeTime = data[c].NomeTime;
                    _apostaExtraUsuarioApp.Update(loaded);
                }
            }


            return RedirectToAction("Index");
        }

        #endregion
    }
}