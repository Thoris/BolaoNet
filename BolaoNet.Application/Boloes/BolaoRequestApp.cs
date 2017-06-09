using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Boloes
{
    public class BolaoRequestApp :
        Base.GenericApp<Domain.Entities.Boloes.BolaoRequest>,
        Domain.Interfaces.Services.Boloes.IBolaoRequestService
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "BolaoRequest";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="BolaoRequestApp" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public BolaoRequestApp(string url)
            : base (url, ModuleName)
        {

        }

        #endregion
    }
}
