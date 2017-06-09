using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Boloes
{
    public class BolaoPremioApp :
        Base.GenericApp<Domain.Entities.Boloes.BolaoPremio>,
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
        /// Inicializa nova instância da classe <see cref="BolaoPremioApp" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public BolaoPremioApp(string url)
            : base (url, ModuleName)
        {

        }

        #endregion
    }
}
