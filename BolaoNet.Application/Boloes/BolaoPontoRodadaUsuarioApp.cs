using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Boloes
{
    public class BolaoPontoRodadaUsuarioApp :
        Base.GenericApp<Domain.Entities.Boloes.BolaoPontoRodadaUsuario>,
        Domain.Interfaces.Services.Boloes.IBolaoPontoRodadaUsuarioService
    {
        #region Properties

        private Domain.Interfaces.Services.Boloes.IBolaoPontoRodadaUsuarioService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IBolaoPontoRodadaUsuarioService)base._service; }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="BolaoPontoRodadaUsuarioApp" />.
        /// </summary>
        public BolaoPontoRodadaUsuarioApp(Domain.Interfaces.Services.Boloes.IBolaoPontoRodadaUsuarioService service)
            : base (service)
        {

        }

        #endregion
    }
}
