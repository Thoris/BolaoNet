using BolaoNet.Domain.Interfaces.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Campeonatos
{
    public class CampeonatoFaseService :
        Base.BaseGenericService<Entities.Campeonatos.CampeonatoFase>,
        Interfaces.Services.Campeonatos.ICampeonatoFaseService
    {
        #region Properties

        private Interfaces.Repositories.Campeonatos.ICampeonatoFaseDao BaseDao
        {
            get { return (Interfaces.Repositories.Campeonatos.ICampeonatoFaseDao)base.BaseDao; }
        }

        #endregion

        #region Constructors/Destructors

        public CampeonatoFaseService(string userName, Interfaces.Repositories.Campeonatos.ICampeonatoFaseDao dao, ILogging logging)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Campeonatos.CampeonatoFase>)dao, logging)
        {

        }

        #endregion

        #region ICampeonatoFaseService members

        public IList<Entities.Campeonatos.CampeonatoFase> GetFaseCampeonato(Entities.Campeonatos.Campeonato campeonato)
        {
            if (campeonato == null)
                throw new ArgumentException("campeonato");
            if (string.IsNullOrEmpty(campeonato.Nome))
                throw new ArgumentException("campeonato.Nome");

            return BaseDao.GetFasesCampeonato(base.CurrentUserName, campeonato);
        }

        #endregion

    }
}
