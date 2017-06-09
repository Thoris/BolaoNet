using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Boloes
{
    public class BolaoCriterioPontosTimesApp :
        Base.GenericApp<Domain.Entities.Boloes.BolaoCriterioPontosTimes>,
        Domain.Interfaces.Services.Boloes.IBolaoCriterioPontosTimesService
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "BolaoCriterioPontosTimes";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="BolaoCriterioPontosTimesApp" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public BolaoCriterioPontosTimesApp(string url)
            : base (url, ModuleName)
        {

        }

        #endregion 
    
        public IList<Domain.Entities.Boloes.BolaoCriterioPontosTimes> GetCriterioPontosBolao(Domain.Entities.Boloes.Bolao bolao)
        {
            throw new NotImplementedException();
        }
    }
}
