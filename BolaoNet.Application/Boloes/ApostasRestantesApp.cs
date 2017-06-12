using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Boloes
{
    public class ApostasRestantesApp :
        Base.GenericApp<Domain.Entities.Boloes.ApostasRestantesUser>,
        Application.Interfaces.Boloes.IApostasRestantesApp
    {
        #region Properties

        private Domain.Interfaces.Services.Boloes.IApostasRestantesService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IApostasRestantesService)base._service; }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="ApostasRestantesApp" />.
        /// </summary>
        public ApostasRestantesApp(Domain.Interfaces.Services.Boloes.IApostasRestantesService service)
            : base (service)
        {

        }

        #endregion
    }
}
