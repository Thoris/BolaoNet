using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Boloes
{
    public class MensagemApp :
        Base.GenericApp<Domain.Entities.Boloes.Mensagem>,
        Application.Interfaces.Boloes.IMensagemApp
    {
        #region Properties

        private Domain.Interfaces.Services.Boloes.IMensagemService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IMensagemService)base._service; }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="MensagemApp" />.
        /// </summary>
        public MensagemApp(Domain.Interfaces.Services.Boloes.IMensagemService service)
            : base (service)
        {

        }

        #endregion
    }
}
