﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.WebApi.Integration.Campeonatos
{
    public class CampeonatoIntegration :
        Base.GenericIntegration<Domain.Entities.Campeonatos.Campeonato>,
        Domain.Interfaces.Services.Campeonatos.ICampeonatoService
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "Campeonato";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="CampeonatoIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public CampeonatoIntegration(string url)
            : base (url, ModuleName)
        {

        }

        #endregion
    }
}