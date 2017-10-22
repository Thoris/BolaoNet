using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.WebApi.Integration.Boloes
{
    public class BolaoPremioIntegration :
        Base.GenericIntegration<Domain.Entities.Boloes.BolaoPremio>,
        Domain.Interfaces.Services.Boloes.IBolaoPremioService
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "BolaoPremio";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="BolaoPremioIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public BolaoPremioIntegration(string url, string token)
            : base(url, ModuleName, token)
        {

        }

        #endregion

        #region IBolaoPremioService members
        
        public IList<Domain.Entities.Boloes.BolaoPremio> GetPremiosBolao(Domain.Entities.Boloes.Bolao bolao)
        {
            return base.HttpPostApi<IList<Domain.Entities.Boloes.BolaoPremio>>(
                new Dictionary<string, string>(), bolao, "GetPremiosBolao");
        }

        #endregion
    }
}
