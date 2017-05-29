using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Boloes.Controllers
{
    public class BolaoCriterioPontosController:
        GenericApiController<Entities.Boloes.BolaoCriterioPontos>, Business.Interfaces.Boloes.IBolaoCriterioPontosBO
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Business.Interfaces.Boloes.IBolaoCriterioPontosBO Dao
        {
            get { return (Business.Interfaces.Boloes.IBolaoCriterioPontosBO)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public BolaoCriterioPontosController()
            : base(new Business.FactoryBO().CreateBolaoCriterioPontosBO())
        {

        }

        #endregion

        #region Methods


        #endregion

        public int[] GetCriteriosPontos(Entities.Boloes.Bolao bolao)
        {
            throw new NotImplementedException();
        }

        public IList<Entities.Boloes.BolaoCriterioPontos> GetCriterioPontosBolao(Entities.Boloes.Bolao bolao)
        {
            throw new NotImplementedException();
        }
    }
}