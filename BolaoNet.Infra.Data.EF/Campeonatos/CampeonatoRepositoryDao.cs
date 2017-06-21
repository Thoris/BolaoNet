using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Campeonatos
{
    public class CampeonatoRepositoryDao :
        Base.BaseRepositoryDao<Domain.Entities.Campeonatos.Campeonato>, 
        Domain.Interfaces.Repositories.Campeonatos.ICampeonatoDao
    {
        #region Constructors/Destructors

        public CampeonatoRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion

        #region ICampeonatoDao members

        public IList<int> GetRodadasCampeonato(string currentUserName, Domain.Entities.Campeonatos.Campeonato campeonato)
        {
            //var results = base.DataContext.Jogos.Distinct<(row => row.Text);
            //base.DataContext.Jogos.GroupBy(x => x.Text)
            //    .Where(g => g.Count() == 1)
            //    .Select(g => g.First());

            return null;
        }

        #endregion
    }
}
