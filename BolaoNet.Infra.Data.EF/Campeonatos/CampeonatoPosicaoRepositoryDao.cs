using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Campeonatos
{
    public class CampeonatoPosicaoRepositoryDao : 
        Base.BaseRepositoryDao<Domain.Entities.Campeonatos.CampeonatoPosicao>,
        Domain.Interfaces.Repositories.Campeonatos.ICampeonatoPosicaoDao
    {
        
        #region Constructors/Destructors

        public CampeonatoPosicaoRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion

        #region ICampeonatoPosicaoDao members
        
        public IList<Domain.Entities.Campeonatos.CampeonatoPosicao> GetPosicao(string currentUserName, DateTime currentDateTime, Domain.Entities.Campeonatos.Campeonato campeonato, Domain.Entities.Campeonatos.CampeonatoFase fase)
        {
            return GetList(x => string.Compare(x.NomeCampeonato, campeonato.Nome, true) == 0 &&
                string.Compare(x.NomeFase, fase.Nome, true) == 0).OrderBy( x=> x.NomeGrupo).ToList();
        }

        #endregion
    }
}
