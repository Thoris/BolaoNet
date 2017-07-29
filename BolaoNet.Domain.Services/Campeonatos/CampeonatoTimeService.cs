using BolaoNet.Domain.Interfaces.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Campeonatos
{
    public class CampeonatoTimeService :
        Base.BaseGenericService<Entities.Campeonatos.CampeonatoTime>,
        Interfaces.Services.Campeonatos.ICampeonatoTimeService
    {

        #region Properties

        private Interfaces.Repositories.Campeonatos.ICampeonatoTimeDao BaseDao
        {
            get { return (Interfaces.Repositories.Campeonatos.ICampeonatoTimeDao)base.BaseDao; }
        }

        #endregion

        #region Constructors/Destructors

        public CampeonatoTimeService(string userName, Interfaces.Repositories.Campeonatos.ICampeonatoTimeDao dao, ILogging logging)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Campeonatos.CampeonatoTime>)dao, logging)
        {

        }

        #endregion

        #region ICampeonatoTimeService members

        public IList<Entities.Campeonatos.CampeonatoTime> GetTimesCampeonato(Entities.Campeonatos.Campeonato campeonato)
        {
            if (campeonato == null)
                throw new ArgumentException("campeonato");
            if (string.IsNullOrEmpty(campeonato.Nome))
                throw new ArgumentException("campeonato.Nome");

            if (IsSaveLog)
                CheckStart();

            IList<Entities.Campeonatos.CampeonatoTime> res =
                BaseDao.GetTimesCampeonato(base.CurrentUserName, campeonato);


            if (IsSaveLog)
            {
                _logging.Debug(this, GetMessageTotalTime("Buscando os times do campeonato [" + campeonato.Nome + "] total: " + res.Count));
            }

            return res;

        }

        #endregion
    }
}
