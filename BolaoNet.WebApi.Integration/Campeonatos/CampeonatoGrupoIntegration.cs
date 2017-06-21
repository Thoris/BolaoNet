using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.WebApi.Integration.Campeonatos
{
    public class CampeonatoGrupoIntegration :
        Base.GenericIntegration<Domain.Entities.Campeonatos.CampeonatoGrupo>,
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
        /// Inicializa nova instância da classe <see cref="CampeonatoGrupoIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public CampeonatoGrupoIntegration(string url)
            : base (url, ModuleName)
        {

        }

        #endregion

        #region ICampeonatoGrupoService members

        public IList<Domain.Entities.Campeonatos.CampeonatoGrupo> GetGruposCampeonato(Domain.Entities.Campeonatos.Campeonato campeonato)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
