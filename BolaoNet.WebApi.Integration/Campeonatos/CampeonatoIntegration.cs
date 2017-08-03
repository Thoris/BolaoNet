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
        public CampeonatoIntegration(string url)
            : base (url, ModuleName)
        {

        }

        #endregion

        #region ICampeonatoService members

        public IList<int> GetRodadasCampeonato(Domain.Entities.Campeonatos.Campeonato campeonato)
        {
            throw new NotImplementedException();
        }
        public void Reiniciar(Domain.Entities.Campeonatos.Campeonato campeonato)
        {
            throw new NotImplementedException();
        }

        public void ClearDatabase()
        {
            throw new NotImplementedException();
        }
        public IList<IList<Domain.Entities.ValueObjects.CampeonatoRecordVO>> GetRecords(Domain.Entities.Campeonatos.Campeonato campeonato, Domain.Interfaces.Services.Campeonatos.RecordTipoPesquisa tipo)
        {
            throw new NotImplementedException();
        }

        #endregion




    }
}
