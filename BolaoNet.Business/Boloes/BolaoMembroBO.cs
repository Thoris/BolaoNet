using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Boloes
{
    public class BolaoMembroBO :
        Base.BaseGenericBusinessBO<Entities.Boloes.BolaoMembro>,
        Interfaces.Boloes.IBolaoMembroBO
    {

        #region Properties

        private Dao.Boloes.IBolaoMembroDao Dao
        {
            get { return (Dao.Boloes.IBolaoMembroDao)base.BaseDao; }
        }

        #endregion

        #region Constructors/Destructors

        public BolaoMembroBO(string userName, Dao.Boloes.IBolaoMembroDao dao)
            : base(userName, (Dao.Base.IGenericDao<Entities.Boloes.BolaoMembro>)dao)
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
