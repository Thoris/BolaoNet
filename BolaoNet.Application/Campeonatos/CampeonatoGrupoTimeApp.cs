using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Campeonatos
{
    public class CampeonatoGrupoTimeApp :
        Base.GenericApp<Domain.Entities.Campeonatos.CampeonatoGrupoTime>,
        Domain.Interfaces.Services.Campeonatos.ICampeonatoGrupoTimeService
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "CampeonatoGrupoTime";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="CampeonatoGrupoTimeApp" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public CampeonatoGrupoTimeApp(string url)
            : base (url, ModuleName)
        {

        }

        #endregion
    }
}
