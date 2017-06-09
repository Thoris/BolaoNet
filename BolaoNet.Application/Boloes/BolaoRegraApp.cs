using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Boloes
{
    public class BolaoRegraApp :
        Base.GenericApp<Domain.Entities.Boloes.BolaoRegra>,
        Domain.Interfaces.Services.Boloes.IBolaoRegraService
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "BolaoRegra";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="BolaoRegraApp" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public BolaoRegraApp(string url)
            : base (url, ModuleName)
        {

        }

        #endregion
    }
}
