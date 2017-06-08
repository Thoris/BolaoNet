using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Boloes
{
    public class BolaoMembroService :
        Base.BaseGenericService<Entities.Boloes.BolaoMembro>,
        Interfaces.Services.Boloes.IBolaoMembroService
    {

        #region Properties

        private Interfaces.Repositories.Boloes.IBolaoMembroDao Dao
        {
            get { return (Interfaces.Repositories.Boloes.IBolaoMembroDao)base.BaseDao; }
        }

        #endregion

        #region Constructors/Destructors

        public BolaoMembroService(string userName, Interfaces.Repositories.Boloes.IBolaoMembroDao dao)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Boloes.BolaoMembro>)dao)
        {

        }

        #endregion

        #region IBolaoMembroBO members

        public IList<Entities.Boloes.BolaoMembro> GetListUsersInBolao(Entities.Boloes.Bolao bolao)
        {
            if (bolao == null)
                throw new ArgumentException("bolao");
            if (string.IsNullOrEmpty(bolao.Nome))
                throw new ArgumentException("bolao.Nome");

            return Dao.GetListUsersInBolao(this.CurrentUserName, bolao);
        }

        #endregion
    }
}
