﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.WebApi.Integration.Boloes
{
    public class BolaoIntegration :
        Base.GenericIntegration<Domain.Entities.Boloes.Bolao>,
        Domain.Interfaces.Services.Boloes.IBolaoService
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "Bolao";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="BolaoIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public BolaoIntegration(string url, string token)
            : base(url, ModuleName, token)
        {

        }

        #endregion    
    
        #region IBolaoService members

        public bool Iniciar(Domain.Entities.Users.User iniciadoBy, Domain.Entities.Boloes.Bolao bolao)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("iniciadoBy", iniciadoBy);
            parameters.Add("bolao", bolao);

            return base.HttpPostApi<bool>(parameters, "Iniciar");            
        }
        public bool Aguardar(Domain.Entities.Boloes.Bolao bolao)
        {
            return base.HttpPostApi<bool>(new Dictionary<string, string>(), bolao, "Aguardar");
        }
        public IList<Domain.Entities.Boloes.Bolao> GetBoloesDisponiveis()
        {
            return base.HttpPostApi<IList<Domain.Entities.Boloes.Bolao>>(new Dictionary<string, object>(), "GetBoloesDisponiveis");
        }
        public IList<Domain.Entities.ValueObjects.UserBoloesVO> GetBoloesUsuario(Domain.Entities.Users.User user)
        {
            return base.HttpPostApi<IList<Domain.Entities.ValueObjects.UserBoloesVO>>(new Dictionary<string, string>(), user, "GetBoloesUsuario");
        }
        public IList<Domain.Entities.ValueObjects.UserSaldoBolaoVO> GetBoloesSaldoUsuario(Domain.Entities.Users.User user)
        {
            return base.HttpPostApi<IList<Domain.Entities.ValueObjects.UserSaldoBolaoVO>>(new Dictionary<string, string>(), user, "GetBoloesSaldoUsuario");
       
        }
        public bool IsIniciado(Domain.Entities.Boloes.Bolao bolao)
        {
            return base.HttpPostApi<bool>(
                new Dictionary<string, string>(), bolao, "IsIniciado");
       
        }

        #endregion
    }
}
