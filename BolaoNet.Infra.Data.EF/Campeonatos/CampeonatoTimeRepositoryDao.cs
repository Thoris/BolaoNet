using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Campeonatos
{
    public class CampeonatoTimeRepositoryDao : 
        Base.BaseRepositoryDao<Domain.Entities.Campeonatos.CampeonatoTime>,
        Domain.Interfaces.Repositories.Campeonatos.ICampeonatoTimeDao
    {
        
        #region Constructors/Destructors

        public CampeonatoTimeRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion

        #region ICampeonatoTimeDao members

        public IList<Domain.Entities.Campeonatos.CampeonatoTime> GetTimesCampeonato(string currentUserName, Domain.Entities.Campeonatos.Campeonato campeonato)
        {
            return GetList(x => string.Compare(x.NomeCampeonato, campeonato.Nome, true) == 0).ToList();
        }

        #endregion
    }
}
