using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Boloes
{
    public class BolaoBO :
        Base.BaseGenericBusinessBO<Entities.Boloes.Bolao>,
        Interfaces.Boloes.IBolaoBO
    {
        #region Properties

        private Dao.Boloes.IBolaoDao Dao
        {
            get { return (Dao.Boloes.IBolaoDao)base.BaseDao; }
        }

        #endregion

        #region Constructors/Destructors

        public BolaoBO(string userName, Dao.Boloes.IBolaoDao dao)
            : base(userName, (Dao.Base.IGenericDao<Entities.Boloes.Bolao>)dao)
        {

        }

        #endregion

        #region IBolaoBO members

        public bool Iniciar(Entities.Users.User iniciadoBy, Entities.Boloes.Bolao bolao)
        {
            if (iniciadoBy == null)
                throw new ArgumentException("iniciadoBy");
            if (string.IsNullOrEmpty(iniciadoBy.UserName))
                throw new ArgumentException("iniciadoBy.UserName");
            if (bolao == null)
                throw new ArgumentException("bolao");
            if (string.IsNullOrEmpty(bolao.Nome))
                throw new ArgumentException("bolao.Nome");

            return Dao.Iniciar(base.CurrentUserName, DateTime.Now, iniciadoBy, bolao);
        }

        public bool Aguardar(Entities.Boloes.Bolao bolao)
        {
            if (bolao == null)
                throw new ArgumentException("bolao");
            if (string.IsNullOrEmpty(bolao.Nome))
                throw new ArgumentException("bolao.Nome");

            return Dao.Aguardar(base.CurrentUserName, DateTime.Now,  bolao);
        }

        #endregion
    }
}
