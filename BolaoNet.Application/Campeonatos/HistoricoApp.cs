using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Campeonatos
{
    public class HistoricoApp :
        Base.GenericApp<Domain.Entities.Campeonatos.Historico>,
        Domain.Interfaces.Services.Campeonatos.IHistoricoService
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "Historico";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="HistoricoApp" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public HistoricoApp(string url)
            : base (url, ModuleName)
        {

        }

        #endregion
    }
}
