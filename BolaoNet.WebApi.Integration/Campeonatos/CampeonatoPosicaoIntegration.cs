using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.WebApi.Integration.Campeonatos
{
    public class CampeonatoPosicaoIntegration :
        Base.GenericIntegration<Domain.Entities.Campeonatos.CampeonatoPosicao>,
        Domain.Interfaces.Services.Campeonatos.ICampeonatoPosicaoService
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "CampeonatoPosicao";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="CampeonatoPosicaoIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public CampeonatoPosicaoIntegration(string url, string token)
            : base(url, ModuleName, token)
        {

        }

        #endregion

        #region ICampeonatoPosicaoService members
        
        public IList<Domain.Entities.Campeonatos.CampeonatoPosicao> GetPosicao(Domain.Entities.Campeonatos.Campeonato campeonato, Domain.Entities.Campeonatos.CampeonatoFase fase)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("campeonato", campeonato);
            parameters.Add("fase", fase);

            return base.HttpPostApi<IList<Domain.Entities.Campeonatos.CampeonatoPosicao>>(parameters, "GetPosicao");
        }

        #endregion
    }
}
