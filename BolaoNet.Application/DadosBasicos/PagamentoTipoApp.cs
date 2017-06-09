using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.DadosBasicos
{
    public class PagamentoTipoApp :
        Base.GenericApp<Domain.Entities.DadosBasicos.PagamentoTipo>, 
        Domain.Interfaces.Services.DadosBasicos.IPagamentoTipoService
    {
        #region Properties

        private Domain.Interfaces.Services.DadosBasicos.IPagamentoTipoService Service
        {
            get { return (Domain.Interfaces.Services.DadosBasicos.IPagamentoTipoService)base._service; }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="PagamentoTipoApp" />.
        /// </summary>
        public PagamentoTipoApp(Domain.Interfaces.Services.DadosBasicos.IPagamentoTipoService service)
            : base (service)
        {

        }

        #endregion
    }
}
