using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Campeonatos
{
    public class CampeonatoFaseApp :
        Base.GenericApp<Domain.Entities.Campeonatos.CampeonatoFase>,
        Domain.Interfaces.Services.Campeonatos.ICampeonatoFaseService
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "CampeonatoFase";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="CampeonatoFaseApp" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public CampeonatoFaseApp(string url)
            : base (url, ModuleName)
        {

        }

        #endregion
    }
}
