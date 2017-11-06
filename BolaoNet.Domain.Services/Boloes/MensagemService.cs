using BolaoNet.Domain.Interfaces.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Boloes
{
    public class MensagemService :
        Base.BaseGenericService<Entities.Boloes.Mensagem>,
        Interfaces.Services.Boloes.IMensagemService
    {
        #region Properties

        private Interfaces.Repositories.Boloes.IMensagemDao BaseDao
        {
            get { return (Interfaces.Repositories.Boloes.IMensagemDao)base.BaseDao; }
        }

        #endregion

        #region Constructors/Destructors

        public MensagemService(string userName, Interfaces.Repositories.Boloes.IMensagemDao dao, ILogging logging)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Boloes.Mensagem>)dao, logging)
        {

        }

        #endregion

        #region IMensagemService members

        public IList<Entities.Boloes.Mensagem> GetMensagensUsuario(Entities.Boloes.Bolao bolao, Entities.Users.User user)
        {
            if (bolao == null)
                throw new ArgumentException("bolao");
            if (string.IsNullOrEmpty(bolao.Nome))
                throw new ArgumentException("bolao.Nome");
            if (user == null)
                throw new ArgumentException("user");
            if (string.IsNullOrEmpty(user.UserName))
                throw new ArgumentException("user.UserName");


            return BaseDao.GetMensagensUsuario(base.CurrentUserName, DateTime.Now, bolao, user);
        }
        public int GetTotalMensagensNaoLidas(Entities.Boloes.Bolao bolao, Entities.Users.User user)
        {
            if (bolao == null)
                throw new ArgumentException("bolao");
            if (string.IsNullOrEmpty(bolao.Nome))
                throw new ArgumentException("bolao.Nome");
            if (user == null)
                throw new ArgumentException("user");
            if (string.IsNullOrEmpty(user.UserName))
                throw new ArgumentException("user.UserName");

            return BaseDao.GetTotalMensagensNaoLidas(base.CurrentUserName, DateTime.Now, bolao, user);
        }

        public void SetMensagensLidas(Entities.Boloes.Bolao bolao, Entities.Users.User user)
        {
            if (bolao == null)
                throw new ArgumentException("bolao");
            if (string.IsNullOrEmpty(bolao.Nome))
                throw new ArgumentException("bolao.Nome");
            if (user == null)
                throw new ArgumentException("user");
            if (string.IsNullOrEmpty(user.UserName))
                throw new ArgumentException("user.UserName");

            BaseDao.SetMensagensLidas(base.CurrentUserName, DateTime.Now, bolao, user);
        }

        #endregion


    }
}
