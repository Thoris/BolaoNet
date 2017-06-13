using BolaoNet.Services.Controllers;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BolaoNet.Services.Areas.Boloes.Controllers
{
    public class ApostaExtraController : 
        GenericApiController<Domain.Entities.Boloes.ApostaExtra>, 
        Domain.Interfaces.Services.Boloes.IApostaExtraService
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.Boloes.IApostaExtraService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IApostaExtraService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public ApostaExtraController()
            : base(new Domain.Services.FactoryService(null).CreateApostaExtraService())
        {

        }

        #endregion

        #region Methods


        #endregion

        #region IApostaExtraService members

        public IList<Domain.Entities.Boloes.ApostaExtra> GetApostasBolao(Domain.Entities.Boloes.Bolao bolao)
        {

            return Service.GetApostasBolao(bolao);
        }        

        public bool InsertResult(int id, ArrayList data)
        {

            Domain.Entities.Boloes.Bolao bolao = JsonConvert.DeserializeObject<Domain.Entities.Boloes.Bolao>(data[0].ToString());
            Domain.Entities.DadosBasicos.Time time = JsonConvert.DeserializeObject<Domain.Entities.DadosBasicos.Time>(data[1].ToString());
            int posicao = JsonConvert.DeserializeObject<int>(data[2].ToString());
            Domain.Entities.Users.User validadoBy = JsonConvert.DeserializeObject<Domain.Entities.Users.User>(data[3].ToString ());

            return this.InsertResult(bolao, time, posicao, validadoBy);

        }
        public bool InsertResult(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.DadosBasicos.Time time, int posicao, Domain.Entities.Users.User validadoBy)
        {
            return Service.InsertResult(bolao, time, posicao, validadoBy);
        }

        #endregion
    }
}