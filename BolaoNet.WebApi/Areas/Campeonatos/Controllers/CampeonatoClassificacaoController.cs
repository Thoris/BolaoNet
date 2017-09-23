using BolaoNet.Services.Controllers;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BolaoNet.Services.Areas.Campeonatos.Controllers
{
    public class CampeonatoClassificacaoController:
        GenericApiController<Domain.Entities.Campeonatos.CampeonatoClassificacao>,
        Domain.Interfaces.Services.Campeonatos.ICampeonatoClassificacaoService
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.Campeonatos.ICampeonatoClassificacaoService Service
        {
            get { return (Domain.Interfaces.Services.Campeonatos.ICampeonatoClassificacaoService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        //public CampeonatoClassificacaoController()
        //    : base(new Domain.Services.FactoryService(null).CreateCampeonatoClassificacaoService())
        //{

        //}
        public CampeonatoClassificacaoController(Domain.Interfaces.Services.Campeonatos.ICampeonatoClassificacaoService service)
            : base(service)
        {

        }

        #endregion

        #region Methods


        #endregion

        #region ICampeonatoClassificacaoService members

        [HttpPost]
        public IList<Domain.Entities.Campeonatos.CampeonatoClassificacao> LoadClassificacao(int id, ArrayList data)
        {
            Domain.Entities.Campeonatos.Campeonato campeonato;
            Domain.Entities.Campeonatos.CampeonatoFase fase;
            Domain.Entities.Campeonatos.CampeonatoGrupo grupo;
            int rodada;


            campeonato = JsonConvert.DeserializeObject<Domain.Entities.Campeonatos.Campeonato>(data[0].ToString());
            fase = JsonConvert.DeserializeObject<Domain.Entities.Campeonatos.CampeonatoFase>(data[1].ToString());
            grupo = JsonConvert.DeserializeObject<Domain.Entities.Campeonatos.CampeonatoGrupo>(data[2].ToString());
            rodada = JsonConvert.DeserializeObject<int>(data[3].ToString());


            return Service.LoadClassificacao(campeonato, fase, grupo, rodada);
        }
        [HttpPost]
        public IList<Domain.Entities.Campeonatos.CampeonatoClassificacao> LoadClassificacao(Domain.Entities.Campeonatos.Campeonato campeonato, Domain.Entities.Campeonatos.CampeonatoFase fase, Domain.Entities.Campeonatos.CampeonatoGrupo grupo, int rodada)
        {
            return Service.LoadClassificacao(campeonato, fase, grupo, rodada);
        }

        #endregion
    }
}