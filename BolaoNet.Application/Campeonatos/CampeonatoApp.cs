﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Campeonatos
{
    public class CampeonatoApp :
        Base.GenericApp<Domain.Entities.Campeonatos.Campeonato>,
        Application.Interfaces.Campeonatos.ICampeonatoApp
    {
        #region Properties

        private Domain.Interfaces.Services.Campeonatos.ICampeonatoService Service
        {
            get { return (Domain.Interfaces.Services.Campeonatos.ICampeonatoService)base._service; }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="CampeonatoApp" />.
        /// </summary>
        public CampeonatoApp(Domain.Interfaces.Services.Campeonatos.ICampeonatoService service)
            : base (service)
        {

        }

        #endregion

        #region ICampeonatoApp members

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
