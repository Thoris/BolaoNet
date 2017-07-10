using BolaoNet.Domain.Interfaces.Services.Logging;
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

        public BolaoMembroService(string userName, Interfaces.Repositories.Boloes.IBolaoMembroDao dao, ILogging logging)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Boloes.BolaoMembro>)dao, logging)
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

            return Dao.GetListUsersInBolao(this.CurrentUserName, DateTime.Now, bolao);
        }
        public IList<Entities.Boloes.BolaoMembro> GetListBolaoInUsers(Entities.Users.User user)
        {
            if (user == null)
                throw new ArgumentException("user");
            if (string.IsNullOrEmpty(user.UserName))
                throw new ArgumentException("user.Nome");

            return Dao.GetListBolaoInUsers(this.CurrentUserName, DateTime.Now, user);
        }
        public IList<Entities.ValueObjects.UserMembroStatusVO> GetUserStatus(Entities.Boloes.Bolao bolao)
        {
            if (bolao == null)
                throw new ArgumentException("bolao");
            if (string.IsNullOrEmpty(bolao.Nome))
                throw new ArgumentException("bolao.Nome");

            return Dao.GetUserStatus(this.CurrentUserName, DateTime.Now, bolao);
        }

        public bool RemoverMembroBolao(Entities.Boloes.Bolao bolao, Entities.Boloes.BolaoMembro membro)
        {
            if (bolao == null)
                throw new ArgumentException("bolao");
            if (string.IsNullOrEmpty(bolao.Nome))
                throw new ArgumentException("bolao.Nome");
            if (membro == null)
                throw new ArgumentException("membro");
            if (string.IsNullOrEmpty(membro.UserName))
                throw new ArgumentException("membro.Nome");

            return Dao.RemoverMembroBolao(base.CurrentUserName, DateTime.Now, bolao, membro);
        }

        #endregion





    }
}
