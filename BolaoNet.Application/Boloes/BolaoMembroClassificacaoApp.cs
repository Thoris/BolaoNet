using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Boloes
{
    public class BolaoMembroClassificacaoApp :
        Base.GenericApp<Domain.Entities.Boloes.BolaoMembroClassificacao>,
        Domain.Interfaces.Services.Boloes.IBolaoMembroClassificacaoService
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "BolaoMembroClassificacao";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="BolaoMembroClassificacaoApp" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public BolaoMembroClassificacaoApp(string url)
            : base (url, ModuleName)
        {

        }

        #endregion
    }
}
