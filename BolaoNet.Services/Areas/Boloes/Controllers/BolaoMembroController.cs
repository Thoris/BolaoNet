using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Boloes.Controllers
{
    public class BolaoMembroController :
        GenericApiController<Entities.Boloes.BolaoMembro>, Business.Interfaces.Boloes.IBolaoMembroBO
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Business.Interfaces.Boloes.IBolaoMembroBO Dao
        {
            get { return (Business.Interfaces.Boloes.IBolaoMembroBO)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public BolaoMembroController()
            : base(new Business.FactoryBO().CreateBolaoMembroBO())
        {

        }

        #endregion

        #region IBolaoMembroBO

        public IList<Entities.Boloes.BolaoMembro> GetListUsersInBolao(Entities.Boloes.Bolao bolao)
        {
            throw new NotImplementedException();
        }

        #endregion


    }
}