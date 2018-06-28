using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Boloes
{
    public class BolaoPremiacaoRepositoryDao :
        Base.BaseRepositoryDao<Domain.Entities.Boloes.BolaoPremiacao>, 
        Domain.Interfaces.Repositories.Boloes.IBolaoPremiacaoDao
    {
        
        #region Constructors/Destructors

        public BolaoPremiacaoRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion

        #region IBolaoCriterioPontosDao members

        public IList<Domain.Entities.Boloes.BolaoPremiacao> LoadPremiacaoBolao(string currentUserName, DateTime currentDateTime, Domain.Entities.Boloes.Bolao bolao)
        {
            return GetList(x => string.Compare(x.NomeBolao, bolao.Nome, true) == 0).ToList();
        } 

        #endregion        
    
    }
}
