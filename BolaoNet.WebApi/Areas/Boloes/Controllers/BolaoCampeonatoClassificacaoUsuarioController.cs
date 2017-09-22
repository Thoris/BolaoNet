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
    public class BolaoCampeonatoClassificacaoUsuarioController:
        GenericApiController<Domain.Entities.Boloes.BolaoCampeonatoClassificacaoUsuario>,
        Domain.Interfaces.Services.Boloes.IBolaoCampeonatoClassificacaoUsuarioService
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.Boloes.IBolaoCampeonatoClassificacaoUsuarioService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IBolaoCampeonatoClassificacaoUsuarioService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        //public BolaoCampeonatoClassificacaoUsuarioController()
        //    : base(new Domain.Services.FactoryService(null).CreateBolaoCampeonatoClassificacaoUsuarioService())
        //{

        //}
        public BolaoCampeonatoClassificacaoUsuarioController(Domain.Interfaces.Services.Boloes.IBolaoCampeonatoClassificacaoUsuarioService service)
            : base(service)
        {

        }

        #endregion

        #region Methods


        #endregion

        #region IBolaoCampeonatoClassificacaoUsuarioService members

        [HttpPost]
        public IList<Domain.Entities.Boloes.BolaoCampeonatoClassificacaoUsuario> LoadClassificacao(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Campeonatos.CampeonatoFase fase, Domain.Entities.Campeonatos.CampeonatoGrupo grupo, Domain.Entities.Users.User user)
        {
            return Service.LoadClassificacao(bolao, fase, grupo, user);
        }
        [HttpPost]
        public IList<Domain.Entities.Boloes.BolaoCampeonatoClassificacaoUsuario> LoadClassificacao(int id, ArrayList data)
        {

            Domain.Entities.Boloes.Bolao bolao = JsonConvert.DeserializeObject<Domain.Entities.Boloes.Bolao>(data[0].ToString());
            Domain.Entities.Campeonatos.CampeonatoFase fase = JsonConvert.DeserializeObject<Domain.Entities.Campeonatos.CampeonatoFase>(data[1].ToString());
            Domain.Entities.Campeonatos.CampeonatoGrupo grupo = JsonConvert.DeserializeObject<Domain.Entities.Campeonatos.CampeonatoGrupo>(data[2].ToString());
            Domain.Entities.Users.User user = JsonConvert.DeserializeObject<Domain.Entities.Users.User>(data[3].ToString());

            return this.LoadClassificacao(bolao, fase, grupo, user);

        }
        #endregion
    }
}