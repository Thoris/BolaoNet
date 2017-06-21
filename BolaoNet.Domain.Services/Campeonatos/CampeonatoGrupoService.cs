using BolaoNet.Domain.Interfaces.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Campeonatos
{
    public class CampeonatoGrupoService :
        Base.BaseGenericService<Entities.Campeonatos.CampeonatoGrupo>,
        Interfaces.Services.Campeonatos.ICampeonatoGrupoService
    {
        #region Properties

        private Interfaces.Repositories.Campeonatos.ICampeonatoGrupoDao BaseDao
        {
            get { return (Interfaces.Repositories.Campeonatos.ICampeonatoGrupoDao)base.BaseDao; }
        }

        #endregion

        #region Constructors/Destructors

        public CampeonatoGrupoService(string userName, Interfaces.Repositories.Campeonatos.ICampeonatoGrupoDao dao, ILogging logging)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Campeonatos.CampeonatoGrupo>)dao, logging)
        {

        }

        #endregion


        #region ICampeonatoGrupoService members

        public IList<Entities.Campeonatos.CampeonatoGrupo> GetGruposCampeonato(Entities.Campeonatos.Campeonato campeonato)
        {
            if (campeonato == null)
                throw new ArgumentException("campeonato");
            if (string.IsNullOrEmpty(campeonato.Nome))
                throw new ArgumentException("campeonato.Nome");

            return BaseDao.GetGruposCampeonato(base.CurrentUserName, campeonato);
        }

        #endregion
    }
}
