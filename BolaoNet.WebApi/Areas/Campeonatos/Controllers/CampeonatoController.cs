﻿using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Campeonatos.Controllers
{
    public class CampeonatoController:
        GenericApiController<Domain.Entities.Campeonatos.Campeonato>,
        Domain.Interfaces.Services.Campeonatos.ICampeonatoService
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.Campeonatos.ICampeonatoService Service
        {
            get { return (Domain.Interfaces.Services.Campeonatos.ICampeonatoService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public CampeonatoController()
            : base(new Domain.Services.FactoryService(null).CreateCampeonatoService())
        {

        }
        public CampeonatoController(Domain.Interfaces.Services.Campeonatos.ICampeonatoService service)
            : base(service)
        {

        }

        #endregion

        #region Methods


        #endregion

        #region ICampeonatoService members

        public IList<int> GetRodadasCampeonato(Domain.Entities.Campeonatos.Campeonato campeonato)
        {
            return Service.GetRodadasCampeonato(campeonato);
        }
        public void Reiniciar(Domain.Entities.Campeonatos.Campeonato campeonato)
        {
            Service.Reiniciar(campeonato);
        }

        public void ClearDatabase()
        {
            Service.ClearDatabase();
        }
        public IList<IList<Domain.Entities.ValueObjects.CampeonatoRecordVO>> GetRecords(Domain.Entities.Campeonatos.Campeonato campeonato, Domain.Interfaces.Services.Campeonatos.RecordTipoPesquisa tipo)
        {
            return Service.GetRecords(campeonato, tipo);
        }

        #endregion




    }
}