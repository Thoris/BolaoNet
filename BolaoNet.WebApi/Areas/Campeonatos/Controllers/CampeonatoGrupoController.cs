﻿using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BolaoNet.Services.Areas.Campeonatos.Controllers
{
    public class CampeonatoGrupoController:
        GenericApiController<Domain.Entities.Campeonatos.CampeonatoGrupo>, 
        Domain.Interfaces.Services.Campeonatos.ICampeonatoGrupoService
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.Campeonatos.ICampeonatoGrupoService Service
        {
            get { return (Domain.Interfaces.Services.Campeonatos.ICampeonatoGrupoService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        //public CampeonatoGrupoController()
        //    : base(new Domain.Services.FactoryService(null).CreateCampeonatoGrupoService())
        //{

        //}
        public CampeonatoGrupoController(Domain.Interfaces.Services.Campeonatos.ICampeonatoGrupoService service)
            : base(service)
        {

        }

        #endregion

        #region Methods


        #endregion


        #region ICampeonatoGrupoService members

        [HttpPost]
        public IList<Domain.Entities.Campeonatos.CampeonatoGrupo> GetGruposCampeonato(Domain.Entities.Campeonatos.Campeonato campeonato)
        {
            return Service.GetGruposCampeonato(campeonato);
        }

        #endregion
    }
}