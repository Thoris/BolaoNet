using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Campeonatos
{
    public class CampeonatoTimeApp :
        Base.GenericApp<Domain.Entities.Campeonatos.CampeonatoTime>,
        Application.Interfaces.Campeonatos.ICampeonatoTimeApp
    {
        #region Properties

        private Domain.Interfaces.Services.Campeonatos.ICampeonatoTimeService Service
        {
            get { return (Domain.Interfaces.Services.Campeonatos.ICampeonatoTimeService)base._service; }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="CampeonatoTimeApp" />.
        /// </summary>
        public CampeonatoTimeApp(Domain.Interfaces.Services.Campeonatos.ICampeonatoTimeService service)
            : base (service)
        {

        }

        #endregion

        #region ICampeonatoTimeApp members

        public IList<Domain.Entities.Campeonatos.CampeonatoTime> GetTimesCampeonato(Domain.Entities.Campeonatos.Campeonato campeonato)
        {
            return Service.GetTimesCampeonato(campeonato);
        }

        #endregion
    }
}
