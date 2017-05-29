using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Boloes.Controllers
{
    public class MensagemController:
        GenericApiController<Entities.Boloes.Mensagem>, Business.Interfaces.Boloes.IMensagemBO
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Business.Interfaces.Boloes.IMensagemBO Dao
        {
            get { return (Business.Interfaces.Boloes.IMensagemBO)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public MensagemController()
            : base ( new Business.FactoryBO().CreateMensagemBO())
        {

        }

        #endregion

        #region Methods


        #endregion
    }
}