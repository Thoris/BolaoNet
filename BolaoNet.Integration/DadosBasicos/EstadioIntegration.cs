using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Integration.DadosBasicos
{
    public class EstadioIntegration :
        Base.GenericIntegration<Entities.DadosBasicos.Estadio>, 
        Business.Interfaces.DadosBasicos.IEstadioBO
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "Estadio";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="EstadioIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public EstadioIntegration(string url)
            : base (url, ModuleName)
        {

        }

        #endregion
    }
}
