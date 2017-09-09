using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Boloes
{
    public class BolaoHistoricoRepositoryDao :
        Base.BaseRepositoryDao<Domain.Entities.Boloes.BolaoHistorico>,
        Domain.Interfaces.Repositories.Boloes.IBolaoHistoricoDao
    {
        
        #region Constructors/Destructors

        public BolaoHistoricoRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion

        #region IBolaoHistoricoDao membros

        public IList<Domain.Entities.Boloes.BolaoHistorico> GetListFromBolao(string currentUserName, DateTime currentDateTime, Domain.Entities.Boloes.Bolao bolao, int ano)
        {
            return GetList(x => string.Compare(x.NomeBolao, bolao.Nome, true) == 0 && x.Ano == ano).ToList();
        }

        public IList<int> GetYearsFromBolao(string currentName, DateTime currentDateTime, Domain.Entities.Boloes.Bolao bolao)
        {
            var query = from j in base.DataContext.BoloesHistorico
                        where string.Compare(j.NomeBolao, bolao.Nome, true) == 0
                        select j.Ano;

            IList<int> result = query.Distinct().ToList();

            return result;
        }

        #endregion    
    

    
    
    }
    
}
