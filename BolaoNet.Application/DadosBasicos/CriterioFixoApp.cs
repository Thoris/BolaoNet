using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.DadosBasicos
{
    public class CriterioFixoApp :
        Base.GenericApp<Domain.Entities.DadosBasicos.CriterioFixo>,
        Domain.Interfaces.Services.DadosBasicos.ICriterioFixoService
    {
        #region Properties

        private Domain.Interfaces.Services.DadosBasicos.ICriterioFixoService Service
        {
            get { return (Domain.Interfaces.Services.DadosBasicos.ICriterioFixoService)base._service; }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="CriterioFixoApp" />.
        /// </summary>
        public CriterioFixoApp(Domain.Interfaces.Services.DadosBasicos.ICriterioFixoService service)
            : base (service)
        {

        }

        #endregion
    }
}
