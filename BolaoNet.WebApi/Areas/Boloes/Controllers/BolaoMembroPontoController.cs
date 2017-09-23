using BolaoNet.Services.Controllers;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BolaoNet.WebApi.Areas.Boloes.Controllers
{
    public class BolaoMembroPontoController:
        GenericApiController<Domain.Entities.Boloes.BolaoMembroPonto>, 
        Domain.Interfaces.Services.Boloes.IBolaoMembroPontoService
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.Boloes.IBolaoMembroPontoService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IBolaoMembroPontoService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        //public BolaoMembroController()
        //    : base(new Domain.Services.FactoryService(null).CreateBolaoMembroService())
        //{

        //}
        public BolaoMembroPontoController(Domain.Interfaces.Services.Boloes.IBolaoMembroPontoService service)
            : base(service)
        {

        }

        #endregion

        #region IBolaoMembroBO members

        [HttpPost]
        public IList<Domain.Entities.Boloes.BolaoMembroPonto> GetHistoricoClassificacao(int id, ArrayList data)
        {
            Domain.Entities.Users.User user = null;
            Domain.Entities.Boloes.Bolao bolao = null;

            bolao = JsonConvert.DeserializeObject<Domain.Entities.Boloes.Bolao>(data[0].ToString());
            user = JsonConvert.DeserializeObject<Domain.Entities.Users.User>(data[1].ToString());
            
            return Service.GetHistoricoClassificacao(bolao, user);
        }
        [HttpPost]
        public IList<Domain.Entities.Boloes.BolaoMembroPonto> GetHistoricoClassificacao(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user)
        {
            return Service.GetHistoricoClassificacao(bolao, user);
        }

        #endregion



    }
}