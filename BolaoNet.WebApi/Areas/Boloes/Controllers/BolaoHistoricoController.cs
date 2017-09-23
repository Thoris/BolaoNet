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
    public class BolaoHistoricoController :
        GenericApiController<Domain.Entities.Boloes.BolaoHistorico>,
        Domain.Interfaces.Services.Boloes.IBolaoHistoricoService
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.Boloes.IBolaoHistoricoService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IBolaoHistoricoService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors
         
        public BolaoHistoricoController(Domain.Interfaces.Services.Boloes.IBolaoHistoricoService service)
            : base(service)
        {

        }

        #endregion

        #region IBolaoMembroBO members

        [HttpPost]
        public IList<Domain.Entities.Boloes.BolaoHistorico> GetListFromBolao(int id, ArrayList data)
        {
            Domain.Entities.Boloes.Bolao bolao;
            int ano;
            bolao = JsonConvert.DeserializeObject<Domain.Entities.Boloes.Bolao>(data[0].ToString());
            ano = JsonConvert.DeserializeObject<int>(data[1].ToString());
            

            return Service.GetListFromBolao(bolao, ano);
        }
        [HttpPost]
        public IList<Domain.Entities.Boloes.BolaoHistorico> GetListFromBolao(Domain.Entities.Boloes.Bolao bolao, int ano)
        {
            return Service.GetListFromBolao(bolao, ano);
        }
        [HttpPost]
        public IList<int> GetYearsFromBolao(Domain.Entities.Boloes.Bolao bolao)
        {
            return Service.GetYearsFromBolao(bolao);
        }

        #endregion



    }
}