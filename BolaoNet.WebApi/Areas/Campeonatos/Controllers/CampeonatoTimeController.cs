using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BolaoNet.Services.Areas.Campeonatos.Controllers
{
    public class CampeonatoTimeController:
        GenericApiController<Domain.Entities.Campeonatos.CampeonatoTime>,
        Domain.Interfaces.Services.Campeonatos.ICampeonatoTimeService
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.Campeonatos.ICampeonatoTimeService Service
        {
            get { return (Domain.Interfaces.Services.Campeonatos.ICampeonatoTimeService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        //public CampeonatoTimeController()
        //    : base(new Domain.Services.FactoryService(null).CreateCampeonatoTimeService())
        //{

        //}
        public CampeonatoTimeController(Domain.Interfaces.Services.Campeonatos.ICampeonatoTimeService service)
            : base(service)
        {

        }

        #endregion

        #region Methods


        #endregion

        #region ICampeonatoTimeService

        [HttpPost]
        public IList<Domain.Entities.Campeonatos.CampeonatoTime> GetTimesCampeonato(Domain.Entities.Campeonatos.Campeonato campeonato)
        {
            return Service.GetTimesCampeonato(campeonato);
        }

        #endregion
    }
}