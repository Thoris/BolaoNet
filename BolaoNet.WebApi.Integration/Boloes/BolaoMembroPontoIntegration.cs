﻿using BolaoNet.WebApi.Integration.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.WebApi.Integration.Boloes
{
    public class BolaoMembroPontoIntegrationBase :
        GenericIntegration<Domain.Entities.Boloes.BolaoMembroPonto>,
        Domain.Interfaces.Services.Boloes.IBolaoMembroPontoService
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "BolaoMembroPonto";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="BolaoMembroIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public BolaoMembroPontoIntegrationBase(string url, string token)
            : base(url, ModuleName, token)
        {

        }

        #endregion

        #region IBolaoMembroService members


        public IList<Domain.Entities.Boloes.BolaoMembroPonto> GetHistoricoClassificacao(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("bolao", bolao);
            parameters.Add("user", user);

            return base.HttpPostApi<IList<Domain.Entities.Boloes.BolaoMembroPonto>>(parameters, "GetHistoricoClassificacao");   
      
        }

        #endregion
    }
}
