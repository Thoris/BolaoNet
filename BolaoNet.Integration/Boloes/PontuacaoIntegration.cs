﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Integration.Boloes
{
    public class PontuacaoIntegration :
        Base.GenericIntegration<Entities.Boloes.Pontuacao>,
        Business.Interfaces.Boloes.IPontuacaoBO
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "Pontuacao";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="PontuacaoIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public PontuacaoIntegration(string url)
            : base (url, ModuleName)
        {

        }

        #endregion
    }
}