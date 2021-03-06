﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Boloes
{
    public class BolaoRegraApp :
        Base.GenericApp<Domain.Entities.Boloes.BolaoRegra>,
        Application.Interfaces.Boloes.IBolaoRegraApp
    {
        #region Properties

        private Domain.Interfaces.Services.Boloes.IBolaoRegraService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IBolaoRegraService)base._service; }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="BolaoRegraApp" />.
        /// </summary>
        public BolaoRegraApp(Domain.Interfaces.Services.Boloes.IBolaoRegraService service)
            : base (service)
        {

        }

        #endregion

        #region IBolaoRegraApp members

        public IList<Domain.Entities.Boloes.BolaoRegra> GetRegrasBolao(Domain.Entities.Boloes.Bolao bolao)
        {
            return Service.GetRegrasBolao(bolao);
        }

        #endregion
    }
}
