using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Boloes
{
    public class BolaoPremioApp :
        Base.GenericApp<Domain.Entities.Boloes.BolaoPremio>,
        Domain.Interfaces.Services.Boloes.IBolaoPremioService
    {
        #region Properties

        private Domain.Interfaces.Services.Boloes.IBolaoPremioService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IBolaoPremioService)base._service; }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="BolaoPremioApp" />.
        /// </summary>
        public BolaoPremioApp(Domain.Interfaces.Services.Boloes.IBolaoPremioService service)
            : base (service)
        {

        }

        #endregion
    }
}
