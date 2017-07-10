using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

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
        private Domain.Interfaces.Services.Boloes.IBolaoMembroService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IBolaoMembroService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        //public BolaoMembroController()
        //    : base(new Domain.Services.FactoryService(null).CreateBolaoMembroService())
        //{

        //}
        public BolaoMembroController(Domain.Interfaces.Services.Boloes.IBolaoMembroService service)
            : base(service)
        {

        }

        #endregion

        #region IBolaoMembroBO members

        public IList<Domain.Entities.Boloes.BolaoMembro> GetListUsersInBolao(Domain.Entities.Boloes.Bolao bolao)
        {
            return Service.GetListUsersInBolao(bolao);
        }
        public IList<Domain.Entities.Boloes.BolaoMembro> GetListBolaoInUsers(Domain.Entities.Users.User user)
        {
            return Service.GetListBolaoInUsers(user);
        }
        public IList<Domain.Entities.ValueObjects.UserMembroStatusVO> GetUserStatus(Domain.Entities.Boloes.Bolao bolao)
        {
            return Service.GetUserStatus(bolao);
        }

        public bool RemoverMembroBolao(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Boloes.BolaoMembro membro)
        {
            return Service.RemoverMembroBolao(bolao, membro);
        }

        #endregion


    }
}