using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Boloes
{
    public class BolaoAcertoTimePontoApp :
        Base.GenericApp<Domain.Entities.Boloes.BolaoAcertoTimePonto>,
        Application.Interfaces.Boloes.IBolaoAcertoTimePontoApp
    {
        #region Properties

        private Domain.Interfaces.Services.Boloes.IBolaoAcertoTimePontoService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IBolaoAcertoTimePontoService)base._service; }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="BolaoAcertoTimePontoApp" />.
        /// </summary>
        public BolaoAcertoTimePontoApp(Domain.Interfaces.Services.Boloes.IBolaoAcertoTimePontoService service)
            : base (service)
        {

        }

        #endregion
    }
}
