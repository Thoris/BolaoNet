using BolaoNet.Domain.Interfaces.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Campeonatos
{
    public class CampeonatoHistoricoService :
        Base.BaseGenericService<Entities.Campeonatos.CampeonatoHistorico>,
        Interfaces.Services.Campeonatos.ICampeonatoHistoricoService
    {

        #region Properties

        private Interfaces.Repositories.Campeonatos.ICampeonatoHistoricoDao BaseDao
        {
            get { return (Interfaces.Repositories.Campeonatos.ICampeonatoHistoricoDao)base.BaseDao; }
        }

        #endregion

        #region Constructors/Destructors

        public CampeonatoHistoricoService(string userName, Interfaces.Repositories.Campeonatos.ICampeonatoHistoricoDao dao, ILogging logging)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Campeonatos.CampeonatoHistorico>)dao, logging)
        {

        }

        #endregion

        #region ICampeonatoHistoricoService members

        public IList<Entities.Campeonatos.CampeonatoHistorico> LoadCampeoes(Entities.Campeonatos.Campeonato campeonato)
        {
            if (campeonato == null)
                throw new ArgumentException("campeonato");
            if (string.IsNullOrEmpty(campeonato.Nome))
                throw new ArgumentException("campeonato.Nome");


            return BaseDao.LoadCampeoes(base.CurrentUserName, DateTime.Now, campeonato);
        }

        #endregion
    }
}
