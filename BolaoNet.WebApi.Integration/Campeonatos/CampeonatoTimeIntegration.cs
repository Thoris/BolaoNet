using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.WebApi.Integration.Campeonatos
{
    public class CampeonatoTimeIntegration :
        Base.GenericIntegration<Domain.Entities.Campeonatos.CampeonatoTime>,
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
        /// Inicializa nova instância da classe <see cref="CampeonatoTimeIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public CampeonatoTimeIntegration(string url, string token)
            : base(url, ModuleName, token)
        {

        }

        #endregion

        #region ICampeonatoTimeService members

        public IList<Domain.Entities.Campeonatos.CampeonatoTime> GetTimesCampeonato(Domain.Entities.Campeonatos.Campeonato campeonato)
        {
            return base.HttpPostApi<IList<Domain.Entities.Campeonatos.CampeonatoTime>>(
                new Dictionary<string, string>(), campeonato, "GetTimesCampeonato");
        }

        #endregion
    }
}
