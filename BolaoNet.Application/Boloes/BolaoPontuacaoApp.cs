using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Boloes
{
    public class BolaoPontuacaoApp :
        Base.GenericApp<Domain.Entities.Boloes.BolaoPontuacao>,
        Domain.Interfaces.Services.Boloes.IBolaoPontuacaoService
    {
        #region Properties

        private Domain.Interfaces.Services.Boloes.IBolaoPontuacaoService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IBolaoPontuacaoService)base._service; }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="BolaoPontuacaoApp" />.
        /// </summary>
        public BolaoPontuacaoApp(Domain.Interfaces.Services.Boloes.IBolaoPontuacaoService service)
            : base (service)
        {

        }

        #endregion
    }
}
