using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Campeonatos.Controllers
{
    public class RecordsTimesController: BaseCampeonatoAreaController
    {

        #region Constructors/Destructors

        public RecordsTimesController(
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

        public ActionResult Index(int id)
        {
            ViewModels.Campeonatos.CampeonatoRecordsListViewModel model = new ViewModels.Campeonatos.CampeonatoRecordsListViewModel();


            Domain.Interfaces.Services.Campeonatos.RecordTipoPesquisa tipo = (Domain.Interfaces.Services.Campeonatos.RecordTipoPesquisa)id;

            switch(tipo)
            {
                case Domain.Interfaces.Services.Campeonatos.RecordTipoPesquisa.QtdJogosSemGanhar:
                    model.Title = "Quantidade de jogos sem ganhar";
                    break;
                case Domain.Interfaces.Services.Campeonatos.RecordTipoPesquisa.QtdJogosSemPerder:
                    model.Title = "Quantidade de Jogos sem perder";
                    break;
                case Domain.Interfaces.Services.Campeonatos.RecordTipoPesquisa.RecordQtdJogosSemGanhar:
                    model.Title = "Record de quantidade de jogos sem ganhar";
                    break;
                case Domain.Interfaces.Services.Campeonatos.RecordTipoPesquisa.RecordQtdJogosSemPerder:
                    model.Title = "Record de quantidade de jogos sem perder";
                    break;
                case Domain.Interfaces.Services.Campeonatos.RecordTipoPesquisa.RecordSeqDerrotas:
                    model.Title = "Record de Sequência de Derrotas";
                    break;
                case Domain.Interfaces.Services.Campeonatos.RecordTipoPesquisa.RecordSeqEmpates:
                    model.Title = "Record de Sequência de Empates";
                    break;
                case Domain.Interfaces.Services.Campeonatos.RecordTipoPesquisa.RecordSeqVitorias:
                    model.Title = "Records de Sequência de Vitórias";
                    break;
                case Domain.Interfaces.Services.Campeonatos.RecordTipoPesquisa.SequenciaDerrotas:
                    model.Title = "Sequência de Derrotas";
                    break;
                case Domain.Interfaces.Services.Campeonatos.RecordTipoPesquisa.SequenciaEmpates:
                    model.Title = "Sequência de Empates";
                    break;
                case Domain.Interfaces.Services.Campeonatos.RecordTipoPesquisa.SequenciaVitorias:
                    model.Title = "Sequência de Vitórias";
                    break;
            }


            
            IList<IList<Domain.Entities.ValueObjects.CampeonatoRecordVO>> list = CampeonatoApp.GetRecords(base.SelectedCampeonato, tipo);

            model.List = Mapper.Map<IList<IList<Domain.Entities.ValueObjects.CampeonatoRecordVO>>, 
                IList<IList<ViewModels.Campeonatos.CampeonatoRecordsViewModel>>>(list);



            return View(model);
        }

        #endregion
    }
}