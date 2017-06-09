using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Campeonatos
{
    public class CampeonatoPosicaoApp :
        Base.GenericApp<Domain.Entities.Campeonatos.CampeonatoPosicao>,
        Domain.Interfaces.Services.Campeonatos.ICampeonatoPosicaoService
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "CampeonatoPosicao";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="CampeonatoPosicaoApp" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public CampeonatoPosicaoApp(string url)
            : base (url, ModuleName)
        {

        }

        #endregion
    }
}
