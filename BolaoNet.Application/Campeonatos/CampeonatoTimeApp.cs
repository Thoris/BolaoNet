using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Campeonatos
{
    public class CampeonatoTimeApp :
        Base.GenericApp<Domain.Entities.Campeonatos.CampeonatoTime>,
        Domain.Interfaces.Services.Campeonatos.ICampeonatoTimeService
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "CampeonatoTime";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="CampeonatoTimeApp" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public CampeonatoTimeApp(string url)
            : base (url, ModuleName)
        {

        }

        #endregion
    }
}
