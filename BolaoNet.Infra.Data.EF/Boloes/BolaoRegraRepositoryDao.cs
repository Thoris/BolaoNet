using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Boloes
{
    public class BolaoRegraRepositoryDao :
        Base.BaseRepositoryDao<Domain.Entities.Boloes.BolaoRegra>,
        Domain.Interfaces.Repositories.Boloes.IBolaoRegraDao
    {
        
        #region Constructors/Destructors

        public BolaoRegraRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion

        #region IBolaoRegraDao members

        public IList<Domain.Entities.Boloes.BolaoRegra> GetRegrasBolao(string currentUserName, DateTime currentDateTime, Domain.Entities.Boloes.Bolao bolao)
        {
            return GetList(x => string.Compare(x.NomeBolao, bolao.Nome, true) == 0).ToList ();
        }

        #endregion
    }
}
