﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Campeonatos
{
    public class CampeonatoFaseApp :
        Base.GenericApp<Domain.Entities.Campeonatos.CampeonatoFase>,
        Application.Interfaces.Campeonatos.ICampeonatoFaseApp
    {
        #region Properties

        private Domain.Interfaces.Services.Campeonatos.ICampeonatoFaseService Service
        {
            get { return (Domain.Interfaces.Services.Campeonatos.ICampeonatoFaseService)base._service; }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="CampeonatoFaseApp" />.
        /// </summary>
        public CampeonatoFaseApp(Domain.Interfaces.Services.Campeonatos.ICampeonatoFaseService service)
            : base (service)
        {

        }

        #endregion

        #region ICampeonatoFaseApp members

        public IList<Domain.Entities.Campeonatos.CampeonatoFase> GetFaseCampeonato(Domain.Entities.Campeonatos.Campeonato campeonato)
        {
            return Service.GetFaseCampeonato(campeonato);
        }

        #endregion
    }
}
