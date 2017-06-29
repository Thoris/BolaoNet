using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        
        public IList<Domain.Entities.Campeonatos.CampeonatoClassificacao> LoadClassificacao(Domain.Entities.Campeonatos.Campeonato campeonato, Domain.Entities.Campeonatos.CampeonatoFase fase, Domain.Entities.Campeonatos.CampeonatoGrupo grupo, int rodada)
        {
            return Service.LoadClassificacao(campeonato, fase, grupo, rodada);
        }

        #endregion
    }
}