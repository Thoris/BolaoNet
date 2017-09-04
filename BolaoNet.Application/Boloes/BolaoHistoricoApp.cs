using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Boloes
{
    public class BolaoHistoricoApp :
        Base.GenericApp<Domain.Entities.Boloes.BolaoHistorico>,
        Application.Interfaces.Boloes.IBolaoHistoricoApp
    {
        #region Properties

        private Domain.Interfaces.Services.Boloes.IBolaoHistoricoService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IBolaoHistoricoService)base._service; }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="IBolaoHistoricoService" />.
        /// </summary>
        public BolaoHistoricoApp(Domain.Interfaces.Services.Boloes.IBolaoHistoricoService service)
            : base (service)
        {

        }

        #endregion

        #region IBolaoHistoricoService members



        #endregion
    }
}
