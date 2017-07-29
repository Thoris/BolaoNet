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


            if (IsSaveLog)
                CheckStart();

            IList<Entities.Boloes.BolaoMembro> res =
                Dao.GetListUsersInBolao(this.CurrentUserName, DateTime.Now, bolao);

            if (IsSaveLog)
            {
                _logging.Debug(this, GetMessageTotalTime("Carregamento de histórico do bolão [" + bolao.Nome + "] total: " + res.Count));
            }

            return res;
        }
        public IList<Entities.Boloes.BolaoMembro> GetListBolaoInUsers(Entities.Users.User user)
        {
            if (user == null)
                throw new ArgumentException("user");
            if (string.IsNullOrEmpty(user.UserName))
                throw new ArgumentException("user.Nome");


            if (IsSaveLog)
                CheckStart();

            IList<Entities.Boloes.BolaoMembro> res =
                Dao.GetListBolaoInUsers(this.CurrentUserName, DateTime.Now, user);


            if (IsSaveLog)
            {
                _logging.Debug(this, GetMessageTotalTime("Carregamento de lista de bolões do usuário [" + user.UserName + "] total: " + res.Count));
            }

            return res;
        }
        public IList<Entities.ValueObjects.UserMembroStatusVO> GetUserStatus(Entities.Boloes.Bolao bolao)
        {
            if (bolao == null)
                throw new ArgumentException("bolao");
            if (string.IsNullOrEmpty(bolao.Nome))
                throw new ArgumentException("bolao.Nome");


            if (IsSaveLog)
                CheckStart();

            IList<Entities.ValueObjects.UserMembroStatusVO> res =
                Dao.GetUserStatus(this.CurrentUserName, DateTime.Now, bolao);

            if (IsSaveLog)
            {
                _logging.Debug(this, GetMessageTotalTime("Busca de status dos usuários do bolão [" + bolao.Nome + "] total: " + res.Count));
            }

            return res;

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


            if (IsSaveLog)
                CheckStart();

            bool res = Dao.RemoverMembroBolao(base.CurrentUserName, DateTime.Now, bolao, membro);

            if (IsSaveLog)
            {
                _logging.Debug(this, GetMessageTotalTime("Removeção do usuário [" + membro.UserName + "] do bolão [" + bolao.Nome + "] res: " + res));
            }

            return res;

        }

        #endregion
    }
}
