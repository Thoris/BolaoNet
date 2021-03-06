﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Campeonatos
{
    public class CampeonatoPosicaoApp :
        Base.GenericApp<Domain.Entities.Campeonatos.CampeonatoPosicao>,
        Application.Interfaces.Campeonatos.ICampeonatoPosicaoApp
    {
        #region Properties

        private Domain.Interfaces.Services.Campeonatos.ICampeonatoPosicaoService Service
        {
            get { return (Domain.Interfaces.Services.Campeonatos.ICampeonatoPosicaoService)base._service; }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="CampeonatoPosicaoApp" />.
        /// </summary>
        public CampeonatoPosicaoApp(Domain.Interfaces.Services.Campeonatos.ICampeonatoPosicaoService service)
            : base (service)
        {

        }

        #endregion

        #region ICampeonatoPosicaoApp members

        public IList<Domain.Entities.Campeonatos.CampeonatoPosicao> GetPosicao(Domain.Entities.Campeonatos.Campeonato campeonato, Domain.Entities.Campeonatos.CampeonatoFase fase)
        {
            return Service.GetPosicao(campeonato, fase);
        }

        #endregion
    }
}
