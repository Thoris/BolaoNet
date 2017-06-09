using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Boloes.Controllers
{
    public class BolaoMembroController :
        GenericApiController<Domain.Entities.Boloes.BolaoMembro>, 
        Domain.Interfaces.Services.Boloes.IBolaoMembroService
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.Boloes.IBolaoMembroService Dao
        {
            get { return (Domain.Interfaces.Services.Boloes.IBolaoMembroService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public BolaoMembroController()
            : base(new Domain.Services.FactoryService().CreateBolaoMembroService())
        {

        }

        #endregion

        #region IBolaoMembroBO

        public IList<Domain.Entities.Boloes.BolaoMembro> GetListUsersInBolao(Domain.Entities.Boloes.Bolao bolao)
        {
            throw new NotImplementedException();
        }

        #endregion


    }
}