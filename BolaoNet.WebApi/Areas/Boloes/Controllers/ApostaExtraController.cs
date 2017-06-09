using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Boloes.Controllers
{
    public class ApostaExtraController : 
        GenericApiController<Domain.Entities.Boloes.ApostaExtra>, Domain.Interfaces.Services.Boloes.IApostaExtraService
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.Boloes.IApostaExtraService Dao
        {
            get { return (Domain.Interfaces.Services.Boloes.IApostaExtraService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public ApostaExtraController()
            : base(new Domain.Services.FactoryService().CreateApostaExtraService())
        {

        }

        #endregion

        #region Methods


        #endregion

        public IList<Domain.Entities.Boloes.ApostaExtra> GetApostasBolao(Domain.Entities.Boloes.Bolao bolao)
        {
            throw new NotImplementedException();
        }



        public bool InsertResult(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.DadosBasicos.Time time, int posicao, Domain.Entities.Users.User validadoBy)
        {
            throw new NotImplementedException();
        }
    }
}