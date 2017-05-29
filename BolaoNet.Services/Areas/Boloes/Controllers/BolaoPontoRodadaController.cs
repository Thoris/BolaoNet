using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Boloes.Controllers
{
    public class BolaoPontoRodadaController :
        GenericApiController<Entities.Boloes.BolaoPontoRodada>, Business.Interfaces.Boloes.IBolaoPontoRodadaBO
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Business.Interfaces.Boloes.IBolaoPontoRodadaBO Dao
        {
            get { return (Business.Interfaces.Boloes.IBolaoPontoRodadaBO)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public BolaoPontoRodadaController()
            : base(new Business.FactoryBO().CreateBolaoPontoRodadaBO())
        {

        }

        #endregion

        #region Methods


        #endregion
    }
}