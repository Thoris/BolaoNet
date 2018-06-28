using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.WebApi.Integration.Boloes
{
    public class BolaoPremiacaoIntegration :
        Base.GenericIntegration<Domain.Entities.Boloes.BolaoPremiacao>,
        Domain.Interfaces.Services.Boloes.IBolaoPremiacaoService
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "BolaoPremiacao";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="BolaoCriterioPontosIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public BolaoPremiacaoIntegration(string url, string token)
            : base(url, ModuleName, token)
        {

        }

        #endregion    
    
        #region IBolaoCriterioPontosService members

        public IList<Domain.Entities.Boloes.BolaoPremiacao> LoadPremiacaoBolao(Domain.Entities.Boloes.Bolao bolao)
        {
            return base.HttpPostApi<ICollection<Domain.Entities.Boloes.BolaoPremiacao>>(
               new Dictionary<string, string>(), bolao, "LoadPremiacaoBolao").ToList<Domain.Entities.Boloes.BolaoPremiacao>();
        
        }
       
        #endregion

    }
}
