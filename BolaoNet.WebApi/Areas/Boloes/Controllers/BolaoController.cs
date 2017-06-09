using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Boloes.Controllers
{
    public class BolaoController :
        GenericApiController<Domain.Entities.Boloes.Bolao>, Domain.Interfaces.Services.Boloes.IBolaoService 
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.Boloes.IBolaoService Dao
        {
            get { return (Domain.Interfaces.Services.Boloes.IBolaoService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public BolaoController()
            : base(new Domain.Services.FactoryService().CreateBolaoService())
        {

        }

        #endregion

        #region Methods


        #endregion

        public bool Iniciar(Domain.Entities.Users.User iniciadoBy, Domain.Entities.Boloes.Bolao bolao)
        {
            throw new NotImplementedException();
        }

        public bool Aguardar(Domain.Entities.Boloes.Bolao bolao)
        {
            throw new NotImplementedException();
        }
    }
}