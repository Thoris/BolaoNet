using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Campeonatos
{
    public class HistoricoApp :
        Base.GenericApp<Domain.Entities.Campeonatos.Historico>,
        Domain.Interfaces.Services.Campeonatos.IHistoricoService
    {
        #region Properties

        private Domain.Interfaces.Services.Campeonatos.IHistoricoService Service
        {
            get { return (Domain.Interfaces.Services.Campeonatos.IHistoricoService)base._service; }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="HistoricoApp" />.
        /// </summary>
        public HistoricoApp(Domain.Interfaces.Services.Campeonatos.IHistoricoService service)
            : base (service)
        {

        }

        #endregion
    }
}
