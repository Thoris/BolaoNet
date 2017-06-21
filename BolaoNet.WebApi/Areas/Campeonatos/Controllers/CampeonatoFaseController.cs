using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Campeonatos.Controllers
{
    public class CampeonatoFaseController:
        GenericApiController<Domain.Entities.Campeonatos.CampeonatoFase>, 
        Domain.Interfaces.Services.Campeonatos.ICampeonatoFaseService
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.Campeonatos.ICampeonatoFaseService Service
        {
            get { return (Domain.Interfaces.Services.Campeonatos.ICampeonatoFaseService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        //public CampeonatoFaseController()
        //    : base(new Domain.Services.FactoryService(null).CreateCampeonatoFaseService())
        //{

        //}        
        public CampeonatoFaseController(Domain.Interfaces.Services.Campeonatos.ICampeonatoFaseService service)
            : base(service)
        {

        }

        #endregion

        #region Methods


        #endregion

        #region ICampeonatoFaseService members

        public IList<Domain.Entities.Campeonatos.CampeonatoFase> GetFaseCampeonato(Domain.Entities.Campeonatos.Campeonato campeonato)
        {
            return Service.GetFaseCampeonato(campeonato);
        }

        #endregion
    }
}