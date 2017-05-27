using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Boloes.Controllers
{
    public class BolaoController :
        GenericApiController<Entities.Boloes.Bolao>, Business.Interfaces.Boloes.IBolaoBO 
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Business.Interfaces.Boloes.IBolaoBO Dao
        {
            get { return (Business.Interfaces.Boloes.IBolaoBO)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public BolaoController()
            : base ( new Business.FactoryBO().CreateBolaoBO())
        {

        }

        #endregion

        #region Methods


        #endregion

        public bool Iniciar(Entities.Users.User iniciadoBy, Entities.Boloes.Bolao bolao)
        {
            throw new NotImplementedException();
        }

        public bool Aguardar(Entities.Boloes.Bolao bolao)
        {
            throw new NotImplementedException();
        }
    }
}