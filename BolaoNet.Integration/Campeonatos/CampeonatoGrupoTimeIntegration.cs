using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Integration.Campeonatos
{
    public class CampeonatoGrupoTimeIntegration :
        Base.GenericIntegration<Entities.Campeonatos.CampeonatoGrupoTime>,
        Business.Interfaces.Campeonatos.ICampeonatoGrupoTimeBO
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "CampeonatoGrupoTime";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="CampeonatoGrupoTimeIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public CampeonatoGrupoTimeIntegration(string url)
            : base (url, ModuleName)
        {

        }

        #endregion
    }
}
