using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Boloes.Controllers
{
    public class ApostaExtraController : 
        GenericApiController<Entities.Boloes.ApostaExtra>, Business.Interfaces.Boloes.IApostaExtraBO
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Business.Interfaces.Boloes.IApostaExtraBO Dao
        {
            get { return (Business.Interfaces.Boloes.IApostaExtraBO)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public ApostaExtraController()
            : base(new Business.FactoryBO().CreateApostaExtraBO())
        {

        }

        #endregion

        #region Methods


        #endregion

        public IList<Entities.Boloes.ApostaExtra> GetApostasBolao(Entities.Boloes.Bolao bolao)
        {
            throw new NotImplementedException();
        }



        public bool InsertResult(Entities.Boloes.Bolao bolao, Entities.DadosBasicos.Time time, int posicao, Entities.Users.User validadoBy)
        {
            throw new NotImplementedException();
        }
    }
}