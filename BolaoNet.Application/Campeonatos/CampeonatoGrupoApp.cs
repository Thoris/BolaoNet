using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Campeonatos
{
    public class CampeonatoGrupoApp :
        Base.GenericApp<Domain.Entities.Campeonatos.CampeonatoGrupo>,
        Application.Interfaces.Campeonatos.ICampeonatoGrupoApp
    {
        #region Properties

        private Domain.Interfaces.Services.Campeonatos.ICampeonatoGrupoService Service
        {
            get { return (Domain.Interfaces.Services.Campeonatos.ICampeonatoGrupoService)base._service; }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="CampeonatoGrupoApp" />.
        /// </summary>
        public CampeonatoGrupoApp(Domain.Interfaces.Services.Campeonatos.ICampeonatoGrupoService service)
            : base (service)
        {

        }

        #endregion

        #region ICampeonatoGrupoApp members

        public IList<Domain.Entities.Campeonatos.CampeonatoGrupo> GetGruposCampeonato(Domain.Entities.Campeonatos.Campeonato campeonato)
        {
            return Service.GetGruposCampeonato(campeonato);
        }

        #endregion
    }
}
