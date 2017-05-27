using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Boloes.Controllers
{
    public class ApostasRestantesController:
        GenericApiController<Entities.Boloes.ApostasRestantesUser>, Business.Interfaces.Boloes.IApostasRestantesBO
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Business.Interfaces.Boloes.IApostasRestantesBO Dao
        {
            get { return (Business.Interfaces.Boloes.IApostasRestantesBO)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public ApostasRestantesController()
            : base ( new Business.FactoryBO().CreateApostasRestantesBO())
        {

        }

        #endregion

        #region Methods


        #endregion


    }
}