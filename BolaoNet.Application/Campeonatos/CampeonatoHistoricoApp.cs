using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Campeonatos
{
    public class CampeonatoHistoricoApp :
        Base.GenericApp<Domain.Entities.Campeonatos.CampeonatoHistorico>,
        Domain.Interfaces.Services.Campeonatos.ICampeonatoHistoricoService
    {
        #region Properties

        private Domain.Interfaces.Services.Campeonatos.ICampeonatoHistoricoService Service
        {
            get { return (Domain.Interfaces.Services.Campeonatos.ICampeonatoHistoricoService)base._service; }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="CampeonatoHistoricoApp" />.
        /// </summary>
        public CampeonatoHistoricoApp(Domain.Interfaces.Services.Campeonatos.ICampeonatoHistoricoService service)
            : base (service)
        {

        }

        #endregion
    }
}
