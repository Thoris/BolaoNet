using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.WebApi.Integration.Boloes
{
    public class BolaoHistoricoIntegration :
        Base.GenericIntegration<Domain.Entities.Boloes.BolaoHistorico>,
        Domain.Interfaces.Services.Boloes.IBolaoHistoricoService
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "BolaoHistorico";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="BolaoHistoricoIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public BolaoHistoricoIntegration(string url)
            : base (url, ModuleName)
        {

        }

        #endregion    
    
        #region IBolaoHistoricoService members

        public IList<Domain.Entities.Boloes.BolaoHistorico> GetListFromBolao(Domain.Entities.Boloes.Bolao bolao, int ano)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("bolao", bolao);
            parameters.Add("ano", ano);

            return base.HttpPostApi<IList<Domain.Entities.Boloes.BolaoHistorico>>(parameters, "GetListFromBolao");
      
        }

        public IList<int> GetYearsFromBolao(Domain.Entities.Boloes.Bolao bolao)
        {
            return base.HttpPostApi<IList<int>>(
             new Dictionary<string, string>(), bolao, "GetYearsFromBolao").ToList<int>();
        
        }

        #endregion



    }
}
