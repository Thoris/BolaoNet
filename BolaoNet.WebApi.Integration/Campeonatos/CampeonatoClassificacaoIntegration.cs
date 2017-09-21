using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.WebApi.Integration.Campeonatos
{
    public class CampeonatoClassificacaoIntegration :
        Base.GenericIntegration<Domain.Entities.Campeonatos.CampeonatoClassificacao>,
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
        /// Inicializa nova instância da classe <see cref="CampeonatoClassificacaoIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public CampeonatoClassificacaoIntegration(string url)
            : base (url, ModuleName)
        {

        }

        #endregion

        #region ICampeonatoClassificacaoService members

        public IList<Domain.Entities.Campeonatos.CampeonatoClassificacao> LoadClassificacao(Domain.Entities.Campeonatos.Campeonato campeonato, Domain.Entities.Campeonatos.CampeonatoFase fase, Domain.Entities.Campeonatos.CampeonatoGrupo grupo, int rodada)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("campeonato", campeonato);
            parameters.Add("fase", fase);
            parameters.Add("grupo", grupo);
            parameters.Add("rodada", rodada);

            return HttpPostApi<IList<Domain.Entities.Campeonatos.CampeonatoClassificacao>>(
                parameters, "LoadClassificacao");
        }

        #endregion
    }
}
