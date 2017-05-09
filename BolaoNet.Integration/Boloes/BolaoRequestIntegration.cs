﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Integration.Boloes
{
    public class BolaoRequestIntegration :
        Base.GenericIntegration<Entities.Boloes.BolaoRequest>,
        Business.Interfaces.Boloes.IBolaoRequestBO
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "BolaoRequest";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="BolaoRequestIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public BolaoRequestIntegration(string url)
            : base (url, ModuleName)
        {

        }

        #endregion
    }
}