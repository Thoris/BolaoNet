using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Boloes
{
    public class BolaoRequestStatusApp :
        Base.GenericApp<Domain.Entities.Boloes.BolaoRequestStatus>,
        Domain.Interfaces.Services.Boloes.IBolaoRequestStatusService
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "BolaoRequestStatus";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="BolaoRequestStatusApp" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public BolaoRequestStatusApp(string url)
            : base (url, ModuleName)
        {

        }

        #endregion
    }
}
