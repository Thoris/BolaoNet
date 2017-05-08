﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Integration.Campeonatos
{
    public class FaseIntegration :
        Base.GenericIntegration<Entities.Campeonatos.Fase>,
        Business.Interfaces.Campeonatos.IFaseBO
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "Fase";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="FaseIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public FaseIntegration(string url)
            : base (url, ModuleName)
        {

        }

        #endregion
    }
}
