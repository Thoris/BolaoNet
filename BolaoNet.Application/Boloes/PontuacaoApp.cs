using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Boloes
{
    public class PontuacaoApp :
        Base.GenericApp<Domain.Entities.Boloes.Pontuacao>,
        Domain.Interfaces.Services.Boloes.IPontuacaoService
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "Pontuacao";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="PontuacaoApp" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public PontuacaoApp(string url)
            : base (url, ModuleName)
        {

        }

        #endregion
    }
}
