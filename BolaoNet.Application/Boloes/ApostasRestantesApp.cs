using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Boloes
{
    public class ApostasRestantesApp :
        Base.GenericApp<Domain.Entities.Boloes.ApostasRestantesUser>,
        Domain.Interfaces.Services.Boloes.IApostasRestantesService
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "ApostasRestantes";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="ApostasRestantesApp" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public ApostasRestantesApp(string url)
            : base (url, ModuleName)
        {

        }

        #endregion
    }
}
