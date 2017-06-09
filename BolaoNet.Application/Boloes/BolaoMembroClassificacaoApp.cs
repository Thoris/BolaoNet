using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Boloes
{
    public class BolaoMembroClassificacaoApp :
        Base.GenericApp<Domain.Entities.Boloes.BolaoMembroClassificacao>,
        Domain.Interfaces.Services.Boloes.IBolaoMembroClassificacaoService
    {
        #region Properties

        private Domain.Interfaces.Services.Boloes.IBolaoMembroClassificacaoService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IBolaoMembroClassificacaoService)base._service; }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="BolaoMembroClassificacaoApp" />.
        /// </summary>
        public BolaoMembroClassificacaoApp(Domain.Interfaces.Services.Boloes.IBolaoMembroClassificacaoService service)
            : base (service)
        {

        }

        #endregion
    }
}
