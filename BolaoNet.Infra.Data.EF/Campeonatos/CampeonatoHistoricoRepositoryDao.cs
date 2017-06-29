using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Campeonatos
{
    public class CampeonatoHistoricoRepositoryDao : 
        Base.BaseRepositoryDao<Domain.Entities.Campeonatos.CampeonatoHistorico>,
        Domain.Interfaces.Repositories.Campeonatos.ICampeonatoHistoricoDao
    {        
        #region Constructors/Destructors

        public CampeonatoHistoricoRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion

        #region ICampeonatoHistoricoDao members

        public IList<Domain.Entities.Campeonatos.CampeonatoHistorico> LoadCampeoes(string currentUserName, DateTime currentDateTime, Domain.Entities.Campeonatos.Campeonato campeonato)
        {
            return base.GetList ( 
                x => x.NomeCampeonato == campeonato.Nome
                ).OrderByDescending( x => x.Ano ).ToList();
        }

        #endregion
    }
}
