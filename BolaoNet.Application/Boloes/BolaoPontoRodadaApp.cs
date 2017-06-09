using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Boloes
{
    public class BolaoPontoRodadaApp :
        Base.GenericApp<Domain.Entities.Boloes.BolaoPontoRodada>,
        Domain.Interfaces.Services.Boloes.IBolaoPontoRodadaService
    {
        #region Properties

        private Domain.Interfaces.Services.Boloes.IBolaoPontoRodadaService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IBolaoPontoRodadaService)base._service; }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="BolaoPontoRodadaApp" />.
        /// </summary>
        public BolaoPontoRodadaApp(Domain.Interfaces.Services.Boloes.IBolaoPontoRodadaService service)
            : base (service)
        {

        }

        #endregion
    }
}
