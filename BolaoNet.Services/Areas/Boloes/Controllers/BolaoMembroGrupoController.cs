using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Boloes.Controllers
{
    public class BolaoMembroGrupoController :
        GenericApiController<Entities.Boloes.BolaoMembroGrupo>, Business.Interfaces.Boloes.IBolaoMembroGrupoBO
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Business.Interfaces.Boloes.IBolaoMembroGrupoBO Dao
        {
            get { return (Business.Interfaces.Boloes.IBolaoMembroGrupoBO)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public BolaoMembroGrupoController()
            : base(new Business.FactoryBO().CreateBolaoMembroGrupoBO())
        {

        }

        #endregion

        #region Methods


        #endregion
    }
}