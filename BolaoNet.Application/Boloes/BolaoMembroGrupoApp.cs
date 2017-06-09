using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Boloes
{
    public class BolaoMembroGrupoApp :
        Base.GenericApp<Domain.Entities.Boloes.BolaoMembroGrupo>,
        Domain.Interfaces.Services.Boloes.IBolaoMembroGrupoService
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "BolaoMembroGrupo";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="BolaoMembroGrupoApp" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public BolaoMembroGrupoApp(string url)
            : base (url, ModuleName)
        {

        }

        #endregion
    }
}
