using BolaoNet.Domain.Interfaces.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Boloes
{
    public class BolaoAcertoTimePontoService :
     Base.BaseGenericService<Entities.Boloes.BolaoAcertoTimePonto>,
        Interfaces.Services.Boloes.IBolaoAcertoTimePontoService
    {
        #region Properties

        private Interfaces.Repositories.Boloes.IBolaoAcertoTimePontoDao Dao
        {
            get { return (Interfaces.Repositories.Boloes.IBolaoAcertoTimePontoDao)base.BaseDao; }
        }

        #endregion
        
        #region Constructors/Destructors

        public BolaoAcertoTimePontoService(string userName, Interfaces.Repositories.Boloes.IBolaoAcertoTimePontoDao dao, ILogging logging)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Boloes.BolaoAcertoTimePonto>)dao, logging)
        {

        }

        #endregion

        #region IBolaoAcertoTimePontoService members
        public Entities.Boloes.BolaoAcertoTimePonto GetByJogoId(Entities.Boloes.Bolao bolao, int jogoId)
        {
            if (bolao == null)
                throw new ArgumentException("bolao");
            if (string.IsNullOrEmpty(bolao.Nome))
                throw new ArgumentException("bolao.Nome");
            if (jogoId == 0)
                throw new ArgumentException("jogoId");

            return Dao.GetByJogoId(base.CurrentUserName, DateTime.Now, bolao, jogoId);
        }
        
        
        #endregion

        
    }
}
