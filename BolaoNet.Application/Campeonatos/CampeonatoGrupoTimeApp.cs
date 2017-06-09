using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Campeonatos
{
    public class CampeonatoGrupoTimeApp :
        Base.GenericApp<Domain.Entities.Campeonatos.CampeonatoGrupoTime>,
        Domain.Interfaces.Services.Campeonatos.ICampeonatoGrupoTimeService
    {
        #region Properties

        private Domain.Interfaces.Services.Campeonatos.ICampeonatoGrupoTimeService Service
        {
            get { return (Domain.Interfaces.Services.Campeonatos.ICampeonatoGrupoTimeService)base._service; }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="CampeonatoGrupoTimeApp" />.
        /// </summary>
        public CampeonatoGrupoTimeApp(Domain.Interfaces.Services.Campeonatos.ICampeonatoGrupoTimeService service)
            : base (service)
        {

        }

        #endregion
    }
}
