using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Boloes.Controllers
{
    public class BolaoCriterioPontosTimesController:
        GenericApiController<Domain.Entities.Boloes.BolaoCriterioPontosTimes>, 
        Domain.Interfaces.Services.Boloes.IBolaoCriterioPontosTimesService 
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.Boloes.IBolaoCriterioPontosTimesService Dao
        {
            get { return (Domain.Interfaces.Services.Boloes.IBolaoCriterioPontosTimesService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public BolaoCriterioPontosTimesController()
            : base(new Domain.Services.FactoryService().CreateBolaoCriterioPontosTimesService())
        {

        }

        #endregion

        #region Methods


        #endregion

        public IList<Domain.Entities.Boloes.BolaoCriterioPontosTimes> GetCriterioPontosBolao(Domain.Entities.Boloes.Bolao bolao)
        {
            throw new NotImplementedException();
        }
    }
}