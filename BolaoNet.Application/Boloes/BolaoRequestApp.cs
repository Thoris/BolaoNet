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
        #region Properties

        private Domain.Interfaces.Services.Boloes.IBolaoRequestService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IBolaoRequestService)base._service; }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="BolaoRequestApp" />.
        /// </summary>
        public BolaoRequestApp(Domain.Interfaces.Services.Boloes.IBolaoRequestService service)
            : base (service)
        {

        }

        #endregion
    }
}
