using BolaoNet.Services.Controllers;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BolaoNet.Services.Areas.Campeonatos.Controllers
{
    public class CampeonatoPosicaoController:
        GenericApiController<Domain.Entities.Campeonatos.CampeonatoPosicao>,
        Domain.Interfaces.Services.Campeonatos.ICampeonatoPosicaoService
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.Campeonatos.ICampeonatoPosicaoService Service
        {
            get { return (Domain.Interfaces.Services.Campeonatos.ICampeonatoPosicaoService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        //public CampeonatoPosicaoController()
        //    : base(new Domain.Services.FactoryService(null).CreateCampeonatoPosicaoService())
        //{

        //}
        public CampeonatoPosicaoController(Domain.Interfaces.Services.Campeonatos.ICampeonatoPosicaoService service)
            : base(service)
        {

        }

        #endregion

        #region Methods


        #endregion

        #region ICampeonatoPosicaoService members


        [HttpPost]
        public IList<Domain.Entities.Campeonatos.CampeonatoPosicao> GetPosicao(int id, ArrayList data)
        {
            Domain.Entities.Campeonatos.Campeonato campeonato;
            Domain.Entities.Campeonatos.CampeonatoFase fase;
             
            campeonato = JsonConvert.DeserializeObject<Domain.Entities.Campeonatos.Campeonato>(data[0].ToString());
            fase = JsonConvert.DeserializeObject<Domain.Entities.Campeonatos.CampeonatoFase>(data[1].ToString());
            

            return Service.GetPosicao(campeonato, fase);
        }

        [HttpPost]
        public IList<Domain.Entities.Campeonatos.CampeonatoPosicao> GetPosicao(Domain.Entities.Campeonatos.Campeonato campeonato, Domain.Entities.Campeonatos.CampeonatoFase fase)
        {
            return Service.GetPosicao(campeonato, fase);
        }

        #endregion
    }
}