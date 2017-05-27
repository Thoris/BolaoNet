using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Boloes.Controllers
{
    public class ApostaPontosController:
        GenericApiController<Entities.Boloes.ApostaPontos>, Business.Interfaces.Boloes.IApostaPontosBO
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Business.Interfaces.Boloes.IApostaPontosBO Dao
        {
            get { return (Business.Interfaces.Boloes.IApostaPontosBO)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public ApostaPontosController()
            : base(new Business.FactoryBO().CreateApostaPontosBO())
        {

        }

        #endregion

        #region Methods


        #endregion


    }
}