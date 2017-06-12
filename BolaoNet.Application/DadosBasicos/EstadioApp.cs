using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.DadosBasicos
{
    public class EstadioApp :
        Base.GenericApp<Domain.Entities.DadosBasicos.Estadio>,
        Application.Interfaces.DadosBasicos.IEstadioApp
    {
        #region Properties

        private Domain.Interfaces.Services.DadosBasicos.IEstadioService Service
        {
            get { return (Domain.Interfaces.Services.DadosBasicos.IEstadioService)base._service; }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="EstadioApp" />.
        /// </summary>
        public EstadioApp(Domain.Interfaces.Services.DadosBasicos.IEstadioService service)
            : base (service)
        {

        }

        #endregion
    }
}
