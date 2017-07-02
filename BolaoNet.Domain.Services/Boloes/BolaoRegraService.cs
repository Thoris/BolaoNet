using BolaoNet.Domain.Interfaces.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Boloes
{
    public class BolaoRegraService :
        Base.BaseGenericService<Entities.Boloes.BolaoRegra>,
        Interfaces.Services.Boloes.IBolaoRegraService
    {

        #region Properties

        private Interfaces.Repositories.Boloes.IBolaoRegraDao Dao
        {
            get { return (Interfaces.Repositories.Boloes.IBolaoRegraDao)base.BaseDao; }
        }

        #endregion

        #region Constructors/Destructors

        public BolaoRegraService(string userName, Interfaces.Repositories.Boloes.IBolaoRegraDao dao, ILogging logging)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Boloes.BolaoRegra>)dao, logging)
        {

        }

        #endregion

        #region IBolaoRegraService members

        public IList<Entities.Boloes.BolaoRegra> GetRegrasBolao(Entities.Boloes.Bolao bolao)
        {
            if (bolao == null)
                throw new ArgumentException("bolao");
            if (string.IsNullOrEmpty(bolao.Nome))
                throw new ArgumentException("bolao.Nome");

            return Dao.GetRegrasBolao(base.CurrentUserName, DateTime.Now, bolao);
        }

        #endregion
    }
}
