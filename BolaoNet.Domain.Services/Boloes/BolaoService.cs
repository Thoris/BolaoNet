using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Boloes
{
    public class BolaoService :
        Base.BaseGenericService<Entities.Boloes.Bolao>,
        Interfaces.Services.Boloes.IBolaoService
    {
        #region Properties

        private Interfaces.Repositories.Boloes.IBolaoDao Dao
        {
            get { return (Interfaces.Repositories.Boloes.IBolaoDao)base.BaseDao; }
        }

        #endregion

        #region Constructors/Destructors

        public BolaoService(string userName, Interfaces.Repositories.Boloes.IBolaoDao dao)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Boloes.Bolao>)dao)
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
