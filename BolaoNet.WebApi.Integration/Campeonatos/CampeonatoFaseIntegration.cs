using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.WebApi.Integration.Campeonatos
{
    public class CampeonatoFaseIntegration :
        Base.GenericIntegration<Domain.Entities.Campeonatos.CampeonatoFase>,
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
        /// Inicializa nova instância da classe <see cref="CampeonatoFaseIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public CampeonatoFaseIntegration(string url)
            : base (url, ModuleName)
        {

        }

        #endregion

        #region ICampeonatoFaseService members

        public IList<Domain.Entities.Campeonatos.CampeonatoFase> GetFaseCampeonato(Domain.Entities.Campeonatos.Campeonato campeonato)
        {
            throw new NotImplementedException();
        }

        #endregion


    }
}
