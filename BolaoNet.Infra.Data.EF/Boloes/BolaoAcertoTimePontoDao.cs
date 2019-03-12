using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Boloes
{
    public class BolaoAcertoTimePontoDao : 
        Base.BaseRepositoryDao<Domain.Entities.Boloes.BolaoAcertoTimePonto>, 
        Domain.Interfaces.Repositories.Boloes.IBolaoAcertoTimePontoDao
    {
        
        #region Constructors/Destructors

        public BolaoAcertoTimePontoDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion

        #region IBolaoAcertoTimePontoDao members

        public Domain.Entities.Boloes.BolaoAcertoTimePonto GetByJogoId(string currentUserName, DateTime currentDateTime, Domain.Entities.Boloes.Bolao bolao, int jogoId)
        {
            IList<Domain.Entities.Boloes.BolaoAcertoTimePonto> list = 
                GetList(x => x.NomeBolao == bolao.Nome && x.JogoId == jogoId).ToList<Domain.Entities.Boloes.BolaoAcertoTimePonto>();

            if (list != null && list.Count > 0)
                return list[0];

            return null;

        }

        #endregion
    }
}
