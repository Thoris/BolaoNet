﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.WebApi.Integration.Boloes
{
    public class ApostaExtraUsuarioIntegration :
        Base.GenericIntegration<Domain.Entities.Boloes.ApostaExtraUsuario>,
        Domain.Interfaces.Services.Boloes.IApostaExtraUsuarioService
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "ApostaExtraUsuario";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="ApostaExtraUsuarioIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public ApostaExtraUsuarioIntegration(string url, string token)
            : base(url, ModuleName, token)
        {

        }

        #endregion

        #region IApostaExtraUsuarioService members

        public IList<Domain.Entities.ValueObjects.ApostaExtraUsuarioVO> GetApostasUser(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("bolao", bolao);
            parameters.Add("user", user);

            return base.HttpPostApi<ICollection<Domain.Entities.ValueObjects.ApostaExtraUsuarioVO>>(
                parameters, "GetApostasUser").ToList<Domain.Entities.ValueObjects.ApostaExtraUsuarioVO>();
        }

        public IList<Domain.Entities.Boloes.ApostaExtraUsuario> GetApostasBolao(Domain.Entities.Boloes.Bolao bolao)
        {
            return base.HttpPostApi<ICollection<Domain.Entities.Boloes.ApostaExtraUsuario>>
                (new Dictionary<string, string>(), bolao, "GetApostasBolao").ToList<Domain.Entities.Boloes.ApostaExtraUsuario>();
        }

        public IList<IList<Domain.Entities.Boloes.ApostaExtraUsuario>> GetApostasBolaoAgrupado(Domain.Entities.Boloes.Bolao bolao)
        {
            return base.HttpPostApi<IList<IList<Domain.Entities.Boloes.ApostaExtraUsuario>>>
                (new Dictionary<string, string>(), bolao, "GetApostasBolaoAgrupado").ToList();
        }

        #endregion
    }
}
