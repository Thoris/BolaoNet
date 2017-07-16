using BolaoNet.Domain.Interfaces.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Campeonatos
{
    public class CampeonatoService :
        Base.BaseGenericService<Entities.Campeonatos.Campeonato>,
        Interfaces.Services.Campeonatos.ICampeonatoService
    {
        #region Properties

        private Interfaces.Repositories.Campeonatos.ICampeonatoDao BaseDao
        {
            get { return (Interfaces.Repositories.Campeonatos.ICampeonatoDao)base.BaseDao; }
        }

        #endregion

        #region Constructors/Destructors

        public CampeonatoService(string userName, Interfaces.Repositories.Campeonatos.ICampeonatoDao dao, ILogging logging)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Campeonatos.Campeonato>)dao, logging)
        {

        }

        #endregion

        #region ICampeonatoService members

        public IList<int> GetRodadasCampeonato(Entities.Campeonatos.Campeonato campeonato)
        {
            if (campeonato == null)
                throw new ArgumentException("campeonato");
            if (string.IsNullOrEmpty(campeonato.Nome))
                throw new ArgumentException("campeonato.Nome");

            return BaseDao.GetRodadasCampeonato(base.CurrentUserName, campeonato);
        }



        public void Reiniciar(Entities.Campeonatos.Campeonato campeonato)
        {
            BaseDao.Reiniciar(base.CurrentUserName, DateTime.Now, campeonato);
        }

        public void ClearDatabase()
        {
            BaseDao.ClearDatabase(base.CurrentUserName, DateTime.Now);
        }
        #endregion
    }
}
