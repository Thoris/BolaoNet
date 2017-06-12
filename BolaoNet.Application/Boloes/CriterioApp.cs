using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Boloes
{
    public class CriterioApp :
        Base.GenericApp<Domain.Entities.Boloes.Criterio>,
        Application.Interfaces.Boloes.ICriterioApp
    {
        #region Properties

        private Domain.Interfaces.Services.Boloes.ICriterioService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.ICriterioService)base._service; }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="CriterioApp" />.
        /// </summary>
        public CriterioApp(Domain.Interfaces.Services.Boloes.ICriterioService service)
            : base (service)
        {

        }

        #endregion
    }
}
