using BolaoNet.Domain.Interfaces.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Boloes
{
    public class BolaoHistoricoService :
        Base.BaseGenericService<Entities.Boloes.BolaoHistorico>,
        Interfaces.Services.Boloes.IBolaoHistoricoService
    {
        #region Properties

        private Interfaces.Repositories.Boloes.IBolaoHistoricoDao Dao
        {
            get { return (Interfaces.Repositories.Boloes.IBolaoHistoricoDao)base.BaseDao; }
        }

        #endregion

        #region Constructors/Destructors

        public BolaoHistoricoService(string userName, Interfaces.Repositories.Boloes.IBolaoHistoricoDao dao, ILogging logging)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Boloes.BolaoHistorico>)dao, logging)
        {

        }

        #endregion

        #region IBolaoHistoricoService members

        public IList<Entities.Boloes.BolaoHistorico> GetListFromBolao(Entities.Boloes.Bolao bolao, int ano)
        {
            if (bolao == null)
                throw new ArgumentException("bolao");
            if (string.IsNullOrEmpty(bolao.Nome))
                throw new ArgumentException("bolao.Nome");

            return Dao.GetListFromBolao(base.CurrentUserName, DateTime.Now, bolao, ano);
        }
        public IList<int> GetYearsFromBolao(Entities.Boloes.Bolao bolao)
        {
            if (bolao == null)
                throw new ArgumentException("bolao");
            if (string.IsNullOrEmpty(bolao.Nome))
                throw new ArgumentException("bolao.Nome");

            return Dao.GetYearsFromBolao(base.CurrentUserName, DateTime.Now, bolao);
        }

        #endregion



    }
}
