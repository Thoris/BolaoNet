using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.WebApi.Integration.Campeonatos
{
    public class CampeonatoIntegration :
        Base.GenericIntegration<Domain.Entities.Campeonatos.Campeonato>,
        Domain.Interfaces.Services.Campeonatos.ICampeonatoService
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "Campeonato";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="CampeonatoIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public CampeonatoIntegration(string url, string token)
            : base(url, ModuleName, token)
        {

        }

        #endregion

        #region ICampeonatoService members

        public IList<int> GetRodadasCampeonato(Domain.Entities.Campeonatos.Campeonato campeonato)
        {
            return base.HttpPostApi<IList<int>>(
            new Dictionary<string, string>(), campeonato, "GetRodadasCampeonato");
        }
        public void Reiniciar(Domain.Entities.Campeonatos.Campeonato campeonato)
        {
             base.HttpPostApi<IList<int>>(
              new Dictionary<string, string>(), campeonato, "Reiniciar");
        }

        public void ClearDatabase()
        {
            base.HttpPostApi<IList<int>>(
             new Dictionary<string, object>(), "ClearDatabase");
        }
        public IList<IList<Domain.Entities.ValueObjects.CampeonatoRecordVO>> GetRecords(Domain.Entities.Campeonatos.Campeonato campeonato, Domain.Interfaces.Services.Campeonatos.RecordTipoPesquisa tipo)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("campeonato", campeonato);
            parameters.Add("tipo", tipo);

            return base.HttpPostApi<IList<IList<Domain.Entities.ValueObjects.CampeonatoRecordVO>>>(parameters, "GetRecords");
        }

        #endregion




    }
}
