using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Campeonatos
{
    public class CampeonatoGrupoApp :
        Base.GenericApp<Domain.Entities.Campeonatos.CampeonatoGrupo>,
        Domain.Interfaces.Services.Campeonatos.ICampeonatoGrupoService
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "CampeonatoGrupo";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="CampeonatoGrupoApp" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public CampeonatoGrupoApp(string url)
            : base (url, ModuleName)
        {

        }

        #endregion
    }
}
