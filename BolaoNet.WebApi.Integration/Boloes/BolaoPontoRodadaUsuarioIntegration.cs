using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.WebApi.Integration.Boloes
{
    public class BolaoPontoRodadaUsuarioIntegration :
        Base.GenericIntegration<Domain.Entities.Boloes.BolaoPontoRodadaUsuario>,
        Domain.Interfaces.Services.Boloes.IBolaoPontoRodadaUsuarioService
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "BolaoPontoRodadaUsuario";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="BolaoPontoRodadaUsuarioIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public BolaoPontoRodadaUsuarioIntegration(string url)
            : base (url, ModuleName)
        {

        }

        #endregion
    }
}
