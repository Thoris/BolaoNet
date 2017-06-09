using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Campeonatos
{
    public class CampeonatoClassificacaoApp :
        Base.GenericApp<Domain.Entities.Campeonatos.CampeonatoClassificacao>,
        Domain.Interfaces.Services.Campeonatos.ICampeonatoClassificacaoService
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "CampeonatoClassificacao";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="CampeonatoClassificacaoApp" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public CampeonatoClassificacaoApp(string url)
            : base (url, ModuleName)
        {

        }

        #endregion
    }
}
