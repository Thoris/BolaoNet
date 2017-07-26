using BolaoNet.Domain.Interfaces.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Boloes
{
    public class BolaoPremioService :
        Base.BaseGenericService<Entities.Boloes.BolaoPremio>,
        Interfaces.Services.Boloes.IBolaoPremioService
    {
        #region Properties

        private Interfaces.Repositories.Boloes.IBolaoPremioDao Dao
        {
            get { return (Interfaces.Repositories.Boloes.IBolaoPremioDao)base.BaseDao; }
        }

        #endregion

        #region Constructors/Destructors

        public BolaoPremioService(string userName, Interfaces.Repositories.Boloes.IBolaoPremioDao dao, ILogging logging)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Boloes.BolaoPremio>)dao, logging)
        {

        }

        #endregion

        #region IBolaoPremioService members

        public IList<Entities.Boloes.BolaoPremio> GetPremiosBolao(Entities.Boloes.Bolao bolao)
        {
            if (bolao == null)
                throw new ArgumentException("bolao");
            if (string.IsNullOrEmpty(bolao.Nome))
                throw new ArgumentException("bolao.Nome");

            return Dao.GetPremiosBolao(base.CurrentUserName, DateTime.Now, bolao);
        }

        #endregion
    }
}
