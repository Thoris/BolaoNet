using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Campeonatos
{
    public class CampeonatoGrupoRepositoryDao : 
        Base.BaseRepositoryDao<Domain.Entities.Campeonatos.CampeonatoGrupo>, 
        Domain.Interfaces.Repositories.Campeonatos.ICampeonatoGrupoDao
    {
        
        #region Constructors/Destructors

        public CampeonatoGrupoRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion

        #region ICampeonatoGrupoDao members

        public IList<Domain.Entities.Campeonatos.CampeonatoGrupo> GetGruposCampeonato(string currentUserName, Domain.Entities.Campeonatos.Campeonato campeonato)
        {
            return GetList(x => string.Compare(x.NomeCampeonato, campeonato.Nome, true) == 0).ToList();
        }

        #endregion
    }
}
