using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.DadosBasicos.Controllers
{
    public class EstadioController:
        GenericApiController<Entities.DadosBasicos.Estadio>, Business.Interfaces.DadosBasicos.IEstadioBO
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Business.Interfaces.DadosBasicos.IEstadioBO Dao
        {
            get { return (Business.Interfaces.DadosBasicos.IEstadioBO)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public EstadioController()
            : base ( new Business.FactoryBO().CreateEstadioBO())
        {

        }

        #endregion

        #region Methods


        #endregion
    }
}