﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Integration.Boloes
{
    public class BolaoRegraIntegration :
        Base.GenericIntegration<Entities.Boloes.BolaoRegra>,
        Business.Interfaces.Boloes.IBolaoRegraBO
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "BolaoRegra";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="BolaoRegraIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public BolaoRegraIntegration(string url)
            : base (url, ModuleName)
        {

        }

        #endregion
    }
}