using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Integration.Campeonatos
{
    public class CampeonatoClassificacaoIntegration :
        Base.GenericIntegration<Entities.Campeonatos.CampeonatoClassificacao>,
        Business.Interfaces.Campeonatos.ICampeonatoClassificacaoBO
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "CampeonatoClassificacao";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="CampeonatoClassificacaoIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public CampeonatoClassificacaoIntegration(string url)
            : base (url, ModuleName)
        {

        }

        #endregion
    }
}
