using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.WebApi.Integration.Boloes
{
    public class ApostaPontosIntegration :
        Base.GenericIntegration<Domain.Entities.Boloes.ApostaPontos>,
        Domain.Interfaces.Services.Boloes.IApostaPontosService
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "ApostaPontos";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="ApostaPontosIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public ApostaPontosIntegration(string url, string token)
            : base(url, ModuleName, token)
        {

        }

        #endregion    
    }
}
