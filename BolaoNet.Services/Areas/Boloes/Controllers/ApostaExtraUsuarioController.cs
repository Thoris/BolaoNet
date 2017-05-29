using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Boloes.Controllers
{
    public class ApostaExtraUsuarioController :
        GenericApiController<Entities.Boloes.ApostaExtraUsuario>, Business.Interfaces.Boloes.IApostaExtraUsuarioBO
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Business.Interfaces.Boloes.IApostaExtraUsuarioBO Dao
        {
            get { return (Business.Interfaces.Boloes.IApostaExtraUsuarioBO)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public ApostaExtraUsuarioController()
            : base(new Business.FactoryBO().CreateApostaExtraUsuarioBO())
        {

        }

        #endregion

        #region Methods


        #endregion

        public IList<Entities.Boloes.ApostaExtraUsuario> GetApostasUser(Entities.Boloes.Bolao bolao, Entities.Users.User user)
        {
            throw new NotImplementedException();
        }


    }
}