using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Boloes.Controllers
{
    public class BolaoPremiacaoController : BaseBolaoAreaController
    {
        #region Variables

        private Application.Interfaces.Boloes.IBolaoPremiacaoApp _bolaoPremiacaoApp;
        
        #endregion

        #region Constructors/Destructors


        public BolaoPremiacaoController(
            Application.Interfaces.Boloes.IBolaoPremiacaoApp bolaoPremiacaoApp,
            Application.Interfaces.Boloes.IBolaoMembroApp bolaoMembroApp,
            Application.Interfaces.Boloes.IBolaoApp bolaoApp,
            Application.Interfaces.Campeonatos.ICampeonatoApp campeonatoApp,
            Application.Interfaces.Campeonatos.ICampeonatoFaseApp campeonatoFaseApp,
            Application.Interfaces.Campeonatos.ICampeonatoGrupoApp campeonatoGrupoApp,
            Application.Interfaces.Campeonatos.ICampeonatoTimeApp campeonatoTimeApp
            )
            : base(bolaoMembroApp, bolaoApp, campeonatoApp, campeonatoFaseApp, campeonatoGrupoApp, campeonatoTimeApp)
        {
            _bolaoPremiacaoApp = bolaoPremiacaoApp;
        }

        #endregion

        #region Actions

        public ActionResult Index()
        {
            ViewModels.Bolao.BolaoPremiacaoViewModelInfo model = new ViewModels.Bolao.BolaoPremiacaoViewModelInfo(); 

            IList<Domain.Entities.Boloes.BolaoPremiacao> list = _bolaoPremiacaoApp.LoadPremiacaoBolao(base.SelectedBolao);

            double total = 0;
            for (int c = 0; c < list.Count; c++ )
            {
                total += list[c].Valor;
            }

            model.Premiacoes = Mapper.Map<IList<Domain.Entities.Boloes.BolaoPremiacao>, IList<ViewModels.Bolao.BolaoPremiacaoViewModel>>(list);
            model.ValorTotal = total;


            return View(model);
        } 
        
        #endregion    
    }
}