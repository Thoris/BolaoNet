using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Campeonatos
{
    public class CampeonatoFaseRepositoryDao : 
        Base.BaseRepositoryDao<Domain.Entities.Campeonatos.CampeonatoFase>,
        Domain.Interfaces.Repositories.Campeonatos.ICampeonatoFaseDao
    {
        
        #region Constructors/Destructors

        public CampeonatoFaseRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion

        #region ICampeonatoFaseDao members

        public IList<Domain.Entities.Campeonatos.CampeonatoFase> GetFasesCampeonato(string currentUserName, Domain.Entities.Campeonatos.Campeonato campeonato)
        {
            return GetList(x => string.Compare(x.NomeCampeonato, campeonato.Nome, true) == 0).ToList();
        }

        #endregion
    }
}
