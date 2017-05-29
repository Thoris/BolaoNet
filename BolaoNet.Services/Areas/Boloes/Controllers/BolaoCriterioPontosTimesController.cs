using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Boloes.Controllers
{
    public class BolaoCriterioPontosTimesController:
        GenericApiController<Entities.Boloes.BolaoCriterioPontosTimes>, Business.Interfaces.Boloes.IBolaoCriterioPontosTimesBO 
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Business.Interfaces.Boloes.IBolaoCriterioPontosTimesBO Dao
        {
            get { return (Business.Interfaces.Boloes.IBolaoCriterioPontosTimesBO)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public BolaoCriterioPontosTimesController()
            : base(new Business.FactoryBO().CreateBolaoCriterioPontosTimesBO())
        {

        }

        #endregion

        #region Methods


        #endregion

        public IList<Entities.Boloes.BolaoCriterioPontosTimes> GetCriterioPontosBolao(Entities.Boloes.Bolao bolao)
        {
            throw new NotImplementedException();
        }
    }
}