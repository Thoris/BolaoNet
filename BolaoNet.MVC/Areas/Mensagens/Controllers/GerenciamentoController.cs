using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Mensagens.Controllers
{
    public class GerenciamentoController : BaseMensagensAreaController
    {       
        #region Constructors/Destructors

        public GerenciamentoController(
            Application.Interfaces.Boloes.IMensagemApp mensagemApp,
            Application.Interfaces.Boloes.IBolaoMembroApp bolaoMembroApp,
            Application.Interfaces.Boloes.IBolaoApp bolaoApp,
            Application.Interfaces.Campeonatos.ICampeonatoApp campeonatoApp,
            Application.Interfaces.Campeonatos.ICampeonatoFaseApp campeonatoFaseApp,
            Application.Interfaces.Campeonatos.ICampeonatoGrupoApp campeonatoGrupoApp,
            Application.Interfaces.Campeonatos.ICampeonatoTimeApp campeonatoTimeApp            
            )
            : base 
            (
                mensagemApp, bolaoMembroApp, bolaoApp, campeonatoApp, campeonatoFaseApp, campeonatoGrupoApp, campeonatoTimeApp
            )
        {
            
        }

        #endregion

        #region Actions

        public ActionResult Index()
        {
            IList<Domain.Entities.Boloes.Mensagem> list =
               _mensagemApp.GetMensagensUsuario(base.SelectedBolao, base.UserLogged);


            IList<ViewModels.Mensagens.MensagemViewModel> model =
                Mapper.Map<
                IList<Domain.Entities.Boloes.Mensagem>,
                IList<ViewModels.Mensagens.MensagemViewModel>>
                (list);

            return View(model);

            
        }

        #endregion
    }
}