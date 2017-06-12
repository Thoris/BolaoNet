using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Boloes
{
    public class BolaoRequestStatusApp :
        Base.GenericApp<Domain.Entities.Boloes.BolaoRequestStatus>,
        Application.Interfaces.Boloes.IBolaoRequestStatusApp
    {
        #region Properties

        private Domain.Interfaces.Services.Boloes.IBolaoRequestStatusService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IBolaoRequestStatusService)base._service; }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="BolaoRequestStatusApp" />.
        /// </summary>
        public BolaoRequestStatusApp(Domain.Interfaces.Services.Boloes.IBolaoRequestStatusService service)
            : base (service)
        {

        }

        #endregion
    }
}
