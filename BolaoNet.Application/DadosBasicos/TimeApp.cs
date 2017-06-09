using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.DadosBasicos
{
    public class TimeApp :
        Base.GenericApp<Domain.Entities.DadosBasicos.Time>,
        Domain.Interfaces.Services.DadosBasicos.ITimeService
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "Time";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="TimeApp" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public TimeApp(string url)
            : base (url, ModuleName)
        {

        }

        #endregion
    }
}
