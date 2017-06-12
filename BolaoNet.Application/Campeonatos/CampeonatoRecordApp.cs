using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Campeonatos
{
    public class CampeonatoRecordApp :
        Base.GenericApp<Domain.Entities.Campeonatos.CampeonatoRecord>,
        Application.Interfaces.Campeonatos.ICampeonatoRecordApp
    {
        #region Properties

        private Domain.Interfaces.Services.Campeonatos.ICampeonatoRecordService Service
        {
            get { return (Domain.Interfaces.Services.Campeonatos.ICampeonatoRecordService)base._service; }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="CampeonatoRecordApp" />.
        /// </summary>
        public CampeonatoRecordApp(Domain.Interfaces.Services.Campeonatos.ICampeonatoRecordService service)
            : base (service)
        {

        }

        #endregion
    }
}
