using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Boloes.Controllers
{
    public class BolaoMembroGrupoController :
        GenericApiController<Domain.Entities.Boloes.BolaoMembroGrupo>, 
        Domain.Interfaces.Services.Boloes.IBolaoMembroGrupoService
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.Boloes.IBolaoMembroGrupoService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IBolaoMembroGrupoService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        //public BolaoMembroGrupoController()
        //    : base(new Domain.Services.FactoryService(null).CreateBolaoMembroGrupoService())
        //{

        //}
        public BolaoMembroGrupoController(Domain.Interfaces.Services.Boloes.IBolaoMembroGrupoService service)
            : base(service)
        {

        }

        #endregion

        #region Methods


        #endregion

        #region IBolaoMembroGrupoService members

        public IList<Domain.Entities.ValueObjects.BolaoGrupoComparacaoClassificacaoVO> LoadClassificacao(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user)
        {
            return Service.LoadClassificacao(bolao, user);
        }

        #endregion
    }
}