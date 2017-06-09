using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Boloes
{
    public class BolaoCampeonatoClassificacaoUsuarioApp :
        Base.GenericApp<Domain.Entities.Boloes.BolaoCampeonatoClassificacaoUsuario>,
        Domain.Interfaces.Services.Boloes.IBolaoCampeonatoClassificacaoUsuarioService
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "BolaoCampeonatoClassificacaoUsuario";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="BolaoCampeonatoClassificacaoUsuarioApp" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public BolaoCampeonatoClassificacaoUsuarioApp(string url)
            : base (url, ModuleName)
        {

        }

        #endregion    
    }
}
