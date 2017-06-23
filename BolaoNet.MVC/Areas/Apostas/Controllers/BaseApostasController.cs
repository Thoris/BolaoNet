using BolaoNet.MVC.Controllers;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Apostas.Controllers
{
    public class BaseApostasController : AuthorizationController
    {
        #region Variables

        private Application.Interfaces.Campeonatos.ICampeonatoApp _campeonatoApp;
        private Application.Interfaces.Campeonatos.ICampeonatoFaseApp _campeonatoFaseApp;
        private Application.Interfaces.Campeonatos.ICampeonatoGrupoApp _campeonatoGrupoApp;
        private Application.Interfaces.Campeonatos.ICampeonatoTimeApp _campeonatoTimeApp;

        #endregion

        #region Properties

        protected ViewModels.Base.CampeonatoDataVO CampeonatoData { get; set; }
        protected string UserName { get; set; }
        protected string NomeBolao { get; set; }

        #endregion
        
        #region Constructors/Destructors

        public BaseApostasController(
            Application.Interfaces.Campeonatos.ICampeonatoApp campeonatoApp,
            Application.Interfaces.Campeonatos.ICampeonatoFaseApp campeonatoFaseApp,
            Application.Interfaces.Campeonatos.ICampeonatoGrupoApp campeonatoGrupoApp,
            Application.Interfaces.Campeonatos.ICampeonatoTimeApp campeonatoTimeApp
            )
        {
            _campeonatoApp = campeonatoApp;
            _campeonatoFaseApp = campeonatoFaseApp;
            _campeonatoGrupoApp = campeonatoGrupoApp;
            _campeonatoTimeApp = campeonatoTimeApp;


            this.UserName = "thoris123";
            this.NomeBolao = "Copa do Mundo 2014";

            if (CampeonatoData == null)
            {
                this.CampeonatoData = new Helpers.CampeonatoDataLoader(
                    campeonatoApp, campeonatoFaseApp, campeonatoGrupoApp, campeonatoTimeApp
                    ).LoadCampeonatoData(new Domain.Entities.Campeonatos.Campeonato("Copa do Mundo 2014"));
            }
            
            //Application.Interfaces.Campeonatos.ICampeonatoApp campeonatoApp = new Application.Campeonatos.CampeonatoApp()
            //Application.Interfaces.Campeonatos.ICampeonatoFaseApp campeonatoFaseApp
            //Application.Interfaces.Campeonatos.ICampeonatoGrupoApp campeonatoGrupoApp
            //Application.Interfaces.Campeonatos.ICampeonatoTimeApp campeonatoTimeApp


            //CampeonatoData = new ViewModels.Base.CampeonatoDataVO();
            //CampeonatoData.NomeCampeonato = "Copa do Mundo 2014";
            //CampeonatoData.NomeFases = new List<string>();
            //CampeonatoData.NomeFases.Add("Classificatória");
            //CampeonatoData.NomeFases.Add("Oitavas de Final");
            //CampeonatoData.NomeFases.Add("Quartas de Final");
            //CampeonatoData.NomeFases.Add("Semi final");
            //CampeonatoData.NomeFases.Add("Final");


            //CampeonatoData.NomeGrupos = new List<string>();
            //CampeonatoData.NomeGrupos.Add("A");
            //CampeonatoData.NomeGrupos.Add("B");
            //CampeonatoData.NomeGrupos.Add("C");
            //CampeonatoData.NomeGrupos.Add("D");
            //CampeonatoData.NomeGrupos.Add("E");
            //CampeonatoData.NomeGrupos.Add("F");
            //CampeonatoData.NomeGrupos.Add("G");
            //CampeonatoData.NomeGrupos.Add("H");


            //CampeonatoData.NomeTimes = new List<string>();
            //CampeonatoData.NomeTimes.Add("Brasil");
            //CampeonatoData.NomeTimes.Add("Argentina");
            //CampeonatoData.NomeTimes.Add("Alemanha");
            //CampeonatoData.NomeTimes.Add("França");
            //CampeonatoData.NomeTimes.Add("Itália");


            //CampeonatoData.Rodadas = new List<int>();
            //CampeonatoData.Rodadas.Add(1);
            //CampeonatoData.Rodadas.Add(2);
            //CampeonatoData.Rodadas.Add(3);
            //CampeonatoData.Rodadas.Add(4);
            //CampeonatoData.Rodadas.Add(5);
            //CampeonatoData.Rodadas.Add(6);
            //CampeonatoData.Rodadas.Add(7);



        }

        #endregion
    }
}