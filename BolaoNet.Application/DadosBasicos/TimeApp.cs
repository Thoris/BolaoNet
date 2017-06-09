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
        #region Properties

        private Domain.Interfaces.Services.DadosBasicos.ITimeService Service
        {
            get { return (Domain.Interfaces.Services.DadosBasicos.ITimeService)base._service; }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="TimeApp" />.
        /// </summary>
        public TimeApp(Domain.Interfaces.Services.DadosBasicos.ITimeService service)
            : base (service)
        {

        }

        #endregion
    }
}
